using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotMpi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotMpi.MpiTests
{
    [TestClass()]
    public partial class MpiTests
    {
        [TestMethod()]
        public void PipeNameTest()
        {
            Mpi.PipeName = "Master";
            Assert.AreEqual("Master", Mpi.PipeName);
            Assert.AreEqual(Mpi.id, MpiRunner.id);

        }



        [TestMethod()]
        public void ParallelTest1()
        {
            Func<int, string> target= For;
            var func = Mpi.ParallelFor(0, numThreads, target, i => i);

            Assert.AreEqual(0, func.Start);
            Assert.AreEqual(numThreads, func.End);
            Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);

        }


    }
}