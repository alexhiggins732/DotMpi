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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DotMpi.Mpi;

namespace DotMpi.MpiTests
{
    public partial class MpiTests
    {

        [TestClass()]
        public partial class ParallelFunctionTests
        {


            [TestMethod()]
            public void ParallelFunctionRange_ResetTest()
            {
                Func<int, string> target = For;

                var func = Mpi.ParallelFor(0, numThreads, target).WithArgs(i => i)
                    .Run();
                func.Reset();
                Assert.AreEqual(0, func.Tasks.Count);

            }

            [TestMethod()]
            public void ParallelFunction_KillTest()
            {
                Func<int, string> target = For;

                var func = Mpi.ParallelFor(numThreads, target, 0).Run();

                func.Kill();
                Assert.AreEqual(3, func.Tasks.Count);
                func.Reset();
                Assert.AreEqual(0, func.Tasks.Count);
                func.Run().Wait();

                Assert.AreEqual(3, func.Tasks.Count);
                Assert.IsNotNull(func.Results[0]);
                Assert.IsTrue(func.Results[0].StartsWith("Thread 0"));

            }


            [TestMethod()]
            public void ParallelFunction_RunTest()
            {
                Func<int, string> target = For;

                var func = Mpi.Parallel(numThreads).For(target);

                var ex = Assert.ThrowsException<ArgumentNullException>(() => func.Run());

                Assert.AreEqual("Value cannot be null. (Parameter 'ArgProvider')", ex.Message);

            }

            [TestMethod()]
            public void ParallelFunction_DoubleRunTest()
            {
                Func<int, string> target = For;

                var func = Mpi.ParallelFor(numThreads, target, 0);

                var runner = func.Run();
                Assert.ThrowsException<Exception>(() => runner.Run());
                runner.Kill();
            }


            static string? NullTest(int i) => null;
            [TestMethod()]
            public void ParallelFunction_NullResultTest()
            {
                Func<int, string?> target = NullTest;

                var func = Mpi.ParallelFor(numThreads, target, 0);
                var runner = func.Run().Wait();
                Assert.IsNull(runner.Results[0]);

            }

            [TestMethod()]
            public void ParallelFunction_WithNoFunc()
            {
                var fn = new Mpi.ParallelFunction<int>(0, numThreads);
                var ex = Assert.ThrowsException<ArgumentNullException>(() => fn.Build());
                Assert.AreEqual($"Value cannot be null. (Parameter '{nameof(IParalellFunction.Delegate)}')", ex.Message);
            }

            [TestMethod()]
            public void ParallelFunction_WithNoArgProvider()
            {
                Func<int, string?> target = NullTest;
                var fn = Mpi.ParallelFor(numThreads, target);
                var ex = Assert.ThrowsException<ArgumentNullException>(() => fn.Build());
                Assert.AreEqual($"Value cannot be null. (Parameter '{nameof(IParalellFunction.ArgProvider)}')", ex.Message);
            }



            [TestMethod()]
            public void ParallelFunction_TestNumThreds()
            {
                Func<int, string?> target = NullTest;
                var fn = Mpi.ParallelFor(4, 8, target);
                Assert.AreEqual(4, fn.NumThreads);

            }


        }
    }
}