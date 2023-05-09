/*
 Copyright (c) 2023 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 
 
 Source code for this software can be found at https://github.com/alexhiggins732/DotMpi
 
 This software is licensce under GNU General Public License version 3 as described in the LICENSE
 file at https://github.com/alexhiggins732/DotMpi/LICENSE
 
 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Versioning;

namespace DotMpi.MpiTests
{
    public partial class MpiTests
    {
        // For code coverage do not short circuit with || operator. Use | to evaluate both.
        [SupportedOSPlatformGuard("windows")]  // The platform guard attributes used
        [SupportedOSPlatformGuard("linux")]
        private static readonly bool _isWindowsOrLinux = OperatingSystem.IsLinux() | OperatingSystem.IsWindows();

        [ExcludeFromCodeCoverage]
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
        [ExcludeFromCodeCoverage]
        private static int Cpu => cpu.HasValue ? cpu.Value : (cpu = GetCpuId()).Value;
        private static Process CurrentProcess => Process.GetCurrentProcess();
        private static int ProcessId => CurrentProcess.Id;

        const int numThreads = 2;

        [TestClass()]
        public partial class ParallelFunctionBuilderTests
        {

            public ParallelFunctionBuilderTests()
            {
                Logger.Instance.InfoEnabled = true;


            }


            public static string MpiHelloWorld1(int threadIndex, string message)
            {
                ;
                return @$"{message} from thread {threadIndex} on process {ProcessId} on cpu {Cpu}";
            }


            [TestMethod]
            public void TestIsSupported()
            {
                Assert.IsTrue(_isWindowsOrLinux, "Only windows and linux support setting CPU affinity. Mileage may vary on other OSes such as IOS");
            }

            [TestMethod]
            public void MpiHelloWorld()
            {
                Func<int, string, string> target = MpiHelloWorld1;
                var fn = Mpi.ParallelFor(1, target, i => new(i, "Hello World"));
                var result = fn.Run().Wait();
                Assert.IsTrue(result.Results.Single().StartsWith("Hello World"));
            }

            [TestMethod]
            public void MpiHelloWorldFailsWhenStartNotGreaterThanEnd()
            {
                Func<int, string, string> target = MpiHelloWorld1;

                var runner = Mpi.Parallel(0, 0);
                Assert.ThrowsException<ArgumentException>(() => runner.For(target).Build());
            }

            [TestMethod]
            public void MpiHelloWorldFailsWhenStartNegative()
            {
                Func<int, string, string> target = MpiHelloWorld1;

                var runner = Mpi.Parallel(-1, 1);
                Assert.ThrowsException<ArgumentException>(() => runner.For(target).Build());
            }

            [TestMethod]
            public void MpiHelloWorldFailsWhenEndNegative()
            {
                Func<int, string, string> target = MpiHelloWorld1;

                var runner = Mpi.Parallel(-2, -1);
                Assert.ThrowsException<ArgumentException>(() => runner.For(target).Build());
            }
        }
    }
}