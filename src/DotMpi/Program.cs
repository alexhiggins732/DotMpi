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
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
[assembly: InternalsVisibleTo("DotMpiTests")]
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
                MpiRunnerTest.PipeName = "Master";
                Console.WriteLine($"[{DateTime.Now}] {id} Calling {nameof(MpiRunnerTest.LaunchProcesses)}");
                MpiRunnerTest.LaunchProcesses();
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
                    Mpi.FunctionExecutor.RunThread(clientIndex, pipeName);
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
                    MpiRunnerTest.LaunchSieve(startIndex, endIndex, sieveSize, pipeName);
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
            if (_isWindowsOrLinux)
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

    }
}




  

