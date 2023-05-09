/*
 Copyright (c) 2023 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 
 
 Source code for this software can be found at https://github.com/alexhiggins732/DotMpi
 
 This software is licensce under GNU General Public License version 3 as described in the LICENSE
 file at https://github.com/alexhiggins732/DotMpi/LICENSE
 
 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DotMpi.Mpi;
using Newtonsoft.Json;

namespace DotMpi.MpiTests
{
    public partial class MpiTests
    {

        public partial class ParallelForTests
        {
            
            // from, to, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_1_Range_ArgList_00()
            {
                Func<int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, i => new(0));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // from, to, target, args
            [TestMethod()]
            public void ParallelForTest_1_Range_Args_00()
            {
                Func<int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, 0);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

                Func<int, ArgList<int>> argProvider
                    = i => new(0);
                var runnerArgs= runner.ArgProvider(0).ToArray().Select(x=> (int)x);
                var fnArgs = argProvider(0).ToArray().Select(x=> (int)x);
                Assert.IsTrue(runnerArgs.SequenceEqual(fnArgs));

            }

            // from, to, target
            [TestMethod()]
            public void ParallelForTest_1_Range_00()
            {
                Func<int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }


            // numthreads, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_2_Range_ArgList_00()
            {
                Func<int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, i => new(0));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

            }

            // numthreads, target, args
            [TestMethod()]
            public void ParallelForTest_2_Range_Args_00()
            {
                Func<int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, 0);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // numthreads, target
            [TestMethod()]
            public void ParallelForTest_2_Range_00()
            {
                Func<int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }
            
            // from, to, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_1_Range_ArgList_01()
            {
                Func<int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, i => new(0, 1));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // from, to, target, args
            [TestMethod()]
            public void ParallelForTest_1_Range_Args_01()
            {
                Func<int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

                Func<int, ArgList<int, int>> argProvider
                    = i => new(0, 1);
                var runnerArgs= runner.ArgProvider(0).ToArray().Select(x=> (int)x);
                var fnArgs = argProvider(0).ToArray().Select(x=> (int)x);
                Assert.IsTrue(runnerArgs.SequenceEqual(fnArgs));

            }

            // from, to, target
            [TestMethod()]
            public void ParallelForTest_1_Range_01()
            {
                Func<int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }


            // numthreads, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_2_Range_ArgList_01()
            {
                Func<int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, i => new(0, 1));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

            }

            // numthreads, target, args
            [TestMethod()]
            public void ParallelForTest_2_Range_Args_01()
            {
                Func<int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, 0, 1);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // numthreads, target
            [TestMethod()]
            public void ParallelForTest_2_Range_01()
            {
                Func<int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }
            
            // from, to, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_1_Range_ArgList_02()
            {
                Func<int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, i => new(0, 1, 2));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // from, to, target, args
            [TestMethod()]
            public void ParallelForTest_1_Range_Args_02()
            {
                Func<int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

                Func<int, ArgList<int, int, int>> argProvider
                    = i => new(0, 1, 2);
                var runnerArgs= runner.ArgProvider(0).ToArray().Select(x=> (int)x);
                var fnArgs = argProvider(0).ToArray().Select(x=> (int)x);
                Assert.IsTrue(runnerArgs.SequenceEqual(fnArgs));

            }

            // from, to, target
            [TestMethod()]
            public void ParallelForTest_1_Range_02()
            {
                Func<int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }


            // numthreads, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_2_Range_ArgList_02()
            {
                Func<int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, i => new(0, 1, 2));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

            }

            // numthreads, target, args
            [TestMethod()]
            public void ParallelForTest_2_Range_Args_02()
            {
                Func<int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, 0, 1, 2);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // numthreads, target
            [TestMethod()]
            public void ParallelForTest_2_Range_02()
            {
                Func<int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }
            
            // from, to, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_1_Range_ArgList_03()
            {
                Func<int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, i => new(0, 1, 2, 3));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // from, to, target, args
            [TestMethod()]
            public void ParallelForTest_1_Range_Args_03()
            {
                Func<int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

                Func<int, ArgList<int, int, int, int>> argProvider
                    = i => new(0, 1, 2, 3);
                var runnerArgs= runner.ArgProvider(0).ToArray().Select(x=> (int)x);
                var fnArgs = argProvider(0).ToArray().Select(x=> (int)x);
                Assert.IsTrue(runnerArgs.SequenceEqual(fnArgs));

            }

            // from, to, target
            [TestMethod()]
            public void ParallelForTest_1_Range_03()
            {
                Func<int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }


            // numthreads, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_2_Range_ArgList_03()
            {
                Func<int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, i => new(0, 1, 2, 3));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

            }

            // numthreads, target, args
            [TestMethod()]
            public void ParallelForTest_2_Range_Args_03()
            {
                Func<int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, 0, 1, 2, 3);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // numthreads, target
            [TestMethod()]
            public void ParallelForTest_2_Range_03()
            {
                Func<int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }
            
            // from, to, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_1_Range_ArgList_04()
            {
                Func<int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, i => new(0, 1, 2, 3, 4));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // from, to, target, args
            [TestMethod()]
            public void ParallelForTest_1_Range_Args_04()
            {
                Func<int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

                Func<int, ArgList<int, int, int, int, int>> argProvider
                    = i => new(0, 1, 2, 3, 4);
                var runnerArgs= runner.ArgProvider(0).ToArray().Select(x=> (int)x);
                var fnArgs = argProvider(0).ToArray().Select(x=> (int)x);
                Assert.IsTrue(runnerArgs.SequenceEqual(fnArgs));

            }

            // from, to, target
            [TestMethod()]
            public void ParallelForTest_1_Range_04()
            {
                Func<int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }


            // numthreads, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_2_Range_ArgList_04()
            {
                Func<int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, i => new(0, 1, 2, 3, 4));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

            }

            // numthreads, target, args
            [TestMethod()]
            public void ParallelForTest_2_Range_Args_04()
            {
                Func<int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, 0, 1, 2, 3, 4);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // numthreads, target
            [TestMethod()]
            public void ParallelForTest_2_Range_04()
            {
                Func<int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }
            
            // from, to, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_1_Range_ArgList_05()
            {
                Func<int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, i => new(0, 1, 2, 3, 4, 5));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // from, to, target, args
            [TestMethod()]
            public void ParallelForTest_1_Range_Args_05()
            {
                Func<int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

                Func<int, ArgList<int, int, int, int, int, int>> argProvider
                    = i => new(0, 1, 2, 3, 4, 5);
                var runnerArgs= runner.ArgProvider(0).ToArray().Select(x=> (int)x);
                var fnArgs = argProvider(0).ToArray().Select(x=> (int)x);
                Assert.IsTrue(runnerArgs.SequenceEqual(fnArgs));

            }

            // from, to, target
            [TestMethod()]
            public void ParallelForTest_1_Range_05()
            {
                Func<int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }


            // numthreads, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_2_Range_ArgList_05()
            {
                Func<int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, i => new(0, 1, 2, 3, 4, 5));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

            }

            // numthreads, target, args
            [TestMethod()]
            public void ParallelForTest_2_Range_Args_05()
            {
                Func<int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, 0, 1, 2, 3, 4, 5);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // numthreads, target
            [TestMethod()]
            public void ParallelForTest_2_Range_05()
            {
                Func<int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }
            
            // from, to, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_1_Range_ArgList_06()
            {
                Func<int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, i => new(0, 1, 2, 3, 4, 5, 6));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // from, to, target, args
            [TestMethod()]
            public void ParallelForTest_1_Range_Args_06()
            {
                Func<int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

                Func<int, ArgList<int, int, int, int, int, int, int>> argProvider
                    = i => new(0, 1, 2, 3, 4, 5, 6);
                var runnerArgs= runner.ArgProvider(0).ToArray().Select(x=> (int)x);
                var fnArgs = argProvider(0).ToArray().Select(x=> (int)x);
                Assert.IsTrue(runnerArgs.SequenceEqual(fnArgs));

            }

            // from, to, target
            [TestMethod()]
            public void ParallelForTest_1_Range_06()
            {
                Func<int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }


            // numthreads, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_2_Range_ArgList_06()
            {
                Func<int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, i => new(0, 1, 2, 3, 4, 5, 6));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

            }

            // numthreads, target, args
            [TestMethod()]
            public void ParallelForTest_2_Range_Args_06()
            {
                Func<int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, 0, 1, 2, 3, 4, 5, 6);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // numthreads, target
            [TestMethod()]
            public void ParallelForTest_2_Range_06()
            {
                Func<int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }
            
            // from, to, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_1_Range_ArgList_07()
            {
                Func<int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, i => new(0, 1, 2, 3, 4, 5, 6, 7));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // from, to, target, args
            [TestMethod()]
            public void ParallelForTest_1_Range_Args_07()
            {
                Func<int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

                Func<int, ArgList<int, int, int, int, int, int, int, int>> argProvider
                    = i => new(0, 1, 2, 3, 4, 5, 6, 7);
                var runnerArgs= runner.ArgProvider(0).ToArray().Select(x=> (int)x);
                var fnArgs = argProvider(0).ToArray().Select(x=> (int)x);
                Assert.IsTrue(runnerArgs.SequenceEqual(fnArgs));

            }

            // from, to, target
            [TestMethod()]
            public void ParallelForTest_1_Range_07()
            {
                Func<int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }


            // numthreads, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_2_Range_ArgList_07()
            {
                Func<int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, i => new(0, 1, 2, 3, 4, 5, 6, 7));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

            }

            // numthreads, target, args
            [TestMethod()]
            public void ParallelForTest_2_Range_Args_07()
            {
                Func<int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // numthreads, target
            [TestMethod()]
            public void ParallelForTest_2_Range_07()
            {
                Func<int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }
            
            // from, to, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_1_Range_ArgList_08()
            {
                Func<int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, i => new(0, 1, 2, 3, 4, 5, 6, 7, 8));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // from, to, target, args
            [TestMethod()]
            public void ParallelForTest_1_Range_Args_08()
            {
                Func<int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

                Func<int, ArgList<int, int, int, int, int, int, int, int, int>> argProvider
                    = i => new(0, 1, 2, 3, 4, 5, 6, 7, 8);
                var runnerArgs= runner.ArgProvider(0).ToArray().Select(x=> (int)x);
                var fnArgs = argProvider(0).ToArray().Select(x=> (int)x);
                Assert.IsTrue(runnerArgs.SequenceEqual(fnArgs));

            }

            // from, to, target
            [TestMethod()]
            public void ParallelForTest_1_Range_08()
            {
                Func<int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }


            // numthreads, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_2_Range_ArgList_08()
            {
                Func<int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, i => new(0, 1, 2, 3, 4, 5, 6, 7, 8));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

            }

            // numthreads, target, args
            [TestMethod()]
            public void ParallelForTest_2_Range_Args_08()
            {
                Func<int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // numthreads, target
            [TestMethod()]
            public void ParallelForTest_2_Range_08()
            {
                Func<int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }
            
            // from, to, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_1_Range_ArgList_09()
            {
                Func<int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, i => new(0, 1, 2, 3, 4, 5, 6, 7, 8, 9));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // from, to, target, args
            [TestMethod()]
            public void ParallelForTest_1_Range_Args_09()
            {
                Func<int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

                Func<int, ArgList<int, int, int, int, int, int, int, int, int, int>> argProvider
                    = i => new(0, 1, 2, 3, 4, 5, 6, 7, 8, 9);
                var runnerArgs= runner.ArgProvider(0).ToArray().Select(x=> (int)x);
                var fnArgs = argProvider(0).ToArray().Select(x=> (int)x);
                Assert.IsTrue(runnerArgs.SequenceEqual(fnArgs));

            }

            // from, to, target
            [TestMethod()]
            public void ParallelForTest_1_Range_09()
            {
                Func<int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }


            // numthreads, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_2_Range_ArgList_09()
            {
                Func<int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, i => new(0, 1, 2, 3, 4, 5, 6, 7, 8, 9));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

            }

            // numthreads, target, args
            [TestMethod()]
            public void ParallelForTest_2_Range_Args_09()
            {
                Func<int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // numthreads, target
            [TestMethod()]
            public void ParallelForTest_2_Range_09()
            {
                Func<int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }
            
            // from, to, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_1_Range_ArgList_10()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, i => new(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // from, to, target, args
            [TestMethod()]
            public void ParallelForTest_1_Range_Args_10()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

                Func<int, ArgList<int, int, int, int, int, int, int, int, int, int, int>> argProvider
                    = i => new(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
                var runnerArgs= runner.ArgProvider(0).ToArray().Select(x=> (int)x);
                var fnArgs = argProvider(0).ToArray().Select(x=> (int)x);
                Assert.IsTrue(runnerArgs.SequenceEqual(fnArgs));

            }

            // from, to, target
            [TestMethod()]
            public void ParallelForTest_1_Range_10()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }


            // numthreads, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_2_Range_ArgList_10()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, i => new(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

            }

            // numthreads, target, args
            [TestMethod()]
            public void ParallelForTest_2_Range_Args_10()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // numthreads, target
            [TestMethod()]
            public void ParallelForTest_2_Range_10()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }
            
            // from, to, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_1_Range_ArgList_11()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, i => new(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // from, to, target, args
            [TestMethod()]
            public void ParallelForTest_1_Range_Args_11()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

                Func<int, ArgList<int, int, int, int, int, int, int, int, int, int, int, int>> argProvider
                    = i => new(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
                var runnerArgs= runner.ArgProvider(0).ToArray().Select(x=> (int)x);
                var fnArgs = argProvider(0).ToArray().Select(x=> (int)x);
                Assert.IsTrue(runnerArgs.SequenceEqual(fnArgs));

            }

            // from, to, target
            [TestMethod()]
            public void ParallelForTest_1_Range_11()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }


            // numthreads, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_2_Range_ArgList_11()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, i => new(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

            }

            // numthreads, target, args
            [TestMethod()]
            public void ParallelForTest_2_Range_Args_11()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // numthreads, target
            [TestMethod()]
            public void ParallelForTest_2_Range_11()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }
            
            // from, to, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_1_Range_ArgList_12()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, i => new(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // from, to, target, args
            [TestMethod()]
            public void ParallelForTest_1_Range_Args_12()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

                Func<int, ArgList<int, int, int, int, int, int, int, int, int, int, int, int, int>> argProvider
                    = i => new(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
                var runnerArgs= runner.ArgProvider(0).ToArray().Select(x=> (int)x);
                var fnArgs = argProvider(0).ToArray().Select(x=> (int)x);
                Assert.IsTrue(runnerArgs.SequenceEqual(fnArgs));

            }

            // from, to, target
            [TestMethod()]
            public void ParallelForTest_1_Range_12()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }


            // numthreads, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_2_Range_ArgList_12()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, i => new(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

            }

            // numthreads, target, args
            [TestMethod()]
            public void ParallelForTest_2_Range_Args_12()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // numthreads, target
            [TestMethod()]
            public void ParallelForTest_2_Range_12()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }
            
            // from, to, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_1_Range_ArgList_13()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, i => new(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // from, to, target, args
            [TestMethod()]
            public void ParallelForTest_1_Range_Args_13()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

                Func<int, ArgList<int, int, int, int, int, int, int, int, int, int, int, int, int, int>> argProvider
                    = i => new(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
                var runnerArgs= runner.ArgProvider(0).ToArray().Select(x=> (int)x);
                var fnArgs = argProvider(0).ToArray().Select(x=> (int)x);
                Assert.IsTrue(runnerArgs.SequenceEqual(fnArgs));

            }

            // from, to, target
            [TestMethod()]
            public void ParallelForTest_1_Range_13()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }


            // numthreads, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_2_Range_ArgList_13()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, i => new(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

            }

            // numthreads, target, args
            [TestMethod()]
            public void ParallelForTest_2_Range_Args_13()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // numthreads, target
            [TestMethod()]
            public void ParallelForTest_2_Range_13()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }
            
            // from, to, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_1_Range_ArgList_14()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, i => new(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // from, to, target, args
            [TestMethod()]
            public void ParallelForTest_1_Range_Args_14()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

                Func<int, ArgList<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>> argProvider
                    = i => new(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);
                var runnerArgs= runner.ArgProvider(0).ToArray().Select(x=> (int)x);
                var fnArgs = argProvider(0).ToArray().Select(x=> (int)x);
                Assert.IsTrue(runnerArgs.SequenceEqual(fnArgs));

            }

            // from, to, target
            [TestMethod()]
            public void ParallelForTest_1_Range_14()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }


            // numthreads, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_2_Range_ArgList_14()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, i => new(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

            }

            // numthreads, target, args
            [TestMethod()]
            public void ParallelForTest_2_Range_Args_14()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // numthreads, target
            [TestMethod()]
            public void ParallelForTest_2_Range_14()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }
            
            // from, to, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_1_Range_ArgList_15()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, i => new(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // from, to, target, args
            [TestMethod()]
            public void ParallelForTest_1_Range_Args_15()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

                Func<int, ArgList<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>> argProvider
                    = i => new(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
                var runnerArgs= runner.ArgProvider(0).ToArray().Select(x=> (int)x);
                var fnArgs = argProvider(0).ToArray().Select(x=> (int)x);
                Assert.IsTrue(runnerArgs.SequenceEqual(fnArgs));

            }

            // from, to, target
            [TestMethod()]
            public void ParallelForTest_1_Range_15()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(0, numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }


            // numthreads, target, func<int, arglist>
            [TestMethod()]
            public void ParallelForTest_2_Range_ArgList_15()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, i => new(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15));
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);

            }

            // numthreads, target, args
            [TestMethod()]
            public void ParallelForTest_2_Range_Args_15()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }

            // numthreads, target
            [TestMethod()]
            public void ParallelForTest_2_Range_15()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var runner = Mpi
                    .ParallelFor(numThreads, target);
                
                Assert.AreEqual(0, runner.Start);
                Assert.AreEqual(numThreads, runner.End);
                Assert.AreEqual(target.Method.MetadataToken, runner.Target.Method.MetadataToken);
            }
            
        }
    }
}