/*
 Copyright (c) 2023 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 
 
 Source code for this software can be found at https://github.com/alexhiggins732/DotMpi
 
 This software is licensce under GNU General Public License version 3 as described in the LICENSE
 file at https://github.com/alexhiggins732/DotMpi/LICENSE
 
 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Versioning;
using static DotMpi.Mpi;


namespace DotMpi.MpiTests
{
     public partial class MpiTests
    {
        public partial class ArgListTests
        {
            const int numThreads = 2;
    
                [TestMethod]
                public void ArgList_TestCreate_00()
                {
                    var argList = ArgList.Create(0);
                    Assert.AreEqual(0, argList.Arg0);
                                        
                }

                [TestMethod]
                public void ArgList_TestFuncReadCreate_00()
                {
                    Func<int, string> target = For;
                    var argList = ArgList.Create(0);

                    var fn= Mpi.ParallelFor(numThreads, target, (i) => argList);
                    var fnArgProvider = fn.ArgProvider;
                    var fnArgs = fnArgProvider(0);

                    Assert.AreEqual(0, fnArgs.Arg0);
                                        
                }

    
                [TestMethod]
                public void ArgList_TestCreate_01()
                {
                    var argList = ArgList.Create(0, 1);
                    Assert.AreEqual(0, argList.Arg0);
                    Assert.AreEqual(1, argList.Arg1);
                                        
                }

                [TestMethod]
                public void ArgList_TestFuncReadCreate_01()
                {
                    Func<int, int, string> target = For;
                    var argList = ArgList.Create(0, 1);

                    var fn= Mpi.ParallelFor(numThreads, target, (i) => argList);
                    var fnArgProvider = fn.ArgProvider;
                    var fnArgs = fnArgProvider(0);

                    Assert.AreEqual(0, fnArgs.Arg0);
                    Assert.AreEqual(1, fnArgs.Arg1);
                                        
                }

    
                [TestMethod]
                public void ArgList_TestCreate_02()
                {
                    var argList = ArgList.Create(0, 1, 2);
                    Assert.AreEqual(0, argList.Arg0);
                    Assert.AreEqual(1, argList.Arg1);
                    Assert.AreEqual(2, argList.Arg2);
                                        
                }

                [TestMethod]
                public void ArgList_TestFuncReadCreate_02()
                {
                    Func<int, int, int, string> target = For;
                    var argList = ArgList.Create(0, 1, 2);

                    var fn= Mpi.ParallelFor(numThreads, target, (i) => argList);
                    var fnArgProvider = fn.ArgProvider;
                    var fnArgs = fnArgProvider(0);

                    Assert.AreEqual(0, fnArgs.Arg0);
                    Assert.AreEqual(1, fnArgs.Arg1);
                    Assert.AreEqual(2, fnArgs.Arg2);
                                        
                }

    
                [TestMethod]
                public void ArgList_TestCreate_03()
                {
                    var argList = ArgList.Create(0, 1, 2, 3);
                    Assert.AreEqual(0, argList.Arg0);
                    Assert.AreEqual(1, argList.Arg1);
                    Assert.AreEqual(2, argList.Arg2);
                    Assert.AreEqual(3, argList.Arg3);
                                        
                }

                [TestMethod]
                public void ArgList_TestFuncReadCreate_03()
                {
                    Func<int, int, int, int, string> target = For;
                    var argList = ArgList.Create(0, 1, 2, 3);

                    var fn= Mpi.ParallelFor(numThreads, target, (i) => argList);
                    var fnArgProvider = fn.ArgProvider;
                    var fnArgs = fnArgProvider(0);

                    Assert.AreEqual(0, fnArgs.Arg0);
                    Assert.AreEqual(1, fnArgs.Arg1);
                    Assert.AreEqual(2, fnArgs.Arg2);
                    Assert.AreEqual(3, fnArgs.Arg3);
                                        
                }

    
                [TestMethod]
                public void ArgList_TestCreate_04()
                {
                    var argList = ArgList.Create(0, 1, 2, 3, 4);
                    Assert.AreEqual(0, argList.Arg0);
                    Assert.AreEqual(1, argList.Arg1);
                    Assert.AreEqual(2, argList.Arg2);
                    Assert.AreEqual(3, argList.Arg3);
                    Assert.AreEqual(4, argList.Arg4);
                                        
                }

                [TestMethod]
                public void ArgList_TestFuncReadCreate_04()
                {
                    Func<int, int, int, int, int, string> target = For;
                    var argList = ArgList.Create(0, 1, 2, 3, 4);

                    var fn= Mpi.ParallelFor(numThreads, target, (i) => argList);
                    var fnArgProvider = fn.ArgProvider;
                    var fnArgs = fnArgProvider(0);

                    Assert.AreEqual(0, fnArgs.Arg0);
                    Assert.AreEqual(1, fnArgs.Arg1);
                    Assert.AreEqual(2, fnArgs.Arg2);
                    Assert.AreEqual(3, fnArgs.Arg3);
                    Assert.AreEqual(4, fnArgs.Arg4);
                                        
                }

    
                [TestMethod]
                public void ArgList_TestCreate_05()
                {
                    var argList = ArgList.Create(0, 1, 2, 3, 4, 5);
                    Assert.AreEqual(0, argList.Arg0);
                    Assert.AreEqual(1, argList.Arg1);
                    Assert.AreEqual(2, argList.Arg2);
                    Assert.AreEqual(3, argList.Arg3);
                    Assert.AreEqual(4, argList.Arg4);
                    Assert.AreEqual(5, argList.Arg5);
                                        
                }

                [TestMethod]
                public void ArgList_TestFuncReadCreate_05()
                {
                    Func<int, int, int, int, int, int, string> target = For;
                    var argList = ArgList.Create(0, 1, 2, 3, 4, 5);

                    var fn= Mpi.ParallelFor(numThreads, target, (i) => argList);
                    var fnArgProvider = fn.ArgProvider;
                    var fnArgs = fnArgProvider(0);

                    Assert.AreEqual(0, fnArgs.Arg0);
                    Assert.AreEqual(1, fnArgs.Arg1);
                    Assert.AreEqual(2, fnArgs.Arg2);
                    Assert.AreEqual(3, fnArgs.Arg3);
                    Assert.AreEqual(4, fnArgs.Arg4);
                    Assert.AreEqual(5, fnArgs.Arg5);
                                        
                }

    
                [TestMethod]
                public void ArgList_TestCreate_06()
                {
                    var argList = ArgList.Create(0, 1, 2, 3, 4, 5, 6);
                    Assert.AreEqual(0, argList.Arg0);
                    Assert.AreEqual(1, argList.Arg1);
                    Assert.AreEqual(2, argList.Arg2);
                    Assert.AreEqual(3, argList.Arg3);
                    Assert.AreEqual(4, argList.Arg4);
                    Assert.AreEqual(5, argList.Arg5);
                    Assert.AreEqual(6, argList.Arg6);
                                        
                }

                [TestMethod]
                public void ArgList_TestFuncReadCreate_06()
                {
                    Func<int, int, int, int, int, int, int, string> target = For;
                    var argList = ArgList.Create(0, 1, 2, 3, 4, 5, 6);

                    var fn= Mpi.ParallelFor(numThreads, target, (i) => argList);
                    var fnArgProvider = fn.ArgProvider;
                    var fnArgs = fnArgProvider(0);

                    Assert.AreEqual(0, fnArgs.Arg0);
                    Assert.AreEqual(1, fnArgs.Arg1);
                    Assert.AreEqual(2, fnArgs.Arg2);
                    Assert.AreEqual(3, fnArgs.Arg3);
                    Assert.AreEqual(4, fnArgs.Arg4);
                    Assert.AreEqual(5, fnArgs.Arg5);
                    Assert.AreEqual(6, fnArgs.Arg6);
                                        
                }

    
                [TestMethod]
                public void ArgList_TestCreate_07()
                {
                    var argList = ArgList.Create(0, 1, 2, 3, 4, 5, 6, 7);
                    Assert.AreEqual(0, argList.Arg0);
                    Assert.AreEqual(1, argList.Arg1);
                    Assert.AreEqual(2, argList.Arg2);
                    Assert.AreEqual(3, argList.Arg3);
                    Assert.AreEqual(4, argList.Arg4);
                    Assert.AreEqual(5, argList.Arg5);
                    Assert.AreEqual(6, argList.Arg6);
                    Assert.AreEqual(7, argList.Arg7);
                                        
                }

                [TestMethod]
                public void ArgList_TestFuncReadCreate_07()
                {
                    Func<int, int, int, int, int, int, int, int, string> target = For;
                    var argList = ArgList.Create(0, 1, 2, 3, 4, 5, 6, 7);

                    var fn= Mpi.ParallelFor(numThreads, target, (i) => argList);
                    var fnArgProvider = fn.ArgProvider;
                    var fnArgs = fnArgProvider(0);

                    Assert.AreEqual(0, fnArgs.Arg0);
                    Assert.AreEqual(1, fnArgs.Arg1);
                    Assert.AreEqual(2, fnArgs.Arg2);
                    Assert.AreEqual(3, fnArgs.Arg3);
                    Assert.AreEqual(4, fnArgs.Arg4);
                    Assert.AreEqual(5, fnArgs.Arg5);
                    Assert.AreEqual(6, fnArgs.Arg6);
                    Assert.AreEqual(7, fnArgs.Arg7);
                                        
                }

    
                [TestMethod]
                public void ArgList_TestCreate_08()
                {
                    var argList = ArgList.Create(0, 1, 2, 3, 4, 5, 6, 7, 8);
                    Assert.AreEqual(0, argList.Arg0);
                    Assert.AreEqual(1, argList.Arg1);
                    Assert.AreEqual(2, argList.Arg2);
                    Assert.AreEqual(3, argList.Arg3);
                    Assert.AreEqual(4, argList.Arg4);
                    Assert.AreEqual(5, argList.Arg5);
                    Assert.AreEqual(6, argList.Arg6);
                    Assert.AreEqual(7, argList.Arg7);
                    Assert.AreEqual(8, argList.Arg8);
                                        
                }

                [TestMethod]
                public void ArgList_TestFuncReadCreate_08()
                {
                    Func<int, int, int, int, int, int, int, int, int, string> target = For;
                    var argList = ArgList.Create(0, 1, 2, 3, 4, 5, 6, 7, 8);

                    var fn= Mpi.ParallelFor(numThreads, target, (i) => argList);
                    var fnArgProvider = fn.ArgProvider;
                    var fnArgs = fnArgProvider(0);

                    Assert.AreEqual(0, fnArgs.Arg0);
                    Assert.AreEqual(1, fnArgs.Arg1);
                    Assert.AreEqual(2, fnArgs.Arg2);
                    Assert.AreEqual(3, fnArgs.Arg3);
                    Assert.AreEqual(4, fnArgs.Arg4);
                    Assert.AreEqual(5, fnArgs.Arg5);
                    Assert.AreEqual(6, fnArgs.Arg6);
                    Assert.AreEqual(7, fnArgs.Arg7);
                    Assert.AreEqual(8, fnArgs.Arg8);
                                        
                }

    
                [TestMethod]
                public void ArgList_TestCreate_09()
                {
                    var argList = ArgList.Create(0, 1, 2, 3, 4, 5, 6, 7, 8, 9);
                    Assert.AreEqual(0, argList.Arg0);
                    Assert.AreEqual(1, argList.Arg1);
                    Assert.AreEqual(2, argList.Arg2);
                    Assert.AreEqual(3, argList.Arg3);
                    Assert.AreEqual(4, argList.Arg4);
                    Assert.AreEqual(5, argList.Arg5);
                    Assert.AreEqual(6, argList.Arg6);
                    Assert.AreEqual(7, argList.Arg7);
                    Assert.AreEqual(8, argList.Arg8);
                    Assert.AreEqual(9, argList.Arg9);
                                        
                }

                [TestMethod]
                public void ArgList_TestFuncReadCreate_09()
                {
                    Func<int, int, int, int, int, int, int, int, int, int, string> target = For;
                    var argList = ArgList.Create(0, 1, 2, 3, 4, 5, 6, 7, 8, 9);

                    var fn= Mpi.ParallelFor(numThreads, target, (i) => argList);
                    var fnArgProvider = fn.ArgProvider;
                    var fnArgs = fnArgProvider(0);

                    Assert.AreEqual(0, fnArgs.Arg0);
                    Assert.AreEqual(1, fnArgs.Arg1);
                    Assert.AreEqual(2, fnArgs.Arg2);
                    Assert.AreEqual(3, fnArgs.Arg3);
                    Assert.AreEqual(4, fnArgs.Arg4);
                    Assert.AreEqual(5, fnArgs.Arg5);
                    Assert.AreEqual(6, fnArgs.Arg6);
                    Assert.AreEqual(7, fnArgs.Arg7);
                    Assert.AreEqual(8, fnArgs.Arg8);
                    Assert.AreEqual(9, fnArgs.Arg9);
                                        
                }

    
                [TestMethod]
                public void ArgList_TestCreate_10()
                {
                    var argList = ArgList.Create(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
                    Assert.AreEqual(0, argList.Arg0);
                    Assert.AreEqual(1, argList.Arg1);
                    Assert.AreEqual(2, argList.Arg2);
                    Assert.AreEqual(3, argList.Arg3);
                    Assert.AreEqual(4, argList.Arg4);
                    Assert.AreEqual(5, argList.Arg5);
                    Assert.AreEqual(6, argList.Arg6);
                    Assert.AreEqual(7, argList.Arg7);
                    Assert.AreEqual(8, argList.Arg8);
                    Assert.AreEqual(9, argList.Arg9);
                    Assert.AreEqual(10, argList.Arg10);
                                        
                }

                [TestMethod]
                public void ArgList_TestFuncReadCreate_10()
                {
                    Func<int, int, int, int, int, int, int, int, int, int, int, string> target = For;
                    var argList = ArgList.Create(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

                    var fn= Mpi.ParallelFor(numThreads, target, (i) => argList);
                    var fnArgProvider = fn.ArgProvider;
                    var fnArgs = fnArgProvider(0);

                    Assert.AreEqual(0, fnArgs.Arg0);
                    Assert.AreEqual(1, fnArgs.Arg1);
                    Assert.AreEqual(2, fnArgs.Arg2);
                    Assert.AreEqual(3, fnArgs.Arg3);
                    Assert.AreEqual(4, fnArgs.Arg4);
                    Assert.AreEqual(5, fnArgs.Arg5);
                    Assert.AreEqual(6, fnArgs.Arg6);
                    Assert.AreEqual(7, fnArgs.Arg7);
                    Assert.AreEqual(8, fnArgs.Arg8);
                    Assert.AreEqual(9, fnArgs.Arg9);
                    Assert.AreEqual(10, fnArgs.Arg10);
                                        
                }

    
                [TestMethod]
                public void ArgList_TestCreate_11()
                {
                    var argList = ArgList.Create(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
                    Assert.AreEqual(0, argList.Arg0);
                    Assert.AreEqual(1, argList.Arg1);
                    Assert.AreEqual(2, argList.Arg2);
                    Assert.AreEqual(3, argList.Arg3);
                    Assert.AreEqual(4, argList.Arg4);
                    Assert.AreEqual(5, argList.Arg5);
                    Assert.AreEqual(6, argList.Arg6);
                    Assert.AreEqual(7, argList.Arg7);
                    Assert.AreEqual(8, argList.Arg8);
                    Assert.AreEqual(9, argList.Arg9);
                    Assert.AreEqual(10, argList.Arg10);
                    Assert.AreEqual(11, argList.Arg11);
                                        
                }

                [TestMethod]
                public void ArgList_TestFuncReadCreate_11()
                {
                    Func<int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;
                    var argList = ArgList.Create(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);

                    var fn= Mpi.ParallelFor(numThreads, target, (i) => argList);
                    var fnArgProvider = fn.ArgProvider;
                    var fnArgs = fnArgProvider(0);

                    Assert.AreEqual(0, fnArgs.Arg0);
                    Assert.AreEqual(1, fnArgs.Arg1);
                    Assert.AreEqual(2, fnArgs.Arg2);
                    Assert.AreEqual(3, fnArgs.Arg3);
                    Assert.AreEqual(4, fnArgs.Arg4);
                    Assert.AreEqual(5, fnArgs.Arg5);
                    Assert.AreEqual(6, fnArgs.Arg6);
                    Assert.AreEqual(7, fnArgs.Arg7);
                    Assert.AreEqual(8, fnArgs.Arg8);
                    Assert.AreEqual(9, fnArgs.Arg9);
                    Assert.AreEqual(10, fnArgs.Arg10);
                    Assert.AreEqual(11, fnArgs.Arg11);
                                        
                }

    
                [TestMethod]
                public void ArgList_TestCreate_12()
                {
                    var argList = ArgList.Create(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
                    Assert.AreEqual(0, argList.Arg0);
                    Assert.AreEqual(1, argList.Arg1);
                    Assert.AreEqual(2, argList.Arg2);
                    Assert.AreEqual(3, argList.Arg3);
                    Assert.AreEqual(4, argList.Arg4);
                    Assert.AreEqual(5, argList.Arg5);
                    Assert.AreEqual(6, argList.Arg6);
                    Assert.AreEqual(7, argList.Arg7);
                    Assert.AreEqual(8, argList.Arg8);
                    Assert.AreEqual(9, argList.Arg9);
                    Assert.AreEqual(10, argList.Arg10);
                    Assert.AreEqual(11, argList.Arg11);
                    Assert.AreEqual(12, argList.Arg12);
                                        
                }

                [TestMethod]
                public void ArgList_TestFuncReadCreate_12()
                {
                    Func<int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;
                    var argList = ArgList.Create(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);

                    var fn= Mpi.ParallelFor(numThreads, target, (i) => argList);
                    var fnArgProvider = fn.ArgProvider;
                    var fnArgs = fnArgProvider(0);

                    Assert.AreEqual(0, fnArgs.Arg0);
                    Assert.AreEqual(1, fnArgs.Arg1);
                    Assert.AreEqual(2, fnArgs.Arg2);
                    Assert.AreEqual(3, fnArgs.Arg3);
                    Assert.AreEqual(4, fnArgs.Arg4);
                    Assert.AreEqual(5, fnArgs.Arg5);
                    Assert.AreEqual(6, fnArgs.Arg6);
                    Assert.AreEqual(7, fnArgs.Arg7);
                    Assert.AreEqual(8, fnArgs.Arg8);
                    Assert.AreEqual(9, fnArgs.Arg9);
                    Assert.AreEqual(10, fnArgs.Arg10);
                    Assert.AreEqual(11, fnArgs.Arg11);
                    Assert.AreEqual(12, fnArgs.Arg12);
                                        
                }

    
                [TestMethod]
                public void ArgList_TestCreate_13()
                {
                    var argList = ArgList.Create(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
                    Assert.AreEqual(0, argList.Arg0);
                    Assert.AreEqual(1, argList.Arg1);
                    Assert.AreEqual(2, argList.Arg2);
                    Assert.AreEqual(3, argList.Arg3);
                    Assert.AreEqual(4, argList.Arg4);
                    Assert.AreEqual(5, argList.Arg5);
                    Assert.AreEqual(6, argList.Arg6);
                    Assert.AreEqual(7, argList.Arg7);
                    Assert.AreEqual(8, argList.Arg8);
                    Assert.AreEqual(9, argList.Arg9);
                    Assert.AreEqual(10, argList.Arg10);
                    Assert.AreEqual(11, argList.Arg11);
                    Assert.AreEqual(12, argList.Arg12);
                    Assert.AreEqual(13, argList.Arg13);
                                        
                }

                [TestMethod]
                public void ArgList_TestFuncReadCreate_13()
                {
                    Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;
                    var argList = ArgList.Create(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);

                    var fn= Mpi.ParallelFor(numThreads, target, (i) => argList);
                    var fnArgProvider = fn.ArgProvider;
                    var fnArgs = fnArgProvider(0);

                    Assert.AreEqual(0, fnArgs.Arg0);
                    Assert.AreEqual(1, fnArgs.Arg1);
                    Assert.AreEqual(2, fnArgs.Arg2);
                    Assert.AreEqual(3, fnArgs.Arg3);
                    Assert.AreEqual(4, fnArgs.Arg4);
                    Assert.AreEqual(5, fnArgs.Arg5);
                    Assert.AreEqual(6, fnArgs.Arg6);
                    Assert.AreEqual(7, fnArgs.Arg7);
                    Assert.AreEqual(8, fnArgs.Arg8);
                    Assert.AreEqual(9, fnArgs.Arg9);
                    Assert.AreEqual(10, fnArgs.Arg10);
                    Assert.AreEqual(11, fnArgs.Arg11);
                    Assert.AreEqual(12, fnArgs.Arg12);
                    Assert.AreEqual(13, fnArgs.Arg13);
                                        
                }

    
                [TestMethod]
                public void ArgList_TestCreate_14()
                {
                    var argList = ArgList.Create(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);
                    Assert.AreEqual(0, argList.Arg0);
                    Assert.AreEqual(1, argList.Arg1);
                    Assert.AreEqual(2, argList.Arg2);
                    Assert.AreEqual(3, argList.Arg3);
                    Assert.AreEqual(4, argList.Arg4);
                    Assert.AreEqual(5, argList.Arg5);
                    Assert.AreEqual(6, argList.Arg6);
                    Assert.AreEqual(7, argList.Arg7);
                    Assert.AreEqual(8, argList.Arg8);
                    Assert.AreEqual(9, argList.Arg9);
                    Assert.AreEqual(10, argList.Arg10);
                    Assert.AreEqual(11, argList.Arg11);
                    Assert.AreEqual(12, argList.Arg12);
                    Assert.AreEqual(13, argList.Arg13);
                    Assert.AreEqual(14, argList.Arg14);
                                        
                }

                [TestMethod]
                public void ArgList_TestFuncReadCreate_14()
                {
                    Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;
                    var argList = ArgList.Create(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);

                    var fn= Mpi.ParallelFor(numThreads, target, (i) => argList);
                    var fnArgProvider = fn.ArgProvider;
                    var fnArgs = fnArgProvider(0);

                    Assert.AreEqual(0, fnArgs.Arg0);
                    Assert.AreEqual(1, fnArgs.Arg1);
                    Assert.AreEqual(2, fnArgs.Arg2);
                    Assert.AreEqual(3, fnArgs.Arg3);
                    Assert.AreEqual(4, fnArgs.Arg4);
                    Assert.AreEqual(5, fnArgs.Arg5);
                    Assert.AreEqual(6, fnArgs.Arg6);
                    Assert.AreEqual(7, fnArgs.Arg7);
                    Assert.AreEqual(8, fnArgs.Arg8);
                    Assert.AreEqual(9, fnArgs.Arg9);
                    Assert.AreEqual(10, fnArgs.Arg10);
                    Assert.AreEqual(11, fnArgs.Arg11);
                    Assert.AreEqual(12, fnArgs.Arg12);
                    Assert.AreEqual(13, fnArgs.Arg13);
                    Assert.AreEqual(14, fnArgs.Arg14);
                                        
                }

    
                [TestMethod]
                public void ArgList_TestCreate_15()
                {
                    var argList = ArgList.Create(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
                    Assert.AreEqual(0, argList.Arg0);
                    Assert.AreEqual(1, argList.Arg1);
                    Assert.AreEqual(2, argList.Arg2);
                    Assert.AreEqual(3, argList.Arg3);
                    Assert.AreEqual(4, argList.Arg4);
                    Assert.AreEqual(5, argList.Arg5);
                    Assert.AreEqual(6, argList.Arg6);
                    Assert.AreEqual(7, argList.Arg7);
                    Assert.AreEqual(8, argList.Arg8);
                    Assert.AreEqual(9, argList.Arg9);
                    Assert.AreEqual(10, argList.Arg10);
                    Assert.AreEqual(11, argList.Arg11);
                    Assert.AreEqual(12, argList.Arg12);
                    Assert.AreEqual(13, argList.Arg13);
                    Assert.AreEqual(14, argList.Arg14);
                    Assert.AreEqual(15, argList.Arg15);
                                        
                }

                [TestMethod]
                public void ArgList_TestFuncReadCreate_15()
                {
                    Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;
                    var argList = ArgList.Create(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);

                    var fn= Mpi.ParallelFor(numThreads, target, (i) => argList);
                    var fnArgProvider = fn.ArgProvider;
                    var fnArgs = fnArgProvider(0);

                    Assert.AreEqual(0, fnArgs.Arg0);
                    Assert.AreEqual(1, fnArgs.Arg1);
                    Assert.AreEqual(2, fnArgs.Arg2);
                    Assert.AreEqual(3, fnArgs.Arg3);
                    Assert.AreEqual(4, fnArgs.Arg4);
                    Assert.AreEqual(5, fnArgs.Arg5);
                    Assert.AreEqual(6, fnArgs.Arg6);
                    Assert.AreEqual(7, fnArgs.Arg7);
                    Assert.AreEqual(8, fnArgs.Arg8);
                    Assert.AreEqual(9, fnArgs.Arg9);
                    Assert.AreEqual(10, fnArgs.Arg10);
                    Assert.AreEqual(11, fnArgs.Arg11);
                    Assert.AreEqual(12, fnArgs.Arg12);
                    Assert.AreEqual(13, fnArgs.Arg13);
                    Assert.AreEqual(14, fnArgs.Arg14);
                    Assert.AreEqual(15, fnArgs.Arg15);
                                        
                }

    
        }
    }
}