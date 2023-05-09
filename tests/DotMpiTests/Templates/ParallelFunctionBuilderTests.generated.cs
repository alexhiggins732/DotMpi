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
        
        public partial class ParallelFunctionBuilderTests
        {
            
            //[TestMethod()]
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
            
            //[TestMethod()]
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
            
            //[TestMethod()]
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
            
            //[TestMethod()]
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
            
            //[TestMethod()]
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
            
            //[TestMethod()]
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
            
            //[TestMethod()]
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
            
            //[TestMethod()]
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
            
            //[TestMethod()]
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
            
            //[TestMethod()]
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
            
            //[TestMethod()]
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
            
            //[TestMethod()]
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
            
            //[TestMethod()]
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
            
            //[TestMethod()]
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
            
            //[TestMethod()]
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
            
            //[TestMethod()]
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
                    .ParallelFor(0, numThreads, target, i => new(i))
                    .Build();
           
                var invoked = new FunctionInvokedEventArgs<string>[numThreads];
                var results = new FunctionResultEventArgs<string>[numThreads];

                func.FunctionInvoked += (sender, e) =>
                {
                    Assert.IsNotNull(e.FunctionCallData);

                    var callData = e.FunctionCallData;
                    
                    var callDataBytes= (byte[])callData;
                    var callDataFromBytes = (RemoteCallData)callDataBytes;

                    var callDataJson = JsonConvert.SerializeObject(callData);
                    var callDataFromBytesJson = JsonConvert.SerializeObject(callDataFromBytes);

                    Assert.AreEqual(callDataJson, callDataFromBytesJson);
                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.PipeName);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    Assert.IsNotNull(e.ArgProvider);
                    invoked[e.ThreadIndex] = e;
                };


                func.FunctionResultReturned += (sender, e) =>
                {
                    var thread = e.ThreadIndex;
                    var result = e.Result;
                    Assert.IsTrue(result != null);
                   

                    var args = e.ArgProvider.ToArray().Select(i => (int)i);
                    var expectedArgs = new[] { e.ThreadIndex};
                    Assert.IsTrue(args.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    var argList =(ArgList<int>)e.ArgProvider;
                    object[] argListArray = argList;
                    var argListTypedArray = argListArray.Select(x => (int)x);
                    Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.Result);
                    Assert.IsNotNull(e.SerializedResult);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    results[e.ThreadIndex] = e;

                };

                
                var debugEnabled = MpiRunner.Logger.DebugEnabled;
                MpiRunner.Logger.DebugEnabled = true;

                  
                var runner = func.Run().Wait(TimeSpan.FromSeconds(10));    

                
                MpiRunner.Logger.DebugEnabled = debugEnabled;

                
                for(var i=0; i<numThreads; i++)
                {
                    Assert.AreEqual(invoked[i].PipeName, results[i].PipeName );
                    Assert.AreEqual(invoked[i].ProcessId, results[i].ProcessId);
                    Assert.AreEqual(invoked[i].ThreadIndex, results[i].ThreadIndex);

                    var invokedArgs = invoked[i].ArgProvider.ToArray().Select(x => (int)i);
                    var recievedArgs = results[i].ArgProvider.ToArray().Select(x => (int)i);
                    Assert.IsTrue(invokedArgs.SequenceEqual(recievedArgs));

                    var result = runner.Results[i];
                    Assert.IsTrue(result.StartsWith($"Thread {i}"), result);
                }
            }
            
            [TestMethod]
            public void ParallelForTest_2_01()
            {
                Func<int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, i => new(i, 0))
                    .Build();
           
                var invoked = new FunctionInvokedEventArgs<string>[numThreads];
                var results = new FunctionResultEventArgs<string>[numThreads];

                func.FunctionInvoked += (sender, e) =>
                {
                    Assert.IsNotNull(e.FunctionCallData);

                    var callData = e.FunctionCallData;
                    
                    var callDataBytes= (byte[])callData;
                    var callDataFromBytes = (RemoteCallData)callDataBytes;

                    var callDataJson = JsonConvert.SerializeObject(callData);
                    var callDataFromBytesJson = JsonConvert.SerializeObject(callDataFromBytes);

                    Assert.AreEqual(callDataJson, callDataFromBytesJson);
                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.PipeName);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    Assert.IsNotNull(e.ArgProvider);
                    invoked[e.ThreadIndex] = e;
                };


                func.FunctionResultReturned += (sender, e) =>
                {
                    var thread = e.ThreadIndex;
                    var result = e.Result;
                    Assert.IsTrue(result != null);
                   

                    var args = e.ArgProvider.ToArray().Select(i => (int)i);
                    var expectedArgs = new[] { e.ThreadIndex, 0};
                    Assert.IsTrue(args.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    var argList =(ArgList<int, int>)e.ArgProvider;
                    object[] argListArray = argList;
                    var argListTypedArray = argListArray.Select(x => (int)x);
                    Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.Result);
                    Assert.IsNotNull(e.SerializedResult);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    results[e.ThreadIndex] = e;

                };

                  
                var runner = func.Run().Wait(TimeSpan.FromSeconds(10));    

                
                for(var i=0; i<numThreads; i++)
                {
                    Assert.AreEqual(invoked[i].PipeName, results[i].PipeName );
                    Assert.AreEqual(invoked[i].ProcessId, results[i].ProcessId);
                    Assert.AreEqual(invoked[i].ThreadIndex, results[i].ThreadIndex);

                    var invokedArgs = invoked[i].ArgProvider.ToArray().Select(x => (int)i);
                    var recievedArgs = results[i].ArgProvider.ToArray().Select(x => (int)i);
                    Assert.IsTrue(invokedArgs.SequenceEqual(recievedArgs));

                    var result = runner.Results[i];
                    Assert.IsTrue(result.StartsWith($"Thread {i}"), result);
                }
            }
            
            [TestMethod]
            public void ParallelForTest_2_02()
            {
                Func<int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, i => new(i, 0, 0))
                    .Build();
           
                var invoked = new FunctionInvokedEventArgs<string>[numThreads];
                var results = new FunctionResultEventArgs<string>[numThreads];

                func.FunctionInvoked += (sender, e) =>
                {
                    Assert.IsNotNull(e.FunctionCallData);

                    var callData = e.FunctionCallData;
                    
                    var callDataBytes= (byte[])callData;
                    var callDataFromBytes = (RemoteCallData)callDataBytes;

                    var callDataJson = JsonConvert.SerializeObject(callData);
                    var callDataFromBytesJson = JsonConvert.SerializeObject(callDataFromBytes);

                    Assert.AreEqual(callDataJson, callDataFromBytesJson);
                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.PipeName);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    Assert.IsNotNull(e.ArgProvider);
                    invoked[e.ThreadIndex] = e;
                };


                func.FunctionResultReturned += (sender, e) =>
                {
                    var thread = e.ThreadIndex;
                    var result = e.Result;
                    Assert.IsTrue(result != null);
                   

                    var args = e.ArgProvider.ToArray().Select(i => (int)i);
                    var expectedArgs = new[] { e.ThreadIndex, 0, 0};
                    Assert.IsTrue(args.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    var argList =(ArgList<int, int, int>)e.ArgProvider;
                    object[] argListArray = argList;
                    var argListTypedArray = argListArray.Select(x => (int)x);
                    Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.Result);
                    Assert.IsNotNull(e.SerializedResult);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    results[e.ThreadIndex] = e;

                };

                  
                var runner = func.Run().Wait(TimeSpan.FromSeconds(10));    

                
                for(var i=0; i<numThreads; i++)
                {
                    Assert.AreEqual(invoked[i].PipeName, results[i].PipeName );
                    Assert.AreEqual(invoked[i].ProcessId, results[i].ProcessId);
                    Assert.AreEqual(invoked[i].ThreadIndex, results[i].ThreadIndex);

                    var invokedArgs = invoked[i].ArgProvider.ToArray().Select(x => (int)i);
                    var recievedArgs = results[i].ArgProvider.ToArray().Select(x => (int)i);
                    Assert.IsTrue(invokedArgs.SequenceEqual(recievedArgs));

                    var result = runner.Results[i];
                    Assert.IsTrue(result.StartsWith($"Thread {i}"), result);
                }
            }
            
            [TestMethod]
            public void ParallelForTest_2_03()
            {
                Func<int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0))
                    .Build();
           
                var invoked = new FunctionInvokedEventArgs<string>[numThreads];
                var results = new FunctionResultEventArgs<string>[numThreads];

                func.FunctionInvoked += (sender, e) =>
                {
                    Assert.IsNotNull(e.FunctionCallData);

                    var callData = e.FunctionCallData;
                    
                    var callDataBytes= (byte[])callData;
                    var callDataFromBytes = (RemoteCallData)callDataBytes;

                    var callDataJson = JsonConvert.SerializeObject(callData);
                    var callDataFromBytesJson = JsonConvert.SerializeObject(callDataFromBytes);

                    Assert.AreEqual(callDataJson, callDataFromBytesJson);
                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.PipeName);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    Assert.IsNotNull(e.ArgProvider);
                    invoked[e.ThreadIndex] = e;
                };


                func.FunctionResultReturned += (sender, e) =>
                {
                    var thread = e.ThreadIndex;
                    var result = e.Result;
                    Assert.IsTrue(result != null);
                   

                    var args = e.ArgProvider.ToArray().Select(i => (int)i);
                    var expectedArgs = new[] { e.ThreadIndex, 0, 0, 0};
                    Assert.IsTrue(args.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    var argList =(ArgList<int, int, int, int>)e.ArgProvider;
                    object[] argListArray = argList;
                    var argListTypedArray = argListArray.Select(x => (int)x);
                    Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.Result);
                    Assert.IsNotNull(e.SerializedResult);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    results[e.ThreadIndex] = e;

                };

                  
                var runner = func.Run().Wait(TimeSpan.FromSeconds(10));    

                
                for(var i=0; i<numThreads; i++)
                {
                    Assert.AreEqual(invoked[i].PipeName, results[i].PipeName );
                    Assert.AreEqual(invoked[i].ProcessId, results[i].ProcessId);
                    Assert.AreEqual(invoked[i].ThreadIndex, results[i].ThreadIndex);

                    var invokedArgs = invoked[i].ArgProvider.ToArray().Select(x => (int)i);
                    var recievedArgs = results[i].ArgProvider.ToArray().Select(x => (int)i);
                    Assert.IsTrue(invokedArgs.SequenceEqual(recievedArgs));

                    var result = runner.Results[i];
                    Assert.IsTrue(result.StartsWith($"Thread {i}"), result);
                }
            }
            
            [TestMethod]
            public void ParallelForTest_2_04()
            {
                Func<int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0, 0))
                    .Build();
           
                var invoked = new FunctionInvokedEventArgs<string>[numThreads];
                var results = new FunctionResultEventArgs<string>[numThreads];

                func.FunctionInvoked += (sender, e) =>
                {
                    Assert.IsNotNull(e.FunctionCallData);

                    var callData = e.FunctionCallData;
                    
                    var callDataBytes= (byte[])callData;
                    var callDataFromBytes = (RemoteCallData)callDataBytes;

                    var callDataJson = JsonConvert.SerializeObject(callData);
                    var callDataFromBytesJson = JsonConvert.SerializeObject(callDataFromBytes);

                    Assert.AreEqual(callDataJson, callDataFromBytesJson);
                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.PipeName);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    Assert.IsNotNull(e.ArgProvider);
                    invoked[e.ThreadIndex] = e;
                };


                func.FunctionResultReturned += (sender, e) =>
                {
                    var thread = e.ThreadIndex;
                    var result = e.Result;
                    Assert.IsTrue(result != null);
                   

                    var args = e.ArgProvider.ToArray().Select(i => (int)i);
                    var expectedArgs = new[] { e.ThreadIndex, 0, 0, 0, 0};
                    Assert.IsTrue(args.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    var argList =(ArgList<int, int, int, int, int>)e.ArgProvider;
                    object[] argListArray = argList;
                    var argListTypedArray = argListArray.Select(x => (int)x);
                    Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.Result);
                    Assert.IsNotNull(e.SerializedResult);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    results[e.ThreadIndex] = e;

                };

                  
                var runner = func.Run().Wait(TimeSpan.FromSeconds(10));    

                
                for(var i=0; i<numThreads; i++)
                {
                    Assert.AreEqual(invoked[i].PipeName, results[i].PipeName );
                    Assert.AreEqual(invoked[i].ProcessId, results[i].ProcessId);
                    Assert.AreEqual(invoked[i].ThreadIndex, results[i].ThreadIndex);

                    var invokedArgs = invoked[i].ArgProvider.ToArray().Select(x => (int)i);
                    var recievedArgs = results[i].ArgProvider.ToArray().Select(x => (int)i);
                    Assert.IsTrue(invokedArgs.SequenceEqual(recievedArgs));

                    var result = runner.Results[i];
                    Assert.IsTrue(result.StartsWith($"Thread {i}"), result);
                }
            }
            
            [TestMethod]
            public void ParallelForTest_2_05()
            {
                Func<int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0, 0, 0))
                    .Build();
           
                var invoked = new FunctionInvokedEventArgs<string>[numThreads];
                var results = new FunctionResultEventArgs<string>[numThreads];

                func.FunctionInvoked += (sender, e) =>
                {
                    Assert.IsNotNull(e.FunctionCallData);

                    var callData = e.FunctionCallData;
                    
                    var callDataBytes= (byte[])callData;
                    var callDataFromBytes = (RemoteCallData)callDataBytes;

                    var callDataJson = JsonConvert.SerializeObject(callData);
                    var callDataFromBytesJson = JsonConvert.SerializeObject(callDataFromBytes);

                    Assert.AreEqual(callDataJson, callDataFromBytesJson);
                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.PipeName);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    Assert.IsNotNull(e.ArgProvider);
                    invoked[e.ThreadIndex] = e;
                };


                func.FunctionResultReturned += (sender, e) =>
                {
                    var thread = e.ThreadIndex;
                    var result = e.Result;
                    Assert.IsTrue(result != null);
                   

                    var args = e.ArgProvider.ToArray().Select(i => (int)i);
                    var expectedArgs = new[] { e.ThreadIndex, 0, 0, 0, 0, 0};
                    Assert.IsTrue(args.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    var argList =(ArgList<int, int, int, int, int, int>)e.ArgProvider;
                    object[] argListArray = argList;
                    var argListTypedArray = argListArray.Select(x => (int)x);
                    Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.Result);
                    Assert.IsNotNull(e.SerializedResult);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    results[e.ThreadIndex] = e;

                };

                  
                var runner = func.Run().Wait(TimeSpan.FromSeconds(10));    

                
                for(var i=0; i<numThreads; i++)
                {
                    Assert.AreEqual(invoked[i].PipeName, results[i].PipeName );
                    Assert.AreEqual(invoked[i].ProcessId, results[i].ProcessId);
                    Assert.AreEqual(invoked[i].ThreadIndex, results[i].ThreadIndex);

                    var invokedArgs = invoked[i].ArgProvider.ToArray().Select(x => (int)i);
                    var recievedArgs = results[i].ArgProvider.ToArray().Select(x => (int)i);
                    Assert.IsTrue(invokedArgs.SequenceEqual(recievedArgs));

                    var result = runner.Results[i];
                    Assert.IsTrue(result.StartsWith($"Thread {i}"), result);
                }
            }
            
            [TestMethod]
            public void ParallelForTest_2_06()
            {
                Func<int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0))
                    .Build();
           
                var invoked = new FunctionInvokedEventArgs<string>[numThreads];
                var results = new FunctionResultEventArgs<string>[numThreads];

                func.FunctionInvoked += (sender, e) =>
                {
                    Assert.IsNotNull(e.FunctionCallData);

                    var callData = e.FunctionCallData;
                    
                    var callDataBytes= (byte[])callData;
                    var callDataFromBytes = (RemoteCallData)callDataBytes;

                    var callDataJson = JsonConvert.SerializeObject(callData);
                    var callDataFromBytesJson = JsonConvert.SerializeObject(callDataFromBytes);

                    Assert.AreEqual(callDataJson, callDataFromBytesJson);
                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.PipeName);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    Assert.IsNotNull(e.ArgProvider);
                    invoked[e.ThreadIndex] = e;
                };


                func.FunctionResultReturned += (sender, e) =>
                {
                    var thread = e.ThreadIndex;
                    var result = e.Result;
                    Assert.IsTrue(result != null);
                   

                    var args = e.ArgProvider.ToArray().Select(i => (int)i);
                    var expectedArgs = new[] { e.ThreadIndex, 0, 0, 0, 0, 0, 0};
                    Assert.IsTrue(args.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    var argList =(ArgList<int, int, int, int, int, int, int>)e.ArgProvider;
                    object[] argListArray = argList;
                    var argListTypedArray = argListArray.Select(x => (int)x);
                    Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.Result);
                    Assert.IsNotNull(e.SerializedResult);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    results[e.ThreadIndex] = e;

                };

                  
                var runner = func.Run().Wait(TimeSpan.FromSeconds(10));    

                
                for(var i=0; i<numThreads; i++)
                {
                    Assert.AreEqual(invoked[i].PipeName, results[i].PipeName );
                    Assert.AreEqual(invoked[i].ProcessId, results[i].ProcessId);
                    Assert.AreEqual(invoked[i].ThreadIndex, results[i].ThreadIndex);

                    var invokedArgs = invoked[i].ArgProvider.ToArray().Select(x => (int)i);
                    var recievedArgs = results[i].ArgProvider.ToArray().Select(x => (int)i);
                    Assert.IsTrue(invokedArgs.SequenceEqual(recievedArgs));

                    var result = runner.Results[i];
                    Assert.IsTrue(result.StartsWith($"Thread {i}"), result);
                }
            }
            
            [TestMethod]
            public void ParallelForTest_2_07()
            {
                Func<int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0))
                    .Build();
           
                var invoked = new FunctionInvokedEventArgs<string>[numThreads];
                var results = new FunctionResultEventArgs<string>[numThreads];

                func.FunctionInvoked += (sender, e) =>
                {
                    Assert.IsNotNull(e.FunctionCallData);

                    var callData = e.FunctionCallData;
                    
                    var callDataBytes= (byte[])callData;
                    var callDataFromBytes = (RemoteCallData)callDataBytes;

                    var callDataJson = JsonConvert.SerializeObject(callData);
                    var callDataFromBytesJson = JsonConvert.SerializeObject(callDataFromBytes);

                    Assert.AreEqual(callDataJson, callDataFromBytesJson);
                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.PipeName);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    Assert.IsNotNull(e.ArgProvider);
                    invoked[e.ThreadIndex] = e;
                };


                func.FunctionResultReturned += (sender, e) =>
                {
                    var thread = e.ThreadIndex;
                    var result = e.Result;
                    Assert.IsTrue(result != null);
                   

                    var args = e.ArgProvider.ToArray().Select(i => (int)i);
                    var expectedArgs = new[] { e.ThreadIndex, 0, 0, 0, 0, 0, 0, 0};
                    Assert.IsTrue(args.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    var argList =(ArgList<int, int, int, int, int, int, int, int>)e.ArgProvider;
                    object[] argListArray = argList;
                    var argListTypedArray = argListArray.Select(x => (int)x);
                    Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.Result);
                    Assert.IsNotNull(e.SerializedResult);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    results[e.ThreadIndex] = e;

                };

                  
                var runner = func.Run().Wait(TimeSpan.FromSeconds(10));    

                
                for(var i=0; i<numThreads; i++)
                {
                    Assert.AreEqual(invoked[i].PipeName, results[i].PipeName );
                    Assert.AreEqual(invoked[i].ProcessId, results[i].ProcessId);
                    Assert.AreEqual(invoked[i].ThreadIndex, results[i].ThreadIndex);

                    var invokedArgs = invoked[i].ArgProvider.ToArray().Select(x => (int)i);
                    var recievedArgs = results[i].ArgProvider.ToArray().Select(x => (int)i);
                    Assert.IsTrue(invokedArgs.SequenceEqual(recievedArgs));

                    var result = runner.Results[i];
                    Assert.IsTrue(result.StartsWith($"Thread {i}"), result);
                }
            }
            
            [TestMethod]
            public void ParallelForTest_2_08()
            {
                Func<int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0, 0))
                    .Build();
           
                var invoked = new FunctionInvokedEventArgs<string>[numThreads];
                var results = new FunctionResultEventArgs<string>[numThreads];

                func.FunctionInvoked += (sender, e) =>
                {
                    Assert.IsNotNull(e.FunctionCallData);

                    var callData = e.FunctionCallData;
                    
                    var callDataBytes= (byte[])callData;
                    var callDataFromBytes = (RemoteCallData)callDataBytes;

                    var callDataJson = JsonConvert.SerializeObject(callData);
                    var callDataFromBytesJson = JsonConvert.SerializeObject(callDataFromBytes);

                    Assert.AreEqual(callDataJson, callDataFromBytesJson);
                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.PipeName);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    Assert.IsNotNull(e.ArgProvider);
                    invoked[e.ThreadIndex] = e;
                };


                func.FunctionResultReturned += (sender, e) =>
                {
                    var thread = e.ThreadIndex;
                    var result = e.Result;
                    Assert.IsTrue(result != null);
                   

                    var args = e.ArgProvider.ToArray().Select(i => (int)i);
                    var expectedArgs = new[] { e.ThreadIndex, 0, 0, 0, 0, 0, 0, 0, 0};
                    Assert.IsTrue(args.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    var argList =(ArgList<int, int, int, int, int, int, int, int, int>)e.ArgProvider;
                    object[] argListArray = argList;
                    var argListTypedArray = argListArray.Select(x => (int)x);
                    Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.Result);
                    Assert.IsNotNull(e.SerializedResult);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    results[e.ThreadIndex] = e;

                };

                  
                var runner = func.Run().Wait(TimeSpan.FromSeconds(10));    

                
                for(var i=0; i<numThreads; i++)
                {
                    Assert.AreEqual(invoked[i].PipeName, results[i].PipeName );
                    Assert.AreEqual(invoked[i].ProcessId, results[i].ProcessId);
                    Assert.AreEqual(invoked[i].ThreadIndex, results[i].ThreadIndex);

                    var invokedArgs = invoked[i].ArgProvider.ToArray().Select(x => (int)i);
                    var recievedArgs = results[i].ArgProvider.ToArray().Select(x => (int)i);
                    Assert.IsTrue(invokedArgs.SequenceEqual(recievedArgs));

                    var result = runner.Results[i];
                    Assert.IsTrue(result.StartsWith($"Thread {i}"), result);
                }
            }
            
            [TestMethod]
            public void ParallelForTest_2_09()
            {
                Func<int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0))
                    .Build();
           
                var invoked = new FunctionInvokedEventArgs<string>[numThreads];
                var results = new FunctionResultEventArgs<string>[numThreads];

                func.FunctionInvoked += (sender, e) =>
                {
                    Assert.IsNotNull(e.FunctionCallData);

                    var callData = e.FunctionCallData;
                    
                    var callDataBytes= (byte[])callData;
                    var callDataFromBytes = (RemoteCallData)callDataBytes;

                    var callDataJson = JsonConvert.SerializeObject(callData);
                    var callDataFromBytesJson = JsonConvert.SerializeObject(callDataFromBytes);

                    Assert.AreEqual(callDataJson, callDataFromBytesJson);
                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.PipeName);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    Assert.IsNotNull(e.ArgProvider);
                    invoked[e.ThreadIndex] = e;
                };


                func.FunctionResultReturned += (sender, e) =>
                {
                    var thread = e.ThreadIndex;
                    var result = e.Result;
                    Assert.IsTrue(result != null);
                   

                    var args = e.ArgProvider.ToArray().Select(i => (int)i);
                    var expectedArgs = new[] { e.ThreadIndex, 0, 0, 0, 0, 0, 0, 0, 0, 0};
                    Assert.IsTrue(args.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    var argList =(ArgList<int, int, int, int, int, int, int, int, int, int>)e.ArgProvider;
                    object[] argListArray = argList;
                    var argListTypedArray = argListArray.Select(x => (int)x);
                    Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.Result);
                    Assert.IsNotNull(e.SerializedResult);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    results[e.ThreadIndex] = e;

                };

                  
                var runner = func.Run().Wait(TimeSpan.FromSeconds(10));    

                
                for(var i=0; i<numThreads; i++)
                {
                    Assert.AreEqual(invoked[i].PipeName, results[i].PipeName );
                    Assert.AreEqual(invoked[i].ProcessId, results[i].ProcessId);
                    Assert.AreEqual(invoked[i].ThreadIndex, results[i].ThreadIndex);

                    var invokedArgs = invoked[i].ArgProvider.ToArray().Select(x => (int)i);
                    var recievedArgs = results[i].ArgProvider.ToArray().Select(x => (int)i);
                    Assert.IsTrue(invokedArgs.SequenceEqual(recievedArgs));

                    var result = runner.Results[i];
                    Assert.IsTrue(result.StartsWith($"Thread {i}"), result);
                }
            }
            
            [TestMethod]
            public void ParallelForTest_2_10()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0))
                    .Build();
           
                var invoked = new FunctionInvokedEventArgs<string>[numThreads];
                var results = new FunctionResultEventArgs<string>[numThreads];

                func.FunctionInvoked += (sender, e) =>
                {
                    Assert.IsNotNull(e.FunctionCallData);

                    var callData = e.FunctionCallData;
                    
                    var callDataBytes= (byte[])callData;
                    var callDataFromBytes = (RemoteCallData)callDataBytes;

                    var callDataJson = JsonConvert.SerializeObject(callData);
                    var callDataFromBytesJson = JsonConvert.SerializeObject(callDataFromBytes);

                    Assert.AreEqual(callDataJson, callDataFromBytesJson);
                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.PipeName);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    Assert.IsNotNull(e.ArgProvider);
                    invoked[e.ThreadIndex] = e;
                };


                func.FunctionResultReturned += (sender, e) =>
                {
                    var thread = e.ThreadIndex;
                    var result = e.Result;
                    Assert.IsTrue(result != null);
                   

                    var args = e.ArgProvider.ToArray().Select(i => (int)i);
                    var expectedArgs = new[] { e.ThreadIndex, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
                    Assert.IsTrue(args.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    var argList =(ArgList<int, int, int, int, int, int, int, int, int, int, int>)e.ArgProvider;
                    object[] argListArray = argList;
                    var argListTypedArray = argListArray.Select(x => (int)x);
                    Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.Result);
                    Assert.IsNotNull(e.SerializedResult);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    results[e.ThreadIndex] = e;

                };

                  
                var runner = func.Run().Wait(TimeSpan.FromSeconds(10));    

                
                for(var i=0; i<numThreads; i++)
                {
                    Assert.AreEqual(invoked[i].PipeName, results[i].PipeName );
                    Assert.AreEqual(invoked[i].ProcessId, results[i].ProcessId);
                    Assert.AreEqual(invoked[i].ThreadIndex, results[i].ThreadIndex);

                    var invokedArgs = invoked[i].ArgProvider.ToArray().Select(x => (int)i);
                    var recievedArgs = results[i].ArgProvider.ToArray().Select(x => (int)i);
                    Assert.IsTrue(invokedArgs.SequenceEqual(recievedArgs));

                    var result = runner.Results[i];
                    Assert.IsTrue(result.StartsWith($"Thread {i}"), result);
                }
            }
            
            [TestMethod]
            public void ParallelForTest_2_11()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0))
                    .Build();
           
                var invoked = new FunctionInvokedEventArgs<string>[numThreads];
                var results = new FunctionResultEventArgs<string>[numThreads];

                func.FunctionInvoked += (sender, e) =>
                {
                    Assert.IsNotNull(e.FunctionCallData);

                    var callData = e.FunctionCallData;
                    
                    var callDataBytes= (byte[])callData;
                    var callDataFromBytes = (RemoteCallData)callDataBytes;

                    var callDataJson = JsonConvert.SerializeObject(callData);
                    var callDataFromBytesJson = JsonConvert.SerializeObject(callDataFromBytes);

                    Assert.AreEqual(callDataJson, callDataFromBytesJson);
                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.PipeName);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    Assert.IsNotNull(e.ArgProvider);
                    invoked[e.ThreadIndex] = e;
                };


                func.FunctionResultReturned += (sender, e) =>
                {
                    var thread = e.ThreadIndex;
                    var result = e.Result;
                    Assert.IsTrue(result != null);
                   

                    var args = e.ArgProvider.ToArray().Select(i => (int)i);
                    var expectedArgs = new[] { e.ThreadIndex, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
                    Assert.IsTrue(args.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    var argList =(ArgList<int, int, int, int, int, int, int, int, int, int, int, int>)e.ArgProvider;
                    object[] argListArray = argList;
                    var argListTypedArray = argListArray.Select(x => (int)x);
                    Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.Result);
                    Assert.IsNotNull(e.SerializedResult);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    results[e.ThreadIndex] = e;

                };

                  
                var runner = func.Run().Wait(TimeSpan.FromSeconds(10));    

                
                for(var i=0; i<numThreads; i++)
                {
                    Assert.AreEqual(invoked[i].PipeName, results[i].PipeName );
                    Assert.AreEqual(invoked[i].ProcessId, results[i].ProcessId);
                    Assert.AreEqual(invoked[i].ThreadIndex, results[i].ThreadIndex);

                    var invokedArgs = invoked[i].ArgProvider.ToArray().Select(x => (int)i);
                    var recievedArgs = results[i].ArgProvider.ToArray().Select(x => (int)i);
                    Assert.IsTrue(invokedArgs.SequenceEqual(recievedArgs));

                    var result = runner.Results[i];
                    Assert.IsTrue(result.StartsWith($"Thread {i}"), result);
                }
            }
            
            [TestMethod]
            public void ParallelForTest_2_12()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0))
                    .Build();
           
                var invoked = new FunctionInvokedEventArgs<string>[numThreads];
                var results = new FunctionResultEventArgs<string>[numThreads];

                func.FunctionInvoked += (sender, e) =>
                {
                    Assert.IsNotNull(e.FunctionCallData);

                    var callData = e.FunctionCallData;
                    
                    var callDataBytes= (byte[])callData;
                    var callDataFromBytes = (RemoteCallData)callDataBytes;

                    var callDataJson = JsonConvert.SerializeObject(callData);
                    var callDataFromBytesJson = JsonConvert.SerializeObject(callDataFromBytes);

                    Assert.AreEqual(callDataJson, callDataFromBytesJson);
                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.PipeName);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    Assert.IsNotNull(e.ArgProvider);
                    invoked[e.ThreadIndex] = e;
                };


                func.FunctionResultReturned += (sender, e) =>
                {
                    var thread = e.ThreadIndex;
                    var result = e.Result;
                    Assert.IsTrue(result != null);
                   

                    var args = e.ArgProvider.ToArray().Select(i => (int)i);
                    var expectedArgs = new[] { e.ThreadIndex, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
                    Assert.IsTrue(args.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    var argList =(ArgList<int, int, int, int, int, int, int, int, int, int, int, int, int>)e.ArgProvider;
                    object[] argListArray = argList;
                    var argListTypedArray = argListArray.Select(x => (int)x);
                    Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.Result);
                    Assert.IsNotNull(e.SerializedResult);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    results[e.ThreadIndex] = e;

                };

                  
                var runner = func.Run().Wait(TimeSpan.FromSeconds(10));    

                
                for(var i=0; i<numThreads; i++)
                {
                    Assert.AreEqual(invoked[i].PipeName, results[i].PipeName );
                    Assert.AreEqual(invoked[i].ProcessId, results[i].ProcessId);
                    Assert.AreEqual(invoked[i].ThreadIndex, results[i].ThreadIndex);

                    var invokedArgs = invoked[i].ArgProvider.ToArray().Select(x => (int)i);
                    var recievedArgs = results[i].ArgProvider.ToArray().Select(x => (int)i);
                    Assert.IsTrue(invokedArgs.SequenceEqual(recievedArgs));

                    var result = runner.Results[i];
                    Assert.IsTrue(result.StartsWith($"Thread {i}"), result);
                }
            }
            
            [TestMethod]
            public void ParallelForTest_2_13()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0))
                    .Build();
           
                var invoked = new FunctionInvokedEventArgs<string>[numThreads];
                var results = new FunctionResultEventArgs<string>[numThreads];

                func.FunctionInvoked += (sender, e) =>
                {
                    Assert.IsNotNull(e.FunctionCallData);

                    var callData = e.FunctionCallData;
                    
                    var callDataBytes= (byte[])callData;
                    var callDataFromBytes = (RemoteCallData)callDataBytes;

                    var callDataJson = JsonConvert.SerializeObject(callData);
                    var callDataFromBytesJson = JsonConvert.SerializeObject(callDataFromBytes);

                    Assert.AreEqual(callDataJson, callDataFromBytesJson);
                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.PipeName);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    Assert.IsNotNull(e.ArgProvider);
                    invoked[e.ThreadIndex] = e;
                };


                func.FunctionResultReturned += (sender, e) =>
                {
                    var thread = e.ThreadIndex;
                    var result = e.Result;
                    Assert.IsTrue(result != null);
                   

                    var args = e.ArgProvider.ToArray().Select(i => (int)i);
                    var expectedArgs = new[] { e.ThreadIndex, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
                    Assert.IsTrue(args.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    var argList =(ArgList<int, int, int, int, int, int, int, int, int, int, int, int, int, int>)e.ArgProvider;
                    object[] argListArray = argList;
                    var argListTypedArray = argListArray.Select(x => (int)x);
                    Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.Result);
                    Assert.IsNotNull(e.SerializedResult);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    results[e.ThreadIndex] = e;

                };

                  
                var runner = func.Run().Wait(TimeSpan.FromSeconds(10));    

                
                for(var i=0; i<numThreads; i++)
                {
                    Assert.AreEqual(invoked[i].PipeName, results[i].PipeName );
                    Assert.AreEqual(invoked[i].ProcessId, results[i].ProcessId);
                    Assert.AreEqual(invoked[i].ThreadIndex, results[i].ThreadIndex);

                    var invokedArgs = invoked[i].ArgProvider.ToArray().Select(x => (int)i);
                    var recievedArgs = results[i].ArgProvider.ToArray().Select(x => (int)i);
                    Assert.IsTrue(invokedArgs.SequenceEqual(recievedArgs));

                    var result = runner.Results[i];
                    Assert.IsTrue(result.StartsWith($"Thread {i}"), result);
                }
            }
            
            [TestMethod]
            public void ParallelForTest_2_14()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0))
                    .Build();
           
                var invoked = new FunctionInvokedEventArgs<string>[numThreads];
                var results = new FunctionResultEventArgs<string>[numThreads];

                func.FunctionInvoked += (sender, e) =>
                {
                    Assert.IsNotNull(e.FunctionCallData);

                    var callData = e.FunctionCallData;
                    
                    var callDataBytes= (byte[])callData;
                    var callDataFromBytes = (RemoteCallData)callDataBytes;

                    var callDataJson = JsonConvert.SerializeObject(callData);
                    var callDataFromBytesJson = JsonConvert.SerializeObject(callDataFromBytes);

                    Assert.AreEqual(callDataJson, callDataFromBytesJson);
                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.PipeName);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    Assert.IsNotNull(e.ArgProvider);
                    invoked[e.ThreadIndex] = e;
                };


                func.FunctionResultReturned += (sender, e) =>
                {
                    var thread = e.ThreadIndex;
                    var result = e.Result;
                    Assert.IsTrue(result != null);
                   

                    var args = e.ArgProvider.ToArray().Select(i => (int)i);
                    var expectedArgs = new[] { e.ThreadIndex, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
                    Assert.IsTrue(args.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    var argList =(ArgList<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>)e.ArgProvider;
                    object[] argListArray = argList;
                    var argListTypedArray = argListArray.Select(x => (int)x);
                    Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.Result);
                    Assert.IsNotNull(e.SerializedResult);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    results[e.ThreadIndex] = e;

                };

                  
                var runner = func.Run().Wait(TimeSpan.FromSeconds(10));    

                
                for(var i=0; i<numThreads; i++)
                {
                    Assert.AreEqual(invoked[i].PipeName, results[i].PipeName );
                    Assert.AreEqual(invoked[i].ProcessId, results[i].ProcessId);
                    Assert.AreEqual(invoked[i].ThreadIndex, results[i].ThreadIndex);

                    var invokedArgs = invoked[i].ArgProvider.ToArray().Select(x => (int)i);
                    var recievedArgs = results[i].ArgProvider.ToArray().Select(x => (int)i);
                    Assert.IsTrue(invokedArgs.SequenceEqual(recievedArgs));

                    var result = runner.Results[i];
                    Assert.IsTrue(result.StartsWith($"Thread {i}"), result);
                }
            }
            
            [TestMethod]
            public void ParallelForTest_2_15()
            {
                Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> target = For;

                var func = Mpi
                    .ParallelFor(0, numThreads, target, i => new(i, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0))
                    .Build();
           
                var invoked = new FunctionInvokedEventArgs<string>[numThreads];
                var results = new FunctionResultEventArgs<string>[numThreads];

                func.FunctionInvoked += (sender, e) =>
                {
                    Assert.IsNotNull(e.FunctionCallData);

                    var callData = e.FunctionCallData;
                    
                    var callDataBytes= (byte[])callData;
                    var callDataFromBytes = (RemoteCallData)callDataBytes;

                    var callDataJson = JsonConvert.SerializeObject(callData);
                    var callDataFromBytesJson = JsonConvert.SerializeObject(callDataFromBytes);

                    Assert.AreEqual(callDataJson, callDataFromBytesJson);
                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.PipeName);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    Assert.IsNotNull(e.ArgProvider);
                    invoked[e.ThreadIndex] = e;
                };


                func.FunctionResultReturned += (sender, e) =>
                {
                    var thread = e.ThreadIndex;
                    var result = e.Result;
                    Assert.IsTrue(result != null);
                   

                    var args = e.ArgProvider.ToArray().Select(i => (int)i);
                    var expectedArgs = new[] { e.ThreadIndex, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
                    Assert.IsTrue(args.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    var argList =(ArgList<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>)e.ArgProvider;
                    object[] argListArray = argList;
                    var argListTypedArray = argListArray.Select(x => (int)x);
                    Assert.IsTrue(argListTypedArray.SequenceEqual(expectedArgs),
                        $"Args: {string.Join(", ", args)} Expected: {string.Join(", ", args)}"
                    );

                    Assert.AreNotEqual(0, e.ProcessId);
                    Assert.IsNotNull(e.Result);
                    Assert.IsNotNull(e.SerializedResult);
                    Assert.IsTrue(e.ThreadIndex >= 0 && e.ThreadIndex < numThreads);
                    results[e.ThreadIndex] = e;

                };

                  
                var runner = func.Run().Wait(TimeSpan.FromSeconds(10));    

                
                for(var i=0; i<numThreads; i++)
                {
                    Assert.AreEqual(invoked[i].PipeName, results[i].PipeName );
                    Assert.AreEqual(invoked[i].ProcessId, results[i].ProcessId);
                    Assert.AreEqual(invoked[i].ThreadIndex, results[i].ThreadIndex);

                    var invokedArgs = invoked[i].ArgProvider.ToArray().Select(x => (int)i);
                    var recievedArgs = results[i].ArgProvider.ToArray().Select(x => (int)i);
                    Assert.IsTrue(invokedArgs.SequenceEqual(recievedArgs));

                    var result = runner.Results[i];
                    Assert.IsTrue(result.StartsWith($"Thread {i}"), result);
                }
            }
            
        }
    }
}