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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotMpi.MpiTests
{
    public partial class MpiTests
    {
        public partial class ParallelFunctionTests
        {
        
        
            [TestMethod()]
            public void ParallelFunction_ForTest_1_00()
            {
                Func<int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target, i => new(i));
                
                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_2_00()
            {
                Func<int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, 0);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod()]
            public void ParallelFunction_ForTest_3_00()
            {
                Func<int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target)
                    .WithArgs(i => new(i));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_4_00()
            {
                Func<int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target)
                    .WithArgs(0);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            
            [TestMethod()]
            public void ParallelFunction_ForTest_1_01()
            {
                Func<int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target, i => new(i, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_2_01()
            {
                Func<int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod()]
            public void ParallelFunction_ForTest_3_01()
            {
                Func<int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target)
                    .WithArgs(i => new(i, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_4_01()
            {
                Func<int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target)
                    .WithArgs(0, 1);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            
            [TestMethod()]
            public void ParallelFunction_ForTest_1_02()
            {
                Func<int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target, i => new(i, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_2_02()
            {
                Func<int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod()]
            public void ParallelFunction_ForTest_3_02()
            {
                Func<int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target)
                    .WithArgs(i => new(i, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_4_02()
            {
                Func<int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target)
                    .WithArgs(0, 1, 2);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            
            [TestMethod()]
            public void ParallelFunction_ForTest_1_03()
            {
                Func<int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target, i => new(i, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_2_03()
            {
                Func<int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod()]
            public void ParallelFunction_ForTest_3_03()
            {
                Func<int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target)
                    .WithArgs(i => new(i, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_4_03()
            {
                Func<int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target)
                    .WithArgs(0, 1, 2, 3);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            
            [TestMethod()]
            public void ParallelFunction_ForTest_1_04()
            {
                Func<int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target, i => new(i, 0, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_2_04()
            {
                Func<int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod()]
            public void ParallelFunction_ForTest_3_04()
            {
                Func<int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target)
                    .WithArgs(i => new(i, 0, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_4_04()
            {
                Func<int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target)
                    .WithArgs(0, 1, 2, 3, 4);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            
            [TestMethod()]
            public void ParallelFunction_ForTest_1_05()
            {
                Func<int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target, i => new(i, 0, 0, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_2_05()
            {
                Func<int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod()]
            public void ParallelFunction_ForTest_3_05()
            {
                Func<int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target)
                    .WithArgs(i => new(i, 0, 0, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_4_05()
            {
                Func<int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target)
                    .WithArgs(0, 1, 2, 3, 4, 5);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            
            [TestMethod()]
            public void ParallelFunction_ForTest_1_06()
            {
                Func<int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_2_06()
            {
                Func<int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod()]
            public void ParallelFunction_ForTest_3_06()
            {
                Func<int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target)
                    .WithArgs(i => new(i, 0, 0, 0, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_4_06()
            {
                Func<int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target)
                    .WithArgs(0, 1, 2, 3, 4, 5, 6);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            
            [TestMethod()]
            public void ParallelFunction_ForTest_1_07()
            {
                Func<int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_2_07()
            {
                Func<int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod()]
            public void ParallelFunction_ForTest_3_07()
            {
                Func<int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target)
                    .WithArgs(i => new(i, 0, 0, 0, 0, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_4_07()
            {
                Func<int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target)
                    .WithArgs(0, 1, 2, 3, 4, 5, 6, 7);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            
            [TestMethod()]
            public void ParallelFunction_ForTest_1_08()
            {
                Func<int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_2_08()
            {
                Func<int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod()]
            public void ParallelFunction_ForTest_3_08()
            {
                Func<int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target)
                    .WithArgs(i => new(i, 0, 0, 0, 0, 0, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_4_08()
            {
                Func<int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target)
                    .WithArgs(0, 1, 2, 3, 4, 5, 6, 7, 8);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            
            [TestMethod()]
            public void ParallelFunction_ForTest_1_09()
            {
                Func<int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_2_09()
            {
                Func<int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod()]
            public void ParallelFunction_ForTest_3_09()
            {
                Func<int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target)
                    .WithArgs(i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_4_09()
            {
                Func<int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target)
                    .WithArgs(0, 1, 2, 3, 4, 5, 6, 7, 8, 9);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            
            [TestMethod()]
            public void ParallelFunction_ForTest_1_10()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_2_10()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod()]
            public void ParallelFunction_ForTest_3_10()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target)
                    .WithArgs(i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_4_10()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target)
                    .WithArgs(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            
            [TestMethod()]
            public void ParallelFunction_ForTest_1_11()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_2_11()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod()]
            public void ParallelFunction_ForTest_3_11()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target)
                    .WithArgs(i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_4_11()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target)
                    .WithArgs(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            
            [TestMethod()]
            public void ParallelFunction_ForTest_1_12()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_2_12()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod()]
            public void ParallelFunction_ForTest_3_12()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target)
                    .WithArgs(i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_4_12()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target)
                    .WithArgs(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            
            [TestMethod()]
            public void ParallelFunction_ForTest_1_13()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_2_13()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod()]
            public void ParallelFunction_ForTest_3_13()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target)
                    .WithArgs(i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_4_13()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target)
                    .WithArgs(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            
            [TestMethod()]
            public void ParallelFunction_ForTest_1_14()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_2_14()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod()]
            public void ParallelFunction_ForTest_3_14()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target)
                    .WithArgs(i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_4_14()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target)
                    .WithArgs(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            
            [TestMethod()]
            public void ParallelFunction_ForTest_1_15()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_2_15()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod()]
            public void ParallelFunction_ForTest_3_15()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(numThreads, target)
                    .WithArgs(i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            [TestMethod]
            public void ParallelFunction_ForTest_4_15()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target)
                    .WithArgs(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);

                Assert.AreEqual(target.Method.MetadataToken, func.Target.Method.MetadataToken);
                Assert.AreEqual(0, func.Start);
                Assert.AreEqual(numThreads, func.End);
            }

            
        }
    }
}