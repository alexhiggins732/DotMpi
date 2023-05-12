/*
 Copyright (c) 2023 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 
 
 Source code for this software can be found at https://github.com/alexhiggins732/DotMpi
 
 This software is licensce under GNU General Public License version 3 as described in the LICENSE
 file at https://github.com/alexhiggins732/DotMpi/LICENSE
 
 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.IO.Pipes;
using System.Data;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Linq;
using System.Diagnostics.CodeAnalysis;

namespace DotMpi
{
    public partial class Mpi
    {
        /// <summary>
        /// A parallel function runner that coordinates execution on multiple processors.
        /// </summary>
        /// <typeparam name="TResult">The type of result returned by each process thread execution.</typeparam>
        public class FunctionRunner<TResult>

        {
            protected static Logger Logger = Logger.Instance;
            /// <summary>
            /// The inclusive starting processor thread index.
            /// </summary>
            public int Start { get; }

            /// <summary>
            /// The exclusing ending processor thread index.
            /// </summary>
            public int End { get; }

            /// <summary>
            /// Flag to track if all process threads have completed execution.
            /// </summary>
            public bool IsRunning { get; private set; }

            /// <summary>
            /// Array of results returned from each executed process. Results are ordered by the processor thread they were returned from.
            /// </summary>
            public Dictionary<int, TResult?> Results = new();


            /// <summary>
            /// Array of serialized results returned from each executed process. Results are ordered by the processor thread they were returned from.
            /// </summary>
            public Dictionary<int, SerializableValue<TResult?>> SerializedResults = new();

            /// <summary>
            /// A flag indicating if any of the results from the executed process returned an error.
            /// </summary>
            public bool HasError => SerializedResults.Any(x => x.Value.HasError);

            /// <summary>
            /// A flag indicating if any of the results from the executed process returned an error.
            /// </summary>
            public Dictionary<int, ErrorData> ErrorData
            {
                get
                {
                    var result = new Dictionary<int, ErrorData>();
                    if (HasError)
                    {
                        foreach (var kvp in SerializedResults)
                        {
                            var errorData = kvp.Value.ErrorData;
                            if (errorData is not null && errorData is ErrorData exceptionData)
                            {
                                result.Add(kvp.Key, exceptionData);
                            }
                        }
                    }
                    return result;
                }
            }


            /// <summary>
            /// Flag to enable logging on the MPI process runner and all processes launched.
            /// Also enables file logging with a seperate log created for each process.
            /// </summary>
            public bool LoggingEnabled { get; set; }


            /// <summary>
            /// A list of task that monitor each process thread for completion.
            /// </summary>
            public List<Task> Tasks { get; private set; } = new();

            /// <summary>
            /// A list of processes for each process thread executed.
            /// </summary>
            internal List<Process> procs = new();

            /// <summary>
            /// Delegate function to provide arguments to each process.
            /// </summary>
            protected Func<int, IArgProvider> ArgProvider { get; }

            /// <summary>
            /// Delegate function to invoke on each parallel process
            /// </summary>
            protected Delegate Delegate { get; }

            /// <summary>
            /// Occurs when a parallel process function result is returned.
            /// </summary>
            /// <typeparam name="TResult">The type of the function result.</typeparam>
            /// <param name="sender">The <see cref="ParallelFunctionRunner{TResult}{TResult}"/> that raised the event.</param>
            /// <param name="e">A <see cref="FunctionResultEventArgs{TResult}"/> that contains the event data including the process thread index, process ID, pipe name, result TValue, and serialized result.</param>
            public event EventHandler<FunctionResultEventArgs<TResult>>? FunctionResultReturned;

            /// <summary>
            /// Occurs when a parallel process function result is returned.
            /// </summary>
            /// <typeparam name="TResult">The type of the function result.</typeparam>
            /// <param name="sender">The <see cref="ParallelFunctionRunner{TResult}{TResult}"/> that raised the event.</param>
            /// <param name="e">A <see cref="FunctionInvokedEventArgs{TResult}"/> that contains the event data including the process thread index, process ID, pipe name, result TValue, and serialized result.</param>
            public event EventHandler<FunctionInvokedEventArgs<TResult>>? FunctionInvoked;


            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="parallelFunction">The parallelFunction to invoke</param>
            /// <exception cref="ArgumentException"></exception>
            public FunctionRunner(IParalellFunction parallelFunction, bool enableLogging)
                : this(parallelFunction)
            {
                this.LoggingEnabled = enableLogging;
            }

            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="parallelFunction">The parallelFunction to invoke</param>
            /// <exception cref="ArgumentException"></exception>

            public FunctionRunner(IParalellFunction parallelFunction)
            {
                var fromInclusive = parallelFunction.Start;
                var toExclusive = parallelFunction.End;

                if (toExclusive <= fromInclusive)
                {
                    throw new ArgumentException("Start must less than end", nameof(toExclusive));
                }
                else if (fromInclusive < 0)// previous check ensures to exclusive is positve and >0 if from =>0
                {
                    throw new ArgumentException("Start must be greater than zero", nameof(fromInclusive));
                }

                if (parallelFunction.Delegate is null)
                {
                    throw new ArgumentNullException(nameof(parallelFunction.Delegate));
                }

                if (parallelFunction.ArgProvider is null)
                {
                    throw new ArgumentNullException(nameof(parallelFunction.ArgProvider));
                }

                Start = fromInclusive;
                End = toExclusive;
                this.ArgProvider = parallelFunction.ArgProvider;
                this.Delegate = parallelFunction.Delegate;

            }


            /// <summary>
            /// Runs the process by executing a remote call through a named pipe server stream.
            /// </summary>
            /// <param name="target">The delegate target to execute remotely.</param>
            /// <param name="pipeServer">The named pipe server stream to use for the remote call.</param>
            /// <param name="pipeName">The name of the named pipe.</param>
            /// <param name="p">The process instance to execute the remote call in.</param>
            /// <param name="threadIndex">The index of the thread executing the remote call.</param>
            /// <param name="argProvider">A function that returns the arguments to pass to the remote call.</param>
            /// <returns>Void.</returns>
            /// <exception cref="System.ArgumentNullException">Thrown if the target, pipeServer, pipeName, p, or argProvider parameter is null.</exception>
            /// <exception cref="System.ArgumentException">Thrown if the target method or its declaring type, the process, or the argument provider type cannot be resolved.</exception>
            void RunProcess(
                Delegate target,
                NamedPipeServerStream pipeServer,
                string pipeName,
                Process p,
                int threadIndex,
                Func<int, IArgProvider> argProvider)
            {

                var args = argProvider(threadIndex).ToArray();


                if (Logger.InfoEnabled)
                {
                    Logger.Info($"{id} [Thread {threadIndex}] Executing ParallelRunner.{nameof(Run)}(pipeServer, {pipeName}, {string.Join(",", args)})");
                    Logger.Info($"{id} Executing ParallelRunner:PipeServer.WaitForConnection()");
                }
                //pipeServer.WaitForConnection();



                var callData = MpiRunner.GetRemoteCallData(target.Method, args);

                if (Logger.InfoEnabled)
                {
                    var debugJson = callData.DebugJson();
                    Logger.Info($"{id} Sending call data to {pipeName} {threadIndex}: {debugJson}");
                }

                using (var bw = new BinaryWriter(pipeServer, Encoding.UTF8, true))
                {
                    byte[] callDataBytes = callData.ToByteArray();
                    bw.Write(callDataBytes.Length);
                    bw.Write(callDataBytes);
                }

                FunctionInvoked?.Invoke(this, new FunctionInvokedEventArgs<TResult>(threadIndex, p.Id, pipeName, argProvider(threadIndex), callData));
            }




            /// <summary>
            /// Executes Process.Kill() on all processes and resets execution state.
            /// </summary>
            /// 
            public FunctionRunner<TResult> Reset()
            {
                Kill();
                Tasks.Clear();
                IsRunning = false;
                return this;
            }


            /// <summary>
            /// Executes Process.Kill() on all processes but leave execution state intact.
            /// </summary>
            public FunctionRunner<TResult> Kill()
            {
                procs.ForEach(p => p.Kill());
                return this;
            }

            /// <summary>
            /// Execute the parallel function on each processor using the configuration set building the function. This method returns before execution has completed.
            /// </summary>
            /// <returns>A function runner that will hold a list of results from each process once execution has finished.</returns>
            /// <exception cref="ArgumentException"></exception>
            public FunctionRunner<TResult> Run()
            {
                return RunProcesses(this.ArgProvider);
            }

            /// <summary>
            /// Internal method that handles execution of each process and monitoring for completion.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments to each process.</param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            protected internal FunctionRunner<TResult> RunProcesses(Func<int, IArgProvider> argProvider)
            {
                if (IsRunning)
                {
                    var errorMessage = "Parallel For is currently running. Wait for it to finish and call Reset, or call Kill(), before calling run again";

                    if (Logger.ErrorEnabled)
                    {
                        Logger.Error(errorMessage);
                    }

                    throw new Exception(errorMessage);
                }
                try
                {
                    Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
                }
                catch
                {
                    //Do nothing. Some build pipelines don't allow setting ProcessPriorityClass.RealTime
                }
                try
                {
                    Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.AboveNormal;
                }
                catch
                {
                    //Do nothing. Some build pipelines don't allow setting ProcessPriorityClass.RealTime
                }

                IsRunning = true;

                Tasks.Clear();


                var codeBase = this.GetType().Assembly.Location;
                var exeName = Path.GetFileNameWithoutExtension(codeBase);


                var start = Start;
                var end = End;
                var numThreads = end - start;
                Tasks = new List<Task>();
                var sw = Stopwatch.StartNew();
                if (LoggingEnabled)
                {
                    Logger.OutputStream = new StreamWriter($"DotMpi-Master.log", true);
                    Logger.EnableAll();
                    Logger.Info($"{id} Running {numThreads} processes.");
                }
                for (var i = start; i < end; i++)
                {
                    var threadIndex = i;

                    Results[threadIndex] = default;
                    SerializedResults[threadIndex] = new SerializableValue<TResult?>();

                    ValidateProcessCount(exeName);


                    var pipeIdentifier = Guid.NewGuid();
                    var pipeId = pipeIdentifier.ToString().Substring(0, 8);
                    var pipeName = $"{exeName}-{pipeId}";

                    var logArg = LoggingEnabled ? " log" : "";
                    string processArgs = $"{exeName}.dll{logArg} mpi {threadIndex} {pipeName}";
                    NamedPipeServerStream pipeServer = null!;
                    Process p = p = new Process()
                    {
                        StartInfo = new ProcessStartInfo("dotnet", processArgs)
                        {
                            //WorkingDirectory= Path.GetFullPath(".")
                        }
                    };

                    // must start process immediately or Kill will error out
                    p.Start();

                    if (LoggingEnabled)
                    {
                        Logger.Info($"{id} Starting Server[{threadIndex}] {pipeName}");
                    }
                    var serverTask = Task.Run(async () =>
                    {
                        try
                        {

                            var provider = argProvider(threadIndex);
                            if (LoggingEnabled)
                            {

                                var args = provider.ToArray();
                                Logger.Info($"{id} Executing {nameof(Run)}(pipeServer, {pipeName}, {threadIndex}, args: {string.Join(",", args)})");
                            }
                            pipeServer = new NamedPipeServerStream(pipeName);


                            await pipeServer.WaitForConnectionAsync();
                            Logger.Info($"{id} Connected Server[{threadIndex}] {pipeName}");
                            RunProcess(Delegate, pipeServer, pipeName, p, threadIndex, argProvider);
                            ReadProcessResult(threadIndex, p, pipeName, pipeServer, provider);
                            p.WaitForExit();
                        }
                        catch (Exception ex)
                        {
                            if (LoggingEnabled)
                                Logger.Error($"{id} Error executing mpi runner {threadIndex} on {pipeName} ", ex);
                            if (!p.HasExited)
                                p.Kill();
                            throw;
                        }

                    });

                    //p.Start();
                    procs.Add(p);


                    p.Exited += (sender, e) =>
                    {
                        if (!serverTask.IsCompleted)
                        {
                            //launchTask.Dispose();
                            if (Logger.ErrorEnabled)
                                Logger.Error($"{id} Task has been canceled because the process has exited unexpectedly.");
                        }
                    };
                    //launchTask.Wait();
                    Tasks.Add(serverTask);

                }

                var monitor = Task.Run(() =>
                {
                    var sw = Stopwatch.StartNew();
                    while (IsRunning)
                    {
                        System.Threading.Thread.Sleep(50);
                        var taskCount = Tasks.Where(x => x.IsCompleted == false).Count();
                        var procCount = procs.Where(x => x.HasExited == false).Count();
                        if (taskCount == 1 && procCount == 0)
                        {
                            //Reset();
                            IsRunning = false;
                        }

                    }
                });
                Tasks.Add(monitor);
                sw.Stop();
                if (LoggingEnabled)
                {
                    Logger.Info($"{id} Started {numThreads} processes in {sw.Elapsed}");
                }
                return this;
            }

            [ExcludeFromCodeCoverage]
            private void ValidateProcessCount(string processName)
            {
                var running = Process.GetProcessesByName(processName);
                //todo make max processes configurable.
                if (running != null && running.Length > 128)
                {
                    var errorMessage = $"Run {processName} launched too many times: Count {running.Length}";
                    Logger.Error(errorMessage);
                    throw new Exception(errorMessage);
                }

            }




            /// <summary>
            /// Waits for all process threads to complete. This method blocks until all processes have exited.
            /// </summary>
            /// <param name="timeout">The maximum amount of time to wait for all processes to complete. If null, the method waits indefinitely.</param>
            /// <returns>The same instance of <see cref="FunctionRunner{TResult}"/> on which the method was called.</returns>
            /// <remarks>The Wait method now takes an optional TimeSpan parameter called timeout that specifies the maximum amount of time to wait for all processes to complete. If timeout is null, the method waits indefinitely. The method first creates an array of tasks that represent the completion of each process, then it uses Task.WhenAny to wait for either all of the tasks to complete or for the timeout to elapse.
            /// If all of the tasks complete before the timeout elapses, the method simply returns the same instance of FunctionRunner<TResult> on which it was called.If the timeout elapses before all of the tasks complete, the method throws a TimeoutException.
            /// </remarks>
            public FunctionRunner<TResult> Wait(TimeSpan? timeout = null)
            {
                var task = Task.Run(() =>
                {
                    while (IsRunning)
                    {
                        System.Threading.Thread.Sleep(1);
                    }
                });
                if (timeout == null)
                {
                    task.Wait();
                    Logger.Instance.OutputStream.Dispose();
                }
                else
                {
                    var timeoutTask = Task.Delay(timeout.Value);
                    var completedTask = Task.WhenAny(task, timeoutTask).Result;
                    Logger.Instance.OutputStream.Dispose();
                    if (completedTask == timeoutTask)
                    {
                        Dispose();
                        throw new TimeoutException($"Wait operation timed out after {timeout}.");
                    }
                }

                return this;
            }



            /// <summary>
            /// Reads the results of each process thread.
            /// </summary>
            /// <param name="index"></param>
            /// <param name="p"></param>
            /// <param name="pipeName"></param>
            /// <param name="pipeServer"></param>
            internal void ReadProcessResult(int index, Process p, string pipeName, NamedPipeServerStream pipeServer, IArgProvider provider)
            {
                try
                {
                    byte[] byteData;
                    if (!pipeServer.IsConnected)
                    {
                        throw new Exception("$pipeServer was closed");
                    }
                    using (var reader = new BinaryReader(pipeServer))
                    {
                        int count = reader.ReadInt32();
                        byteData = reader.ReadBytes(count);
                    }
                    pipeServer.Close();

                    var json = System.Text.Encoding.UTF8.GetString(byteData);
                    var result = JsonConvert.DeserializeObject<SerializableValue<TResult?>>(json);
                    if (result is null)
                    {
                        throw new Exception($"Failed to deserialize result from json: {json}");
                    }
                    else
                    {
                        SerializedResults[index] = result;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                        var value = result.Result;
                        if (value is not null)
                            Results[index] = value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                        if (Logger.DebugEnabled)
                            Logger.Debug($"{id} Read result from client {index} {pipeName} - {json}");

                        FunctionResultReturned?.Invoke(this, new FunctionResultEventArgs<TResult>(index, p.Id, pipeName, provider, result));
                    }



                }
                catch (Exception ex)
                {
                    var errorMessage = $"{id} Error reading result from pipe[{index}] {pipeName} running on {p.Id}: {ex}";
                    if (Logger.ErrorEnabled)
                        Logger.Error(errorMessage);
                    throw;
                }

            }

            /// <summary>
            /// Performs clean up and shutsdown any lingering process threads.
            /// </summary>
            public void Dispose()
            {
                Reset();
            }

        }
    }
}

