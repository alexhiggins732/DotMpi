using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.IO.Pipes;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Data;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Runtime.Versioning;

namespace DotMpi
{
    internal partial class MpiRunnerTest
    {
        static int getOne() => 1;
        public static void TestExecute()
        {

            var result = MpiRunner.Exec(getOne);
            if (result != getOne())
            {
                throw new Exception($"{nameof(TestExecute)} failed. Expected {getOne()} Actual: {result}");
            }
        }
        public static void TestHelloWorldExec(int numThreads)
        {
            Func<int, HelloWorldParallelResult> target = HelloWorld;
            for (var i = 0; i < numThreads; i++)
            {
                var result = MpiRunner.Exec(target, i);
            }
        }

        [SupportedOSPlatformGuard("windows")]  // The platform guard attributes used
        [SupportedOSPlatformGuard("linux")]
        private static readonly bool _isWindowsOrLinux = OperatingSystem.IsWindows() || OperatingSystem.IsLinux();

        public static int GetCpuId()
        {
            if (_isWindowsOrLinux)
            {
                var p = Process.GetCurrentProcess();
                int cpuNumber = 0;
                for (var cpuMask = ((int)p.ProcessorAffinity); cpuMask > 1; cpuNumber++, cpuMask >>= 1) ;
                return cpuNumber;
            }
            else
            {
                return -1;
            }
        }

        private static int? cpu;
        private static int Cpu => cpu.HasValue ? cpu.Value : (cpu = GetCpuId()).Value;
        private static Process CurrentProcess => Process.GetCurrentProcess();
        private static int ProcessId => CurrentProcess.Id;

        public static string MpiHelloWorld(int threadIndex, string message)
        {
         
            return @$"{message} from thread {threadIndex} on process {ProcessId} on cpu {Cpu}";
        }
          
        public static void HelloWorldTest(int numThreads)
        {
            Func<int, string, string> target = MpiHelloWorld;
            var timer = Stopwatch.StartNew();
            var runner = Mpi
                .ParallelFor(0, numThreads, target, i => new(i, "Hello World"))
                .Run()
                .Wait();

            for (var i = 0; i < numThreads; i++)
            {
                var result = runner.Results[i];
                Console.WriteLine($"[{DateTime.Now}] Result {i}: {result}");
            }

            Console.WriteLine($"[{DateTime.Now}] Completed {numThreads} process threads in {timer.Elapsed}");
            timer.Stop();
        }


        public static void TestHelloWorldParallel(int numThreads)
        {
            Func<int, HelloWorldParallelResult> target = HelloWorld;

            var timer = Stopwatch.StartNew();
            var para = Mpi.Parallel(numThreads);

            var runner = para.For(target).WithArgs(HelloWorldArgProvider);

            var controller = runner.WithArgs(HelloWorldArgProvider);

            controller = Mpi
                .ParallelFor(0, numThreads, target, HelloWorldArgProvider);

            //var controller = runner.Run((Mpi.ArgProvider)((i) => new object[] { HelloWorldArgProvider(i) }));

            controller.Wait();
            timer.Stop();
            for (var i = 0; i < numThreads; i++)
            {
                var result = controller.Results[i];
                Console.WriteLine($"[{DateTime.Now}] Result {i}: {result.Status}");
            }
            Console.WriteLine($"[{DateTime.Now}] Completed {numThreads} in {timer.Elapsed}");


        }

        public static int HelloWorldArgProvider(int threadIndex)
            => threadIndex;

        public static HelloWorldParallelResult HelloWorld(int threadIndex)
        {
            var p = Process.GetCurrentProcess();
            var id = p.Id;
            var result = new HelloWorldParallelResult(message: "Hello World", id: id, threadIndex);
            return result;
        }

        public class HelloWorldParallelResult
        {
            public int Id { get; set; }
            public string Message { get; set; }
            public int ThreadIndex { get; }
            public string Status => $"{Message} from thread {ThreadIndex} on process {Id}.";
            public HelloWorldParallelResult(string message, int id, int threadIndex)
            {
                this.Message = message;
                this.Id = id;
                ThreadIndex = threadIndex;
            }
        }


        public static int Add(int a, int b) => a + b;
        public static void TestAddParallel(int numThreads)
        {
            Func<int, int, int> target = Add;
            var timer = Stopwatch.StartNew();



            var runner = Mpi
                .Parallel(numThreads)
                .For(target, i => new(i, i + 1))
                .WithArgs(i => Mpi.ArgList.Create(i, i + 1))
                .WithArgs(0, 1)
                .WithArgs(i => new(i, i + 1))
                //.WithArgs(pv)
                .Run()
                .Wait();


            timer.Stop();

            Console.WriteLine($"[{DateTime.Now}] Completed {numThreads} in {timer.Elapsed}"); ;

            for (var i = 0; i < numThreads; i++)
            {
                var result = runner.Results[i];
                Console.WriteLine($"[{DateTime.Now}] Result {i}: {result}");
            }
            Console.WriteLine($"[{DateTime.Now}] Completed {numThreads} in {timer.Elapsed}");
        }

        public static void TestAddWithLambdaArgProvider(int numThreads)
        {
            Func<int, int, int> target = Add;
            var timer = Stopwatch.StartNew();
            var runner = Mpi
                .Parallel(numThreads)
                .For(target, i =>
                {
                    var arg0 = i;
                    var arg2 = i + 1;
                    return new(arg0, arg2);
                })
                .Run()
                .Wait();
            timer.Stop();

            Console.WriteLine($"[{DateTime.Now}] Completed {numThreads} in {timer.Elapsed}"); ;

            for (var i = 0; i < numThreads; i++)
            {
                var result = runner.Results[i];
                Console.WriteLine($"[{DateTime.Now}] Result {i}: {result}");
            }
            Console.WriteLine($"[{DateTime.Now}] Completed {numThreads} in {timer.Elapsed}");

        }

        public static void TestAddOneLine(int numThreads)
        {

            Func<int, int, int> target = Add;
            var timer = Stopwatch.StartNew();
            var runner = Mpi
                .ParallelFor(0, numThreads, target, i => new(i, i + 1))
                .Run()
                .Wait(); 

            timer.Stop();

            Console.WriteLine($"[{DateTime.Now}] Completed {numThreads} in {timer.Elapsed}"); ;

            for (var i = 0; i < numThreads; i++)
            {
                var result = runner.Results[i];
                Console.WriteLine($"[{DateTime.Now}] Result {i}: {result}");
            }
            Console.WriteLine($"[{DateTime.Now}] Completed {numThreads} in {timer.Elapsed}");

        }
    }

    public partial class Mpi
    {
        private static string pipeName = string.Empty;
        private static string id => $"[{pipeName}]";
        public static string PipeName { get => pipeName; set => MpiRunner.id = pipeName = value; }

        public partial class ParallelFunctionBuilder
        {

            //public int NumThreads { get; }

            /// <summary>
            /// The start index, inclusive.
            /// </summary>
            public int Start { get; }

            /// <summary>
            /// The end index, exclusive.
            /// </summary>
            public int End { get; }

            /// <summary>
            /// Multi processor interface parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunctionBuilder(int fromInclusive, int toExclusive)
            {
                this.Start = fromInclusive;
                this.End = toExclusive;
            }

            /// <summary>
            /// Multi processor interface parallel runner
            /// </summary>
            /// <param name="numThreads">The number of processor threads to create.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunctionBuilder(int numThreads)
                : this(0, numThreads) { }


            public ParallelFunction<TResult> For<TResult>(Func<TResult> func)
            {
                var runner = new ParallelFunction<TResult>(Start, End, func);
                return runner;
            }

            // additional generic overloads generated by ParallelRunner.tt template.


        }

        public interface IArgProvider
        {
            object[] GetArguments(int threadIndex);
        }



  

        /// <summary>
        /// A parallel function runner that coordinates execution on multiple processors.
        /// </summary>
        /// <typeparam name="TResult">The type of result returned by each process thread execution.</typeparam>
        public abstract class ParallelFunctionRunner<TResult>

        {
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
            public TResult[] Results = new TResult[] { };

            /// <summary>
            /// A list of task that monitor each process thread for completion.
            /// </summary>
            public List<Task> Tasks { get; private set; } = new();

            /// <summary>
            /// A list of processes for each process thread executed.
            /// </summary>
            private List<Process> procs = new();

            /// <summary>
            /// Delegate function to provide arguments to each process.
            /// </summary>
            protected Func<int, IArgListProvider> ArgProvider { get; set; } = null!;


            protected abstract void RunThread(NamedPipeServerStream pipeServer, string pipeName, int threadIndex, Func<int, IArgListProvider> argProvider);


            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunctionRunner(int fromInclusive, int toExclusive)
            {
                if (toExclusive <= fromInclusive)
                {
                    throw new ArgumentException("Start must less than end", nameof(toExclusive));
                }
                else if (fromInclusive < 0)
                {
                    throw new ArgumentException("Start must be greater than zero", nameof(fromInclusive));
                }
                else if (toExclusive < 0)
                {
                    throw new ArgumentException("End must be greater than zero", nameof(toExclusive));
                }
                Start = fromInclusive;
                End = toExclusive;
            }


            /// <summary>
            /// Executes Process.Kill() on all processes and resets execution state.
            /// </summary>
            /// 
            public void Reset()
            {
                procs?.ForEach(p => p.Kill());
                Tasks?.Clear();
                // TODO: Decide if results should be cleared.
                IsRunning = false;
            }


            /// <summary>
            /// Executes Process.Kill() on all processes and resets execution state.
            /// </summary>
            public void Kill()
            {
                procs?.ForEach(p => p.Kill());

            }

            /// <summary>
            /// Execute the parallel function on each processor using the configuration set building the function. This method returns before execution has completed.
            /// </summary>
            /// <returns>A function runner that will hold a list of results from each process once execution has finished.</returns>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunctionRunner<TResult> Run()
            {
                if (ArgProvider is null)
                {
                    throw new ArgumentException("Argument provider not set", nameof(ArgProvider));
                }
                return Run(this.ArgProvider);
            }

            /// <summary>
            /// Internal method that handles execution of each process and monitoring for completion.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments to each process.</param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            protected internal ParallelFunctionRunner<TResult> Run(Func<int, IArgListProvider> argProvider)
            {
                if (IsRunning)
                {
                    var errorMessage = "Parallel For is currently running. Wait for it to finish and call Reset, or call Kill(), before calling run again";
                    Logger.Error(errorMessage);
                    throw new Exception(errorMessage);
                }
                IsRunning = true;

                Tasks.Clear();


                var codeBase = this.GetType().Assembly.Location;
                var exeName = Path.GetFileNameWithoutExtension(codeBase);


                var start = Start;
                var end = End;
                var numThreads = end - start;
                Tasks = new List<Task>();
                Results = new TResult[numThreads];
                for (var i = start; i < end; i++)
                {
                    var threadIndex = i;

                    var running = Process.GetProcessesByName(exeName);
                    if (running != null && running.Length > 128)
                    {
                        var errorMessage = $"Run {exeName} launched too many times: Count {running.Length}";
                        Logger.Error(errorMessage);
                        throw new Exception(errorMessage);
                    }


                    var pipeIdentifier = Guid.NewGuid();
                    var pipeId = pipeIdentifier.ToString().Substring(0, 8);
                    var pipeName = $"{exeName}-{pipeId}";


                    var pipeServer = new NamedPipeServerStream(pipeName);
                    string processArgs = $"{exeName}.dll mpi {threadIndex} {pipeName}";
              
                    var p = new Process()
                    {
                        StartInfo = new ProcessStartInfo("dotnet", processArgs)
                    };



                    p.Start();
                    procs.Add(p);

                    var launchTask = Task.Run(() =>
                    {

                        try
                        {
                            if (!p.HasExited)
                            {
                                var args = argProvider(threadIndex).ToArray();
                                if (Logger.InfoEnabled)
                                    Logger.Info($"[{DateTime.Now}] {id} Executing {nameof(Run)}(pipeServer, {pipeName}, {threadIndex}, args: {string.Join(",", args)})");

                                RunThread(pipeServer, pipeName, threadIndex, argProvider);
                                ReadResults(threadIndex, p, pipeName, pipeServer);
                                p.WaitForExit();
                            }

                        }
                        catch (Exception ex)
                        {
                            if (Logger.ErrorEnabled)
                                Logger.Error($"[{DateTime.Now}] {id} Error executing mpi runner {threadIndex} on {pipeName} ", ex);
                            if (!p.HasExited)
                                p.Kill();
                        }
                        return Task.CompletedTask;
                    });

                    p.Exited += (sender, e) =>
                    {
                        if (!launchTask.IsCompleted)
                        {
                            //launchTask.Dispose();
                            if (Logger.InfoEnabled)
                                Logger.Info($"[{DateTime.Now}] {id} Task has been canceled because the process has exited unexpectedly.");
                        }
                    };

                    Tasks.Add(launchTask);

                }

                var monitor = Task.Run(() =>
                {
                    var sw = Stopwatch.StartNew();
                    while (Tasks.Count > 0)
                    {
                        if (sw.ElapsedMilliseconds > 10000)
                        {
                            if (Logger.DebugEnabled)
                                Logger.Debug($"[{DateTime.Now}] Waiting for {Tasks.Count} to complete");
                            sw.Restart();
                        }

                        System.Threading.Thread.Sleep(50);
                        Tasks = Tasks.Where(x => x.IsCompleted == false).ToList();
                        procs = procs.Where(x => x.HasExited == false).ToList();
                        if (Tasks.Count == 1 && procs.Count == 0)
                        {
                            Reset();
                            return;
                        }

                    }
                });
                Tasks.Add(monitor);

                return this;
            }


            /// <summary>
            /// Waits for all process threads to complete. This method blocks until all processes have exited.
            /// TODO: ADD timeout and/or ability to kill without blocking forever.
            /// </summary>
            /// <returns></returns>
            public ParallelFunctionRunner<TResult> Wait()
            {
                while (true)
                {
                    while (IsRunning)
                    {
                        System.Threading.Thread.Sleep(1);
                    }
                    break;
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
            private void ReadResults(int index, Process p, string pipeName, NamedPipeServerStream pipeServer)
            {
                try
                {
                    byte[] byteData;
                    using (var reader = new BinaryReader(pipeServer))
                    {
                        int count = reader.ReadInt32();
                        byteData = reader.ReadBytes(count);
                    }
                    pipeServer.Close();

                    var json = System.Text.Encoding.UTF8.GetString(byteData);
                    var result = JsonConvert.DeserializeObject<SerializableValue<TResult>>(json);
                    if (result is null)
                    {
                        var errorMessage = $"Failed to deserialize result from json: {json}";
                        Logger.Error(errorMessage);
                        throw new Exception(errorMessage);
                    }
#pragma warning disable CS8601 // Possible null reference assignment.
                    Results[index] = result.TValue;
#pragma warning restore CS8601 // Possible null reference assignment.

                    if (Logger.DebugEnabled)
                        Logger.Debug($"[{DateTime.Now}] {id} Read result from client {index} {pipeName} - {json}");
                }
                catch (Exception ex)
                {
                    var errorMessage = $"[{DateTime.Now}] {id} Error reading result from pipe[{index}] {pipeName} running on {p.Id}: {ex}";
                    if (Logger.ErrorEnabled)
                        Logger.Error(errorMessage);
                }

            }

            /// <summary>
            /// Performs clean up and shutsdown any linger process threads.
            /// </summary>
            public void Dispose()
            {
                Kill();

            }

        }


        public interface IParallelFunc
        {
            void Run(NamedPipeServerStream pipeServer, string pipeName, int threadIndex, params object[] args);
        }


        public class ParallelFunction<TResult> : ParallelFunctionRunner<TResult>
        {
            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(int fromInclusive, int toExclusive, Func<TResult> target)
                : base(fromInclusive, toExclusive)
            {
                Target = target;
            }


            public Func<TResult> Target { get; }


            protected override void RunThread(NamedPipeServerStream pipeServer, string pipeName, int threadIndex, Func<int, IArgListProvider> argProvider)
            {
                var args = argProvider(threadIndex).ToArray();

                Console.WriteLine($"[{DateTime.Now}] {id} Executing {nameof(ParallelFunctionBuilder)}.{nameof(Run)}: {string.Join(",", new object[] { pipeName, threadIndex, "args" })}");

                var callData = MpiRunner.GetRemoteCallData(Target.Method, args);
                if (Logger.InfoEnabled)
                {
                    var debugJson = callData.DebugJson();
                    Logger.Info($"[{DateTime.Now}] {id} Sending call data to {pipeName} {threadIndex}: {debugJson}");
                }

                if (args != null && args.Length > 0 && (int)args[0] != threadIndex)
                {
                    throw new Exception("Invalid arg for {threadIndex}: {args[0]}");
                }

                using (var bw = new BinaryWriter(pipeServer, Encoding.UTF8, true))
                {
                    byte[] callDataBytes = callData.ToByteArray();
                    bw.Write(callDataBytes.Length);
                    bw.Write(callDataBytes);
                }

                // will be executed remote on the client.
                //ExecuteAndSend(pipeName);
            }
        }

        /// <summary>
        /// Returns a parallel function builder for the specified number of threads.
        /// </summary>
        /// <param name="numThreads">The number of parallel process threads to launch</param>
        /// <returns></returns>
        public static ParallelFunctionBuilder Parallel(int numThreads) => Parallel(0, numThreads);


        /// <summary>
        /// Returns a parallel function builder for the specified number of threads.
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <returns></returns>
        public static ParallelFunctionBuilder Parallel(int start, int end) => new ParallelFunctionBuilder(start, end);



        //special case for only one generic argument
        public static ParallelFunction<T0, TResult>
            ParallelFor<T0, TResult>(
                int start,
                int end,
                Func<T0, TResult> target,
                Func<int, T0> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(start, end)
                .For(target).WithArgs(argProvider);
            return builder;
        }

        internal static void RunThread(int threadIndex, string pipeName)
        {
            if (Logger.InfoEnabled)
                Logger.Info($"[{DateTime.Now}] {id} Executing {nameof(RunThread)}: {string.Join(",", new object[] { threadIndex, pipeName })}");
            using NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", pipeName);
            try
            {
                if (Logger.DebugEnabled)
                    Logger.Debug($"[{DateTime.Now}] {id} Executing {nameof(RunThread)}:{nameof(pipeClient)}.{nameof(pipeClient.Connect)}({pipeName})");
                pipeClient.Connect();

                if (Logger.DebugEnabled)
                    Logger.Debug($"[{DateTime.Now}] {id} Executed {nameof(RunThread)}:{nameof(pipeClient)}.{nameof(pipeClient.Connect)}({pipeName})");

                using var reader = new BinaryReader(pipeClient);
                using (var writer = new BinaryWriter(pipeClient))
                    try
                    {
                        MpiRunner.HandleRemoteCall(writer, reader, pipeName, threadIndex);
                        //    Console.WriteLine($"[{DateTime.Now}] {id} Reading Remote Data Length {nameof(RunThread)}:{nameof(reader)}.{nameof(reader.ReadInt32)}()");
                        //    var len = reader.ReadInt32();

                        //    Console.WriteLine($"[{DateTime.Now}] {id} Reading Remote Data {nameof(RunThread)}:{nameof(reader)}.{nameof(reader.ReadBytes)}({len})");
                        //    var bytes = reader.ReadBytes(len);

                        //    Console.WriteLine($"[{DateTime.Now}] {id} Read Remote Data {nameof(RunThread)}:{nameof(reader)}.{nameof(reader.ReadBytes)}({len})");

                        //    var json = Encoding.UTF8.GetString(bytes);
                        //    Console.WriteLine($"[{DateTime.Now}] {id} Read Json {nameof(RunThread)}:{nameof(Encoding.UTF8.GetString)} {json}");


                        //    Console.WriteLine($"[{DateTime.Now}] {id} Executing {nameof(MpiRunner)}:{nameof(MpiRunner.HandleRemoteCall)}({json})");

                        //    MpiRunner.HandleRemoteCall(writer, reader, json);


                        //    Console.WriteLine($"[{DateTime.Now}] {id} Serializing Result {nameof(MpiRunner)}:{nameof(SerializableValue)}");
                        //    var serializeableResult = new SerializableValue(objectResult);

                        //    var resultJson = serializeableResult.ToJson();


                        //    Console.WriteLine($"[{DateTime.Now}] {id} Serializing Result to {nameof(MpiRunner)}:{nameof(resultJson)} = {resultJson}");
                        //    var resultData = Encoding.UTF8.GetBytes(resultJson);

                        //    Console.WriteLine($"[{DateTime.Now}] {id} Writing result {nameof(MpiRunner)}:{nameof(writer)}.{nameof(writer.Write)}({resultData.Length})");
                        //    writer.Write(resultData.Length);
                        //    writer.Write(resultData);
                        //    Console.WriteLine($"[{DateTime.Now}] {id} Wrote result {nameof(MpiRunner)}:{nameof(writer)}.{nameof(writer.Write)}({resultData.Length})");

                    }

                    catch (Exception ex)
                    {
                        var errorMessage = $"[{DateTime.Now}] [{pipeName}] Error running thread {threadIndex}: {ex}";
                        if (Logger.ErrorEnabled)
                            Logger.Error(errorMessage);

                        if (pipeClient.IsConnected)
                        {
                            var serializeableResult = new SerializableValue(errorMessage);
                            var resultJson = serializeableResult.ToJson();
                            var resultData = Encoding.UTF8.GetBytes(resultJson);
                            writer.Write(resultData.Length);
                            writer.Write(resultData);
                        }
                    }
            }
            catch (Exception ex)
            {
                var errorMessage = $"[{DateTime.Now}] [{pipeName}] Error running thread {threadIndex}: {ex}";
                if (Logger.ErrorEnabled)
                    Logger.Error(errorMessage);

            }
            if (Logger.InfoEnabled)
                Logger.Info($"[{DateTime.Now}] {id} Completed {nameof(RunThread)}: {string.Join(",", new object[] { threadIndex, pipeName })}");

        }
    }

    internal partial class MpiRunner
    {
        private static string _id = "unknown";
        public static string id { get => $"[{_id}]"; set => _id = value; }

        public static RemoteCallData GetRemoteCallData(MethodInfo method, params object[] args)
        {
            SerializableMethodInfo methodInfo = null!;
            if (method.IsStatic == false)
            {
                var body = method.GetMethodBody();
                if (body is null)
                {
                    throw new Exception("Could not read il body from method");
                }
                var ilBody = body.GetILAsByteArray();
                if (ilBody is not null && ilBody.Length > 5 && (ilBody[0] == 3) && (ilBody[1] == 40))
                {
                    var targetMetaDataTokenBytes = ilBody.Skip(2).Take(4).ToArray();
                    var metaDataToken = BitConverter.ToInt32(targetMetaDataTokenBytes);

                    var methodBase = Assembly.GetExecutingAssembly().ManifestModule.ResolveMethod(metaDataToken);
                    if (methodBase != null)
                    {
                        methodInfo = new SerializableMethodInfo(methodBase);
                    }
                }
                else
                {
                    throw new Exception("Cannot call non static method remotely");
                }
            }

            var argInfo = GetArgInfos(args);
            var returnInfo = new SerializableTypeInfo(method.ReturnType);
            methodInfo ??= new SerializableMethodInfo(method);
            var remoteCallData = new RemoteCallData(methodInfo, returnInfo, argInfo);
            return remoteCallData;
        }



        public static TResult Exec<TResult>(MethodInfo method, params object[] args)
        {
            var callData = GetRemoteCallData(method, args);
            var result = ExecuteRemoteCall<TResult>(callData);
            return result;
        }

        public static TResult
            Exec<TResult>(Func<TResult> fn)
            => Exec<TResult>(fn.Method);


        public static SerializableValue[] GetArgInfos(params object[] args)
        {
            if (args is null || args.Length == 0) return new SerializableValue[] { };
            for (var i = 0; i < args.Length; i++)
            {
                if (args[i] is null)
                    throw new ArgumentNullException($"args{i}");
            }
            return args.Select(x => GetArgInfo(x)).ToArray();
        }


        public static SerializableValue GetArgInfo<T>(T value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            var argInfo = new SerializableValue(value);
            return argInfo;
        }




        private static TResult ExecuteRemoteCall<TResult>(RemoteCallData callData)
        {
            var json = JsonConvert.SerializeObject(callData);
            var result = ExecuteRemoteCall<TResult>(json);
            return result;
        }

        private static TResult ExecuteRemoteCall<TResult>(string json)
        {

            var resultObject = HandleRemoteCall(json);
            var result = (TResult)resultObject;
            return result;
        }

        //Clients read json from IPC stream and pass it to this method to deserialize the method parameters, execute it, and return a result
        public static object HandleRemoteCall(string json)
        {
            var callData = JsonConvert.DeserializeObject<RemoteCallData>(json);

            if (callData is null)
            {
                throw new Exception($"Failed to deserialize Remote call data from json: {json}");
            }
            return Execute(callData);

        }

        private static ConcurrentDictionary<string, Assembly> assemblyRefs = new();

        public static object Execute(RemoteCallData callData)
        {
            var assemblyName = callData.MethodInfo.AssemblyName.Split(",")[0];
            Assembly asm = assemblyRefs.GetOrAdd(assemblyName, x =>
            {
                if (File.Exists($"{assemblyName}.dll"))
                {
                    var fullPath = Path.GetFullPath($"{assemblyName}.dll");
                    return Assembly.LoadFile(fullPath);
                }
                else
                {
                    return Assembly.Load(callData.MethodInfo.AssemblyName);
                }
            });


            var m = asm.ManifestModule.ResolveMethod(callData.MethodInfo.MetaDataToken);
            if (m == null)
                throw new Exception($"Failed to resolve method for MetaDataToken: {callData.MethodInfo.MetaDataToken}");
            var args = callData.ArgInfo.Select(x => x.Value).ToArray();
            var t = m.DeclaringType;


            var result = m.Invoke(null, args);

            if (Logger.InfoEnabled)
            {
                var resultJson = JsonConvert.SerializeObject(result);
                Logger.Info($"[{DateTime.Now}] {id} {m.Name}({string.Join(",", args)}) returned {resultJson}");
            }
#pragma warning disable CS8603 // Possible null reference return.
            return result;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public static void HandleRemoteCall(BinaryWriter writer, BinaryReader reader, string pipe, int threadIndex)
        {
            var length = reader.ReadInt32();
            var bytes = reader.ReadBytes(length);
            var json = Encoding.UTF8.GetString(bytes);

            if (Logger.InfoEnabled)
            {
                var callData = JsonConvert.DeserializeObject<RemoteCallData>(json);
                if (callData is null)
                {
                    throw new Exception($"Failed to deserialize call data: {json}");
                }
                var debugJson = callData.DebugJson();
                Logger.Info($"[{DateTime.Now}] {id} [{pipe}] [Thread {threadIndex}] call data: {debugJson}");
            }



            var objectResult = HandleRemoteCall(json);

            var serializeableResult = new SerializableValue(objectResult);
            var resultData = serializeableResult.ToByteArray();

            writer.Write(resultData.Length);
            writer.Write(resultData);
        }



    }
}
