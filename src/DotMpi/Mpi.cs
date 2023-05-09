/*
 Copyright (c) 2023 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 
 
 Source code for this software can be found at https://github.com/alexhiggins732/DotMpi
 
 This software is licensce under GNU General Public License version 3 as described in the LICENSE
 file at https://github.com/alexhiggins732/DotMpi/LICENSE
 
 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System.Reflection;

namespace DotMpi
{
    public partial class Mpi
    {
        private static string pipeName = string.Empty;
        public static string id => $"[{pipeName}]";
        public static string PipeName { get => pipeName; set => MpiRunner.id = pipeName = value; }
        static Logger Logger = Logger.Instance;

        /// <summary>
        /// Returns a parallel function builder for the specified number of threads.
        /// </summary>
        /// <param name="numThreads">The number of parallel process threads to launch</param>
        /// <returns></returns>
        public static ParallelFunctionBuilder Parallel(int numThreads) => Parallel(0, numThreads);


        /// <summary>
        /// Returns a parallel function builder for the specified number of threads.
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <returns></returns>
        public static ParallelFunctionBuilder Parallel(int start, int end) => new ParallelFunctionBuilder(start, end);



        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <exception cref="ArgumentException"></exception>
        //special case for only one generic argument
        public static ParallelFunction<T0, TResult>
            ParallelFor<T0, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, TResult> target,
                Func<int, T0> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs(argProvider);
            return builder;
        }
    }
}

