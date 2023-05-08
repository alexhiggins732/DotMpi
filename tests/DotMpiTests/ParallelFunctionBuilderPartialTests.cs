
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DotMpi.Mpi;

namespace DotMpi.MpiTests
{

    public partial class ParallelFunctionBuilderTests
    {

    
        public static string For(int arg0) 
            => $"Thread {arg0} - Cpu {Cpu} - Process {ProcessId}: {nameof(For)}";
    
        public static string For(int arg0, int arg1) 
            => $"Thread {arg0} - Cpu {Cpu} - Process {ProcessId}: {nameof(For)}";
    
        public static string For(int arg0, int arg1, int arg2) 
            => $"Thread {arg0} - Cpu {Cpu} - Process {ProcessId}: {nameof(For)}";
    
        public static string For(int arg0, int arg1, int arg2, int arg3) 
            => $"Thread {arg0} - Cpu {Cpu} - Process {ProcessId}: {nameof(For)}";
    
        public static string For(int arg0, int arg1, int arg2, int arg3, int arg4) 
            => $"Thread {arg0} - Cpu {Cpu} - Process {ProcessId}: {nameof(For)}";
    
        public static string For(int arg0, int arg1, int arg2, int arg3, int arg4, int arg5) 
            => $"Thread {arg0} - Cpu {Cpu} - Process {ProcessId}: {nameof(For)}";
    
        public static string For(int arg0, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6) 
            => $"Thread {arg0} - Cpu {Cpu} - Process {ProcessId}: {nameof(For)}";
    
        public static string For(int arg0, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7) 
            => $"Thread {arg0} - Cpu {Cpu} - Process {ProcessId}: {nameof(For)}";
    
        public static string For(int arg0, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8) 
            => $"Thread {arg0} - Cpu {Cpu} - Process {ProcessId}: {nameof(For)}";
    
        public static string For(int arg0, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9) 
            => $"Thread {arg0} - Cpu {Cpu} - Process {ProcessId}: {nameof(For)}";
    
        public static string For(int arg0, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10) 
            => $"Thread {arg0} - Cpu {Cpu} - Process {ProcessId}: {nameof(For)}";
    
        public static string For(int arg0, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10, int arg11) 
            => $"Thread {arg0} - Cpu {Cpu} - Process {ProcessId}: {nameof(For)}";
    
        public static string For(int arg0, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10, int arg11, int arg12) 
            => $"Thread {arg0} - Cpu {Cpu} - Process {ProcessId}: {nameof(For)}";
    
        public static string For(int arg0, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10, int arg11, int arg12, int arg13) 
            => $"Thread {arg0} - Cpu {Cpu} - Process {ProcessId}: {nameof(For)}";
    
        public static string For(int arg0, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10, int arg11, int arg12, int arg13, int arg14) 
            => $"Thread {arg0} - Cpu {Cpu} - Process {ProcessId}: {nameof(For)}";
    
        public static string For(int arg0, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10, int arg11, int arg12, int arg13, int arg14, int arg15) 
            => $"Thread {arg0} - Cpu {Cpu} - Process {ProcessId}: {nameof(For)}";
    
        
        [TestMethod()]
        public void ParallelForTest_1_00()
        {
            Func<int, string> target = For;

            var runner = Mpi
                .ParallelFor(0, numThreads, target, i => new(i))
                .Run().
                 Wait();

            for (var i = 0; i < numThreads; i++)
            {
                var result = runner.Results[i];
                Assert.IsTrue(result.StartsWith($"Thread {i}"), result);

            }
        }
        
        [TestMethod()]
        public void ParallelForTest_1_01()
        {
            Func<int, int, string> target = For;

            var runner = Mpi
                .ParallelFor(0, numThreads, target, i => new(i, 0))
                .Run().
                 Wait();

            for (var i = 0; i < numThreads; i++)
            {
                var result = runner.Results[i];
                Assert.IsTrue(result.StartsWith($"Thread {i}"), result);

            }
        }
        
        [TestMethod()]
        public void ParallelForTest_1_02()
        {
            Func<int, int, int, string> target = For;

            var runner = Mpi
                .ParallelFor(0, numThreads, target, i => new(i, 0, 0))
                .Run().
                 Wait();

            for (var i = 0; i < numThreads; i++)
            {
                var result = runner.Results[i];
                Assert.IsTrue(result.StartsWith($"Thread {i}"), result);

            }
        }
        
        [TestMethod()]
        public void ParallelForTest_1_03()
        {
            Func<int, int, int, int, string> target = For;

            var runner = Mpi
                .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0))
                .Run().
                 Wait();

            for (var i = 0; i < numThreads; i++)
            {
                var result = runner.Results[i];
                Assert.IsTrue(result.StartsWith($"Thread {i}"), result);

            }
        }
        
        [TestMethod()]
        public void ParallelForTest_1_04()
        {
            Func<int, int, int, int, int, string> target = For;

            var runner = Mpi
                .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0, 0))
                .Run().
                 Wait();

            for (var i = 0; i < numThreads; i++)
            {
                var result = runner.Results[i];
                Assert.IsTrue(result.StartsWith($"Thread {i}"), result);

            }
        }
        
        [TestMethod()]
        public void ParallelForTest_1_05()
        {
            Func<int, int, int, int, int, int, string> target = For;

            var runner = Mpi
                .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0, 0, 0))
                .Run().
                 Wait();

            for (var i = 0; i < numThreads; i++)
            {
                var result = runner.Results[i];
                Assert.IsTrue(result.StartsWith($"Thread {i}"), result);

            }
        }
        
        [TestMethod()]
        public void ParallelForTest_1_06()
        {
            Func<int, int, int, int, int, int, int, string> target = For;

            var runner = Mpi
                .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0))
                .Run().
                 Wait();

            for (var i = 0; i < numThreads; i++)
            {
                var result = runner.Results[i];
                Assert.IsTrue(result.StartsWith($"Thread {i}"), result);

            }
        }
        
        [TestMethod()]
        public void ParallelForTest_1_07()
        {
            Func<int, int, int, int, int, int, int, int, string> target = For;

            var runner = Mpi
                .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0))
                .Run().
                 Wait();

            for (var i = 0; i < numThreads; i++)
            {
                var result = runner.Results[i];
                Assert.IsTrue(result.StartsWith($"Thread {i}"), result);

            }
        }
        
        [TestMethod()]
        public void ParallelForTest_1_08()
        {
            Func<int, int, int, int, int, int, int, int, int, string> target = For;

            var runner = Mpi
                .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0, 0))
                .Run().
                 Wait();

            for (var i = 0; i < numThreads; i++)
            {
                var result = runner.Results[i];
                Assert.IsTrue(result.StartsWith($"Thread {i}"), result);

            }
        }
        
        [TestMethod()]
        public void ParallelForTest_1_09()
        {
            Func<int, int, int, int, int, int, int, int, int, int, string> target = For;

            var runner = Mpi
                .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0))
                .Run().
                 Wait();

            for (var i = 0; i < numThreads; i++)
            {
                var result = runner.Results[i];
                Assert.IsTrue(result.StartsWith($"Thread {i}"), result);

            }
        }
        
        [TestMethod()]
        public void ParallelForTest_1_10()
        {
            Func<int, int, int, int, int, int, int, int, int, int, int, string> target = For;

            var runner = Mpi
                .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0))
                .Run().
                 Wait();

            for (var i = 0; i < numThreads; i++)
            {
                var result = runner.Results[i];
                Assert.IsTrue(result.StartsWith($"Thread {i}"), result);

            }
        }
        
        [TestMethod()]
        public void ParallelForTest_1_11()
        {
            Func<int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

            var runner = Mpi
                .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0))
                .Run().
                 Wait();

            for (var i = 0; i < numThreads; i++)
            {
                var result = runner.Results[i];
                Assert.IsTrue(result.StartsWith($"Thread {i}"), result);

            }
        }
        
        [TestMethod()]
        public void ParallelForTest_1_12()
        {
            Func<int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

            var runner = Mpi
                .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0))
                .Run().
                 Wait();

            for (var i = 0; i < numThreads; i++)
            {
                var result = runner.Results[i];
                Assert.IsTrue(result.StartsWith($"Thread {i}"), result);

            }
        }
        
        [TestMethod()]
        public void ParallelForTest_1_13()
        {
            Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

            var runner = Mpi
                .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0))
                .Run().
                 Wait();

            for (var i = 0; i < numThreads; i++)
            {
                var result = runner.Results[i];
                Assert.IsTrue(result.StartsWith($"Thread {i}"), result);

            }
        }
        
        [TestMethod()]
        public void ParallelForTest_1_14()
        {
            Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

            var runner = Mpi
                .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0))
                .Run().
                 Wait();

            for (var i = 0; i < numThreads; i++)
            {
                var result = runner.Results[i];
                Assert.IsTrue(result.StartsWith($"Thread {i}"), result);

            }
        }
        
        [TestMethod()]
        public void ParallelForTest_1_15()
        {
            Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

            var runner = Mpi
                .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0))
                .Run().
                 Wait();

            for (var i = 0; i < numThreads; i++)
            {
                var result = runner.Results[i];
                Assert.IsTrue(result.StartsWith($"Thread {i}"), result);

            }
        }
        
        
        [TestMethod]
        public void ParallelForTest_2_00()
        {
            Func<int, string> target = For;

            var func = Mpi
                .ParallelFor(0, numThreads, target, 0);
           
           func.FunctionResultReturned += (sender, e) =>
            {
                var thread = e.ThreadIndex;
                var result = e.Result;
                Assert.IsTrue(result != null);
                Assert.IsTrue(result.StartsWith($"Thread {thread}"), result);

                var args = e.ArgProvider.ToArray().Select(i => (int)i);
                var expectedArgs = new[] { 0 };
                Assert.IsTrue(args.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

                var argList =(ArgList<int>)e.ArgProvider;
                object[] argListArray = argList;
                var argListTypedArray = argListArray.Select(x => (int)x);
                Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

       

            };
            func.Run().
                 Wait();    

        }
        
        [TestMethod]
        public void ParallelForTest_2_01()
        {
            Func<int, int, string> target = For;

            var func = Mpi
                .ParallelFor(0, numThreads, target, 0, 1);
           
           func.FunctionResultReturned += (sender, e) =>
            {
                var thread = e.ThreadIndex;
                var result = e.Result;
                Assert.IsTrue(result != null);
                Assert.IsTrue(result.StartsWith($"Thread {thread}"), result);

                var args = e.ArgProvider.ToArray().Select(i => (int)i);
                var expectedArgs = new[] { 0, 1 };
                Assert.IsTrue(args.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

                var argList =(ArgList<int, int>)e.ArgProvider;
                object[] argListArray = argList;
                var argListTypedArray = argListArray.Select(x => (int)x);
                Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

       

            };
            func.Run().
                 Wait();    

        }
        
        [TestMethod]
        public void ParallelForTest_2_02()
        {
            Func<int, int, int, string> target = For;

            var func = Mpi
                .ParallelFor(0, numThreads, target, 0, 1, 2);
           
           func.FunctionResultReturned += (sender, e) =>
            {
                var thread = e.ThreadIndex;
                var result = e.Result;
                Assert.IsTrue(result != null);
                Assert.IsTrue(result.StartsWith($"Thread {thread}"), result);

                var args = e.ArgProvider.ToArray().Select(i => (int)i);
                var expectedArgs = new[] { 0, 1, 2 };
                Assert.IsTrue(args.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

                var argList =(ArgList<int, int, int>)e.ArgProvider;
                object[] argListArray = argList;
                var argListTypedArray = argListArray.Select(x => (int)x);
                Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

       

            };
            func.Run().
                 Wait();    

        }
        
        [TestMethod]
        public void ParallelForTest_2_03()
        {
            Func<int, int, int, int, string> target = For;

            var func = Mpi
                .ParallelFor(0, numThreads, target, 0, 1, 2, 3);
           
           func.FunctionResultReturned += (sender, e) =>
            {
                var thread = e.ThreadIndex;
                var result = e.Result;
                Assert.IsTrue(result != null);
                Assert.IsTrue(result.StartsWith($"Thread {thread}"), result);

                var args = e.ArgProvider.ToArray().Select(i => (int)i);
                var expectedArgs = new[] { 0, 1, 2, 3 };
                Assert.IsTrue(args.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

                var argList =(ArgList<int, int, int, int>)e.ArgProvider;
                object[] argListArray = argList;
                var argListTypedArray = argListArray.Select(x => (int)x);
                Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

       

            };
            func.Run().
                 Wait();    

        }
        
        [TestMethod]
        public void ParallelForTest_2_04()
        {
            Func<int, int, int, int, int, string> target = For;

            var func = Mpi
                .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4);
           
           func.FunctionResultReturned += (sender, e) =>
            {
                var thread = e.ThreadIndex;
                var result = e.Result;
                Assert.IsTrue(result != null);
                Assert.IsTrue(result.StartsWith($"Thread {thread}"), result);

                var args = e.ArgProvider.ToArray().Select(i => (int)i);
                var expectedArgs = new[] { 0, 1, 2, 3, 4 };
                Assert.IsTrue(args.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

                var argList =(ArgList<int, int, int, int, int>)e.ArgProvider;
                object[] argListArray = argList;
                var argListTypedArray = argListArray.Select(x => (int)x);
                Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

       

            };
            func.Run().
                 Wait();    

        }
        
        [TestMethod]
        public void ParallelForTest_2_05()
        {
            Func<int, int, int, int, int, int, string> target = For;

            var func = Mpi
                .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5);
           
           func.FunctionResultReturned += (sender, e) =>
            {
                var thread = e.ThreadIndex;
                var result = e.Result;
                Assert.IsTrue(result != null);
                Assert.IsTrue(result.StartsWith($"Thread {thread}"), result);

                var args = e.ArgProvider.ToArray().Select(i => (int)i);
                var expectedArgs = new[] { 0, 1, 2, 3, 4, 5 };
                Assert.IsTrue(args.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

                var argList =(ArgList<int, int, int, int, int, int>)e.ArgProvider;
                object[] argListArray = argList;
                var argListTypedArray = argListArray.Select(x => (int)x);
                Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

       

            };
            func.Run().
                 Wait();    

        }
        
        [TestMethod]
        public void ParallelForTest_2_06()
        {
            Func<int, int, int, int, int, int, int, string> target = For;

            var func = Mpi
                .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6);
           
           func.FunctionResultReturned += (sender, e) =>
            {
                var thread = e.ThreadIndex;
                var result = e.Result;
                Assert.IsTrue(result != null);
                Assert.IsTrue(result.StartsWith($"Thread {thread}"), result);

                var args = e.ArgProvider.ToArray().Select(i => (int)i);
                var expectedArgs = new[] { 0, 1, 2, 3, 4, 5, 6 };
                Assert.IsTrue(args.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

                var argList =(ArgList<int, int, int, int, int, int, int>)e.ArgProvider;
                object[] argListArray = argList;
                var argListTypedArray = argListArray.Select(x => (int)x);
                Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

       

            };
            func.Run().
                 Wait();    

        }
        
        [TestMethod]
        public void ParallelForTest_2_07()
        {
            Func<int, int, int, int, int, int, int, int, string> target = For;

            var func = Mpi
                .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7);
           
           func.FunctionResultReturned += (sender, e) =>
            {
                var thread = e.ThreadIndex;
                var result = e.Result;
                Assert.IsTrue(result != null);
                Assert.IsTrue(result.StartsWith($"Thread {thread}"), result);

                var args = e.ArgProvider.ToArray().Select(i => (int)i);
                var expectedArgs = new[] { 0, 1, 2, 3, 4, 5, 6, 7 };
                Assert.IsTrue(args.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

                var argList =(ArgList<int, int, int, int, int, int, int, int>)e.ArgProvider;
                object[] argListArray = argList;
                var argListTypedArray = argListArray.Select(x => (int)x);
                Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

       

            };
            func.Run().
                 Wait();    

        }
        
        [TestMethod]
        public void ParallelForTest_2_08()
        {
            Func<int, int, int, int, int, int, int, int, int, string> target = For;

            var func = Mpi
                .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8);
           
           func.FunctionResultReturned += (sender, e) =>
            {
                var thread = e.ThreadIndex;
                var result = e.Result;
                Assert.IsTrue(result != null);
                Assert.IsTrue(result.StartsWith($"Thread {thread}"), result);

                var args = e.ArgProvider.ToArray().Select(i => (int)i);
                var expectedArgs = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
                Assert.IsTrue(args.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

                var argList =(ArgList<int, int, int, int, int, int, int, int, int>)e.ArgProvider;
                object[] argListArray = argList;
                var argListTypedArray = argListArray.Select(x => (int)x);
                Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

       

            };
            func.Run().
                 Wait();    

        }
        
        [TestMethod]
        public void ParallelForTest_2_09()
        {
            Func<int, int, int, int, int, int, int, int, int, int, string> target = For;

            var func = Mpi
                .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9);
           
           func.FunctionResultReturned += (sender, e) =>
            {
                var thread = e.ThreadIndex;
                var result = e.Result;
                Assert.IsTrue(result != null);
                Assert.IsTrue(result.StartsWith($"Thread {thread}"), result);

                var args = e.ArgProvider.ToArray().Select(i => (int)i);
                var expectedArgs = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                Assert.IsTrue(args.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

                var argList =(ArgList<int, int, int, int, int, int, int, int, int, int>)e.ArgProvider;
                object[] argListArray = argList;
                var argListTypedArray = argListArray.Select(x => (int)x);
                Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

       

            };
            func.Run().
                 Wait();    

        }
        
        [TestMethod]
        public void ParallelForTest_2_10()
        {
            Func<int, int, int, int, int, int, int, int, int, int, int, string> target = For;

            var func = Mpi
                .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
           
           func.FunctionResultReturned += (sender, e) =>
            {
                var thread = e.ThreadIndex;
                var result = e.Result;
                Assert.IsTrue(result != null);
                Assert.IsTrue(result.StartsWith($"Thread {thread}"), result);

                var args = e.ArgProvider.ToArray().Select(i => (int)i);
                var expectedArgs = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                Assert.IsTrue(args.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

                var argList =(ArgList<int, int, int, int, int, int, int, int, int, int, int>)e.ArgProvider;
                object[] argListArray = argList;
                var argListTypedArray = argListArray.Select(x => (int)x);
                Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

       

            };
            func.Run().
                 Wait();    

        }
        
        [TestMethod]
        public void ParallelForTest_2_11()
        {
            Func<int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

            var func = Mpi
                .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
           
           func.FunctionResultReturned += (sender, e) =>
            {
                var thread = e.ThreadIndex;
                var result = e.Result;
                Assert.IsTrue(result != null);
                Assert.IsTrue(result.StartsWith($"Thread {thread}"), result);

                var args = e.ArgProvider.ToArray().Select(i => (int)i);
                var expectedArgs = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
                Assert.IsTrue(args.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

                var argList =(ArgList<int, int, int, int, int, int, int, int, int, int, int, int>)e.ArgProvider;
                object[] argListArray = argList;
                var argListTypedArray = argListArray.Select(x => (int)x);
                Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

       

            };
            func.Run().
                 Wait();    

        }
        
        [TestMethod]
        public void ParallelForTest_2_12()
        {
            Func<int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

            var func = Mpi
                .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
           
           func.FunctionResultReturned += (sender, e) =>
            {
                var thread = e.ThreadIndex;
                var result = e.Result;
                Assert.IsTrue(result != null);
                Assert.IsTrue(result.StartsWith($"Thread {thread}"), result);

                var args = e.ArgProvider.ToArray().Select(i => (int)i);
                var expectedArgs = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
                Assert.IsTrue(args.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

                var argList =(ArgList<int, int, int, int, int, int, int, int, int, int, int, int, int>)e.ArgProvider;
                object[] argListArray = argList;
                var argListTypedArray = argListArray.Select(x => (int)x);
                Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

       

            };
            func.Run().
                 Wait();    

        }
        
        [TestMethod]
        public void ParallelForTest_2_13()
        {
            Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

            var func = Mpi
                .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
           
           func.FunctionResultReturned += (sender, e) =>
            {
                var thread = e.ThreadIndex;
                var result = e.Result;
                Assert.IsTrue(result != null);
                Assert.IsTrue(result.StartsWith($"Thread {thread}"), result);

                var args = e.ArgProvider.ToArray().Select(i => (int)i);
                var expectedArgs = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
                Assert.IsTrue(args.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

                var argList =(ArgList<int, int, int, int, int, int, int, int, int, int, int, int, int, int>)e.ArgProvider;
                object[] argListArray = argList;
                var argListTypedArray = argListArray.Select(x => (int)x);
                Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

       

            };
            func.Run().
                 Wait();    

        }
        
        [TestMethod]
        public void ParallelForTest_2_14()
        {
            Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

            var func = Mpi
                .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);
           
           func.FunctionResultReturned += (sender, e) =>
            {
                var thread = e.ThreadIndex;
                var result = e.Result;
                Assert.IsTrue(result != null);
                Assert.IsTrue(result.StartsWith($"Thread {thread}"), result);

                var args = e.ArgProvider.ToArray().Select(i => (int)i);
                var expectedArgs = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
                Assert.IsTrue(args.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

                var argList =(ArgList<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>)e.ArgProvider;
                object[] argListArray = argList;
                var argListTypedArray = argListArray.Select(x => (int)x);
                Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

       

            };
            func.Run().
                 Wait();    

        }
        
        [TestMethod]
        public void ParallelForTest_2_15()
        {
            Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

            var func = Mpi
                .ParallelFor(0, numThreads, target, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
           
           func.FunctionResultReturned += (sender, e) =>
            {
                var thread = e.ThreadIndex;
                var result = e.Result;
                Assert.IsTrue(result != null);
                Assert.IsTrue(result.StartsWith($"Thread {thread}"), result);

                var args = e.ArgProvider.ToArray().Select(i => (int)i);
                var expectedArgs = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
                Assert.IsTrue(args.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

                var argList =(ArgList<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>)e.ArgProvider;
                object[] argListArray = argList;
                var argListTypedArray = argListArray.Select(x => (int)x);
                Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                    $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                );

       

            };
            func.Run().
                 Wait();    

        }
        
    }

}