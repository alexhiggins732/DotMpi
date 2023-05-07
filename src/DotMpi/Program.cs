using System.Diagnostics;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace DotMpi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0) goto InvalidArguments;
            pipeName = $"Process-{Process.GetCurrentProcess().Id}";
            Console.WriteLine($"[{DateTime.Now}] {id} Running {string.Join(",", args)}");
            if (args.Length == 1 && args[0] == "kill")
            {
                var currentProcess = Process.GetCurrentProcess();


                var procs = Process
                    .GetProcessesByName(currentProcess.ProcessName)
                    .Where(x => x.Id != currentProcess.Id)
                    .ToList();
                procs.ForEach(p => p.Kill());

            }
            if (args.Length == 1 && args[0] == "launch")
            {
                pipeName = "Master";
                Console.WriteLine($"[{DateTime.Now}] {id} Calling {nameof(LaunchProcesses)}");
                LaunchProcesses();
            }
            else if (args[0] == "test" && args.Length >= 2)
            {
                var command = (args[1] ?? "").ToLower();
                int numThreads = 1;
                Mpi.PipeName = "Master";
                if (args.Length > 2)
                {
                    if (int.TryParse(args[2], out int parsesThreads))
                    {
                        numThreads = parsesThreads;
                    }
                    else
                    {
                        goto InvalidArguments;
                    }
                }
                switch (command)
                {
                    case "mpihelloworld":
                        MpiRunnerTest.HelloWorldTest(numThreads);
                        return;
                    case "helloworld":
                        MpiRunnerTest.TestHelloWorldParallel(numThreads);
                        return;
                    case "add":
                        MpiRunnerTest.TestAddParallel(numThreads);
                        return;
                    case "addlambda":
                        MpiRunnerTest.TestAddWithLambdaArgProvider(numThreads);
                        return;
                    case "addonline":
                        MpiRunnerTest.TestAddOneLine(numThreads);
                        return;
                }
            }
            else if (args[0] == "mpi" && args.Length == 3)
            {

                if (
                     int.TryParse(args[1], out var clientIndex)
                    )
                {
                    pipeName = args[2];
                    Console.WriteLine($"[{DateTime.Now}] {id} Launching mpi runner: {string.Join(",", args)}");
                    SetProcessor(clientIndex);
                    Mpi.PipeName = pipeName;
                    Mpi.RunThread(clientIndex, pipeName);
                    return;
                }
                else
                {
                    Console.WriteLine($"[{DateTime.Now}] {id} Failed to launch mpi runner: {string.Join(",", args)}");
                    goto InvalidArguments;
                }

            }
            else if (args.Length == 5)
            {
                if (
                    int.TryParse(args[1], out var clientIndex)
                    && int.TryParse(args[1], out var startIndex)
                    && int.TryParse(args[2], out var endIndex)
                    && int.TryParse(args[3], out var sieveSize)
                    )
                {
                    pipeName = args[4];
                    SetProcessor(clientIndex);

                    Console.WriteLine($"[{DateTime.Now}] {id} Running client {string.Join(" ", args)}");
                    LaunchSieve(startIndex, endIndex, sieveSize, pipeName);
                    Console.WriteLine($"[{DateTime.Now}] {id} Completed Sieve");
                }
                else
                {
                    goto InvalidArguments;
                }
            }
            else
            {

            }

        InvalidArguments:
            Console.WriteLine($"[{DateTime.Now}] {id} Invalid arguments {string.Join(", ", args)}");

        }

        [SupportedOSPlatformGuard("windows")]  // The platform guard attributes used
        [SupportedOSPlatformGuard("linux")]
        private static readonly bool _isWindowsOrLinux = OperatingSystem.IsWindows() || OperatingSystem.IsLinux();

        private static void SetProcessor(int clientIndex)
        {
            int processorAffinity = clientIndex % Environment.ProcessorCount;
            var affinityMask = 1 << processorAffinity;
            var p = Process.GetCurrentProcess();


            p.PriorityClass = ProcessPriorityClass.BelowNormal;
            if (_isWindowsOrLinux )
            {
                Console.WriteLine($"[{DateTime.Now}] {id} Setting Processor affinity to {affinityMask} for process {p.Id}");
                p.ProcessorAffinity = (IntPtr)(affinityMask);
            }
            else
            {
                Console.WriteLine($"[{DateTime.Now}] {id} Setting Processor affinity nonly supported on Windows and Linux");
            }
         
        }

        private static string pipeName = string.Empty;
        private static string id => $"[{pipeName}]";
        private static void LaunchSieve(int startIndex, int endIndex, int sieveSize, string pipeName)
        {
            var result = Enumerable.Repeat(endIndex, sieveSize).ToArray();
            PrimeSieve.Seive(startIndex, endIndex, result);
            //TODO: share result with main process.
            Console.WriteLine($"[{DateTime.Now}] {id} Calling WriteResultsToPipe for {result.Length} primes.");
            WriteResultsToPipe(pipeName, result);
            Console.WriteLine($"[{DateTime.Now}] {id} Wrote results to pipe: {pipeName}");
        }



        private static void LaunchProcesses()
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
    }

    internal class PrimeSieve
    {
        internal static void Seive(int startIndex, int endIndex, int[] result)
        {
            //throw new NotImplementedException();
        }
    }
}