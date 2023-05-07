using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Runtime.Versioning;

namespace DotMpi.MpiTests
{
    [TestClass()]
    public partial class ParallelFunctionBuilderTests
    {

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
        {;
            return @$"{message} from thread {threadIndex} on process {ProcessId} on cpu {Cpu}";
        }

        const int numThreads = 2;


        [TestMethod()]
        public void ForTest16()
        {
            //Assert.Fail();
            //var a = 1.ToString().PadLeft(2, '0')
        }

        [TestMethod()]
        public void ForTest17()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void ForTest18()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void ForTest19()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void ForTest20()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void ForTest21()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void ForTest22()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void ForTest23()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void ForTest24()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void ForTest25()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void ForTest26()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void ForTest27()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void ForTest28()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void ForTest29()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void ForTest30()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void ForTest31()
        {
            //Assert.Fail();
        }
    }
}