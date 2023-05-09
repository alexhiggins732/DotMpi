/*
 Copyright (c) 2023 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 
 
 Source code for this software can be found at https://github.com/alexhiggins732/DotMpi
 
 This software is licensce under GNU General Public License version 3 as described in the LICENSE
 file at https://github.com/alexhiggins732/DotMpi/LICENSE
 
 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

namespace DotMpi
{
    public partial class Mpi
    {

    
        // from, to, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, TResult>
            ParallelFor<T0, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, TResult> target,
                Func<int, ArgList<T0>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target, argProvider);
            return builder;
        }

        // from, to, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, TResult>
            ParallelFor<T0, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, TResult> target,
                T0 arg0            
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs(arg0);
            return builder;
        }

        // from, to, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, TResult>
            ParallelFor<T0, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, TResult> target
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target);
            return builder;
        }

        // numthreads, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, TResult>
            ParallelFor<T0, TResult>(
                int numThreads,
                Func<T0, TResult> target,
                Func<int, ArgList<T0>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(0, numThreads)
                .For(target, argProvider);
            return builder;
        }

        //numthreads, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, TResult>
            ParallelFor<T0, TResult>(
                int numThreads,
                Func<T0, TResult> target,
                T0 arg0            
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target).WithArgs(arg0);
                return builder;
            }


        //numThreads, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, TResult>
            ParallelFor<T0, TResult>(
                int numThreads,
                Func<T0, TResult> target
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target);
                return builder;
            }

        
        // from, to, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, TResult>
            ParallelFor<T0, T1, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, TResult> target,
                Func<int, ArgList<T0, T1>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target, argProvider);
            return builder;
        }

        // from, to, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, TResult>
            ParallelFor<T0, T1, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, TResult> target,
                T0 arg0, T1 arg1            
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs(arg0, arg1);
            return builder;
        }

        // from, to, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, TResult>
            ParallelFor<T0, T1, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, TResult> target
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target);
            return builder;
        }

        // numthreads, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, TResult>
            ParallelFor<T0, T1, TResult>(
                int numThreads,
                Func<T0, T1, TResult> target,
                Func<int, ArgList<T0, T1>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(0, numThreads)
                .For(target, argProvider);
            return builder;
        }

        //numthreads, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, TResult>
            ParallelFor<T0, T1, TResult>(
                int numThreads,
                Func<T0, T1, TResult> target,
                T0 arg0, T1 arg1            
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target).WithArgs(arg0, arg1);
                return builder;
            }


        //numThreads, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, TResult>
            ParallelFor<T0, T1, TResult>(
                int numThreads,
                Func<T0, T1, TResult> target
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target);
                return builder;
            }

        
        // from, to, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, TResult>
            ParallelFor<T0, T1, T2, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, TResult> target,
                Func<int, ArgList<T0, T1, T2>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target, argProvider);
            return builder;
        }

        // from, to, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, TResult>
            ParallelFor<T0, T1, T2, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, TResult> target,
                T0 arg0, T1 arg1, T2 arg2            
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs(arg0, arg1, arg2);
            return builder;
        }

        // from, to, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, TResult>
            ParallelFor<T0, T1, T2, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, TResult> target
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target);
            return builder;
        }

        // numthreads, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, TResult>
            ParallelFor<T0, T1, T2, TResult>(
                int numThreads,
                Func<T0, T1, T2, TResult> target,
                Func<int, ArgList<T0, T1, T2>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(0, numThreads)
                .For(target, argProvider);
            return builder;
        }

        //numthreads, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, TResult>
            ParallelFor<T0, T1, T2, TResult>(
                int numThreads,
                Func<T0, T1, T2, TResult> target,
                T0 arg0, T1 arg1, T2 arg2            
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target).WithArgs(arg0, arg1, arg2);
                return builder;
            }


        //numThreads, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, TResult>
            ParallelFor<T0, T1, T2, TResult>(
                int numThreads,
                Func<T0, T1, T2, TResult> target
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target);
                return builder;
            }

        
        // from, to, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, TResult>
            ParallelFor<T0, T1, T2, T3, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target, argProvider);
            return builder;
        }

        // from, to, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, TResult>
            ParallelFor<T0, T1, T2, T3, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3            
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs(arg0, arg1, arg2, arg3);
            return builder;
        }

        // from, to, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, TResult>
            ParallelFor<T0, T1, T2, T3, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, TResult> target
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target);
            return builder;
        }

        // numthreads, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, TResult>
            ParallelFor<T0, T1, T2, T3, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(0, numThreads)
                .For(target, argProvider);
            return builder;
        }

        //numthreads, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, TResult>
            ParallelFor<T0, T1, T2, T3, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3            
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target).WithArgs(arg0, arg1, arg2, arg3);
                return builder;
            }


        //numThreads, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, TResult>
            ParallelFor<T0, T1, T2, T3, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, TResult> target
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target);
                return builder;
            }

        
        // from, to, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, TResult>
            ParallelFor<T0, T1, T2, T3, T4, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3, T4>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target, argProvider);
            return builder;
        }

        // from, to, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, TResult>
            ParallelFor<T0, T1, T2, T3, T4, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4            
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs(arg0, arg1, arg2, arg3, arg4);
            return builder;
        }

        // from, to, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, TResult>
            ParallelFor<T0, T1, T2, T3, T4, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, TResult> target
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target);
            return builder;
        }

        // numthreads, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, TResult>
            ParallelFor<T0, T1, T2, T3, T4, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3, T4>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(0, numThreads)
                .For(target, argProvider);
            return builder;
        }

        //numthreads, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, TResult>
            ParallelFor<T0, T1, T2, T3, T4, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4            
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target).WithArgs(arg0, arg1, arg2, arg3, arg4);
                return builder;
            }


        //numThreads, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, TResult>
            ParallelFor<T0, T1, T2, T3, T4, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, TResult> target
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target);
                return builder;
            }

        
        // from, to, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3, T4, T5>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target, argProvider);
            return builder;
        }

        // from, to, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5            
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs(arg0, arg1, arg2, arg3, arg4, arg5);
            return builder;
        }

        // from, to, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, TResult> target
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target);
            return builder;
        }

        // numthreads, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3, T4, T5>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(0, numThreads)
                .For(target, argProvider);
            return builder;
        }

        //numthreads, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5            
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target).WithArgs(arg0, arg1, arg2, arg3, arg4, arg5);
                return builder;
            }


        //numThreads, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, TResult> target
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target);
                return builder;
            }

        
        // from, to, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target, argProvider);
            return builder;
        }

        // from, to, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6            
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            return builder;
        }

        // from, to, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, TResult> target
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target);
            return builder;
        }

        // numthreads, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(0, numThreads)
                .For(target, argProvider);
            return builder;
        }

        //numthreads, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6            
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target).WithArgs(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
                return builder;
            }


        //numThreads, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, TResult> target
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target);
                return builder;
            }

        
        // from, to, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target, argProvider);
            return builder;
        }

        // from, to, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7            
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            return builder;
        }

        // from, to, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, TResult> target
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target);
            return builder;
        }

        // numthreads, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(0, numThreads)
                .For(target, argProvider);
            return builder;
        }

        //numthreads, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7            
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target).WithArgs(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                return builder;
            }


        //numThreads, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, TResult> target
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target);
                return builder;
            }

        
        // from, to, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target, argProvider);
            return builder;
        }

        // from, to, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8            
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            return builder;
        }

        // from, to, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult> target
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target);
            return builder;
        }

        // numthreads, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(0, numThreads)
                .For(target, argProvider);
            return builder;
        }

        //numthreads, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8            
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target).WithArgs(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                return builder;
            }


        //numThreads, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult> target
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target);
                return builder;
            }

        
        // from, to, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target, argProvider);
            return builder;
        }

        // from, to, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9            
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            return builder;
        }

        // from, to, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> target
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target);
            return builder;
        }

        // numthreads, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(0, numThreads)
                .For(target, argProvider);
            return builder;
        }

        //numthreads, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9            
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target).WithArgs(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                return builder;
            }


        //numThreads, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> target
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target);
                return builder;
            }

        
        // from, to, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target, argProvider);
            return builder;
        }

        // from, to, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10            
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            return builder;
        }

        // from, to, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> target
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target);
            return builder;
        }

        // numthreads, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(0, numThreads)
                .For(target, argProvider);
            return builder;
        }

        //numthreads, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10            
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target).WithArgs(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                return builder;
            }


        //numThreads, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> target
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target);
                return builder;
            }

        
        // from, to, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target, argProvider);
            return builder;
        }

        // from, to, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11            
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            return builder;
        }

        // from, to, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> target
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target);
            return builder;
        }

        // numthreads, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(0, numThreads)
                .For(target, argProvider);
            return builder;
        }

        //numthreads, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11            
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target).WithArgs(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                return builder;
            }


        //numThreads, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> target
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target);
                return builder;
            }

        
        // from, to, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target, argProvider);
            return builder;
        }

        // from, to, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12            
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            return builder;
        }

        // from, to, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> target
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target);
            return builder;
        }

        // numthreads, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(0, numThreads)
                .For(target, argProvider);
            return builder;
        }

        //numthreads, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12            
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target).WithArgs(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                return builder;
            }


        //numThreads, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> target
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target);
                return builder;
            }

        
        // from, to, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target, argProvider);
            return builder;
        }

        // from, to, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13            
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            return builder;
        }

        // from, to, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> target
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target);
            return builder;
        }

        // numthreads, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(0, numThreads)
                .For(target, argProvider);
            return builder;
        }

        //numthreads, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13            
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target).WithArgs(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                return builder;
            }


        //numThreads, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> target
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target);
                return builder;
            }

        
        // from, to, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target, argProvider);
            return builder;
        }

        // from, to, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14            
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            return builder;
        }

        // from, to, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> target
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target);
            return builder;
        }

        // numthreads, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(0, numThreads)
                .For(target, argProvider);
            return builder;
        }

        //numthreads, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14            
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target).WithArgs(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                return builder;
            }


        //numThreads, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> target
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target);
                return builder;
            }

        
        // from, to, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target, argProvider);
            return builder;
        }

        // from, to, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15            
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            return builder;
        }

        // from, to, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> target
            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target);
            return builder;
        }

        // numthreads, target, func<int, arglist>
        /// <summary>
        /// Multi processor parallel runner, accepting an argument provider
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> target,
                Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> argProvider
            )
        {
            var builder = new ParallelFunctionBuilder(0, numThreads)
                .For(target, argProvider);
            return builder;
        }

        //numthreads, target, args
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> target,
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15            
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target).WithArgs(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                return builder;
            }


        //numThreads, target
        /// <summary>
        /// Multi processor parallel runner, accepting an strongly typed generic arguments
        /// </summary>
        /// <param name="numThreads">The number of threads to launch.</param>
        /// <param name="target">The target method to execute on the external processor.</param>
        /// <exception cref="ArgumentException"></exception>
        public static ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>
            ParallelFor<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
                int numThreads,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> target
            )
            {
                var builder = new ParallelFunctionBuilder(numThreads)
                    .For(target);
                return builder;
            }

        
    }
}
