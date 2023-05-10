/*
 Copyright (c) 2023 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 
 
 Source code for this software can be found at https://github.com/alexhiggins732/DotMpi
 
 This software is licensce under GNU General Public License version 3 as described in the LICENSE
 file at https://github.com/alexhiggins732/DotMpi/LICENSE
 
 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO.Pipes;
using System.Runtime.Versioning;

namespace DotMpi
{
    [ExcludeFromCodeCoverage]
    internal class MpiRunnerTest
    {
        private static string pipeName = string.Empty;
        private static string id => $"[{pipeName}]";
        public static string PipeName { get => pipeName; set => MpiRunner.id = pipeName = value; }
        static Logger Logger = Logger.Instance;

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
            Mpi.ParallelFor(0, numThreads, target, i => i);

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

            var func = runner.WithArgs(HelloWorldArgProvider);

            var controller = Mpi
                .ParallelFor(0, numThreads, target, HelloWorldArgProvider)
                .Run();

            //var controller = runner.Run((Mpi.ArgProvider)((i) => new object[] { HelloWorldArgProvider(i) }));

            controller.Wait();
            timer.Stop();
            for (var i = 0; i < numThreads; i++)
            {
                var result = controller.Results[i];
                if (result != null)
                    Console.WriteLine($"[{DateTime.Now}] Result {i}: {result.Status}");
                else
                    Console.WriteLine($"[{DateTime.Now}] Result {i}: [null]");
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

        public static void LaunchProcesses()
        {
            // Define the size of the sieve and the number of processes to launch

            var runWatch = Stopwatch.StartNew();
            int numProcesses = 1;
            int sieveSize = numProcesses * 1000000;

            // Calculate the size of each sub-sieve
            int subSieveSize = sieveSize / numProcesses;

            // Create an array to hold the results from each process
            int[][] processResults = new int[numProcesses][];

            var exeName = Process.GetCurrentProcess().ProcessName;
            var exeFileName = $"{exeName}.exe";
            // Launch each sub-process

            var processes = new List<Process>();
            var monitors = new List<Task>();
            for (int i = 0; i < numProcesses; i++)
            {
                // Calculate the starting and ending indices for this sub-sieve
                int startIndex = i * subSieveSize;
                int endIndex = (i + 1) * subSieveSize - 1;
                int clientIndex = i;
                var pipeId = Guid.NewGuid().ToString().Substring(0, 8);
                var pipeName = $"{exeName}-{pipeId}";
                NamedPipeServerStream pipeServer = new NamedPipeServerStream(pipeName);


                // Build the command line arguments for this sub-process
                string processArgs = $"{clientIndex} {startIndex} {endIndex} {sieveSize} {pipeName}";

                // Start the sub-process

                Console.WriteLine($"[{DateTime.Now}] {id} Launching client {processArgs}");

                Process subProcess = new Process();
                subProcess.StartInfo.FileName = exeFileName;
                subProcess.StartInfo.Arguments = processArgs;
                subProcess.Start();

                processes.Add(subProcess);
                // Wait for the sub-process to complete and capture the results

                var monitorTask = Task.Run(() =>
                {
                    pipeServer.WaitForConnection();
                    Console.WriteLine($"[{DateTime.Now}] {id} Client connected {pipeName}");

                    ReadResultsFromSubProcess(processResults, clientIndex, subProcess, pipeName, pipeServer);
                    subProcess.WaitForExit();
                });
                monitors.Add(monitorTask);
            }

            Console.WriteLine($"[{DateTime.Now}] {id} Launched {numProcesses} processes");

            var sw = Stopwatch.StartNew();
            while (monitors.Count > 0)
            {
                if (sw.ElapsedMilliseconds > 10000)
                {
                    Console.WriteLine($"[{DateTime.Now}] {id} Waiting for {monitors.Count} to complete");
                    sw.Restart();
                }

                System.Threading.Thread.Sleep(100);
                monitors = monitors.Where(x => x.IsCompleted == false).ToList();
            }


            // Combine the results from all sub-processes
            int[] combinedResults = CombineResults(processResults);

            runWatch.Stop();

            Console.WriteLine($"[{DateTime.Now}] {id} Processed {numProcesses} in {runWatch.Elapsed}");
            bool printResults = bool.Parse(bool.FalseString);
            if (printResults)
            {
                Console.WriteLine($"[{DateTime.Now}] {id} Results: ");
                foreach (var prime in combinedResults)
                {
                    Console.Write($"{prime} ");
                }

            }

            //// Wait for user input before exiting
            //Console.WriteLine($"[{DateTime.Now}] {id} Press any key to exit...");
            //Console.ReadKey();
        }



        private static void WriteResultsToPipe(string pipeName, int[] result)
        {
            var bytes = new byte[result.Length << 2];
            Buffer.BlockCopy(result, 0, bytes, 0, bytes.Length);
            Console.WriteLine($"[{DateTime.Now}] {id} Copied {result.Length} primes to byte array.");
            using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", pipeName))
            {
                Console.WriteLine($"[{DateTime.Now}] {id} Connecting to pipe {result.Length}.");
                pipeClient.Connect();

                Console.WriteLine($"[{DateTime.Now}] {id} Writing {result.Length} primes to pipe: Buffer {pipeClient.OutBufferSize}");


                using (var bw = new BinaryWriter(pipeClient))
                {
                    //Console.WriteLine($"[{DateTime.Now}] {id} Writing Length {result.Length} to pipe.");
                    bw.Write(result.Length);
                    bw.Write(bytes);
                    //Console.WriteLine($"[{DateTime.Now}] {id} Sent length of {result.Length} to pipe.");
                    //br.Write(bytes);
                    //Console.WriteLine($"[{DateTime.Now}] {id} Send {bytes.Length} bytes");
                    bw.Flush();
                    //pipeClient.WaitForPipeDrain();
                }

                // pipeClient.Close();
                Console.WriteLine($"[{DateTime.Now}] {id} Finished writing {result.Length - 1} primes to pipe");
            }

        }


        static void ReadResultsFromSubProcess(int[][] processResults, int index, Process subProcess, string pipeName, NamedPipeServerStream pipeServer)
        {
            // TODO: Implement this method to read the results from a sub-process
            //       and return them as an int array.

            try
            {
                using (var reader = new BinaryReader(pipeServer))
                {
                    int count = reader.ReadInt32();
                    Console.WriteLine($"[{DateTime.Now}] {id} Read prime count {count} from client {pipeName}");
                    var result = new int[count];

                    if (count > 0)
                    {
                        var buffer = reader.ReadBytes(count << 2);
                        Buffer.BlockCopy(buffer, 0, result, 0, buffer.Length);
                    }
                    processResults[index] = result;

                }
                pipeServer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now}] {id} Error reading primes from pipe  {pipeName}: {ex}");
            }

        }

        static int[] CombineResults(int[][] processResults)
        {
            // TODO: Implement this method to combine the results from all
            //       sub-processes into a single int array.
            //throw new NotImplementedException();
            return processResults.SelectMany(x => x).ToArray();
        }

        public static void LaunchSieve(int startIndex, int endIndex, int sieveSize, string pipeName)
        {
            var result = Enumerable.Repeat(endIndex, sieveSize).ToArray();
            PrimeSieve.Seive(startIndex, endIndex, result);
            //TODO: share result with main process.
            Console.WriteLine($"[{DateTime.Now}] {id} Calling WriteResultsToPipe for {result.Length} primes.");
            WriteResultsToPipe(pipeName, result);
            Console.WriteLine($"[{DateTime.Now}] {id} Wrote results to pipe: {pipeName}");
        }

        internal class PrimeSieve
        {
            internal static void Seive(int startIndex, int endIndex, int[] result)
            {
                //throw new NotImplementedException();
            }
        }
    }
}

