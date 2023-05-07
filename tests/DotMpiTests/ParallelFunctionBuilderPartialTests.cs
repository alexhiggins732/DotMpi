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
        public void ForTest00()
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
        public void ForTest01()
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
        public void ForTest02()
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
        public void ForTest03()
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
        public void ForTest04()
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
        public void ForTest05()
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
        public void ForTest06()
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
        public void ForTest07()
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
        public void ForTest08()
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
        public void ForTest09()
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
        public void ForTest10()
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
        public void ForTest11()
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
        public void ForTest12()
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
        public void ForTest13()
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
        public void ForTest14()
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
        public void ForTest15()
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
    

    }

}