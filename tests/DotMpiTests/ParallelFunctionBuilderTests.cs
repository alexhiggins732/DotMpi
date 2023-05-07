using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace DotMpi.MpiTests
{
    [TestClass()]
    public partial class ParallelFunctionBuilderTests
    {

        public static Process CurrentProcess => Process.GetCurrentProcess();
        public static int ProcessId => CurrentProcess.Id;
        public static int? _cpu;
        public static int Cpu => _cpu.HasValue ? _cpu.Value : (_cpu = GetCpuId()).Value;

        private static int? GetCpuId()
        {
            int cpuNumber = 0;
            for (var cpuMask = ((int)CurrentProcess.ProcessorAffinity); cpuMask > 1; cpuNumber++, cpuMask >>= 1) ;
            return cpuNumber;


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