/*
 Copyright (c) 2023 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 
 
 Source code for this software can be found at https://github.com/alexhiggins732/DotMpi
 
 This software is licensce under GNU General Public License version 3 as described in the LICENSE
 file at https://github.com/alexhiggins732/DotMpi/LICENSE
 
 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System.IO.Pipes;
using System.Text;


namespace DotMpi
{
    public partial class Mpi
    {

    #region ParallelFor

    

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
                T0 arg0            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs((i => new(arg0)));
            return builder;
        }

        

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
                T0 arg0, T1 arg1            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs((i => new(arg0, arg1)));
            return builder;
        }

        

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
                T0 arg0, T1 arg1, T2 arg2            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs((i => new(arg0, arg1, arg2)));
            return builder;
        }

        

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
                T0 arg0, T1 arg1, T2 arg2, T3 arg3            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs((i => new(arg0, arg1, arg2, arg3)));
            return builder;
        }

        

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
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs((i => new(arg0, arg1, arg2, arg3, arg4)));
            return builder;
        }

        

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
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs((i => new(arg0, arg1, arg2, arg3, arg4, arg5)));
            return builder;
        }

        

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
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs((i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6)));
            return builder;
        }

        

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
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs((i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7)));
            return builder;
        }

        

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
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs((i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)));
            return builder;
        }

        

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
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs((i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9)));
            return builder;
        }

        

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
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs((i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10)));
            return builder;
        }

        

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
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs((i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11)));
            return builder;
        }

        

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
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs((i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12)));
            return builder;
        }

        

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
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs((i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13)));
            return builder;
        }

        

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
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs((i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14)));
            return builder;
        }

        

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
                T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15            )
        {
            var builder = new ParallelFunctionBuilder(fromInclusive, toExclusive)
                .For(target).WithArgs((i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15)));
            return builder;
        }

        
    #endregion



    #region ParallelFunctionBuilder.For

        public partial class ParallelFunctionBuilder
        {

            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, TResult>
                For<T0, TResult>
                (
                    Func<T0, TResult> target
                )
                {
                    var runner = new ParallelFunction<T0, TResult>
                        (Start, End, target);
                    return runner;                
                }

            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, TResult>
                For<T0, TResult>
                (
                    Func<T0, TResult> target,
                    Func<int, ArgList<T0>> argProvider
                )
                {
                    var runner = new ParallelFunction<T0, TResult>
                        (Start, End, target);

                    return runner.WithArgs(argProvider);                
                }

        
            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, TResult>
                For<T0, T1, TResult>
                (
                    Func<T0, T1, TResult> target
                )
                {
                    var runner = new ParallelFunction<T0, T1, TResult>
                        (Start, End, target);
                    return runner;                
                }

            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, TResult>
                For<T0, T1, TResult>
                (
                    Func<T0, T1, TResult> target,
                    Func<int, ArgList<T0, T1>> argProvider
                )
                {
                    var runner = new ParallelFunction<T0, T1, TResult>
                        (Start, End, target);

                    return runner.WithArgs(argProvider);                
                }

        
            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, TResult>
                For<T0, T1, T2, TResult>
                (
                    Func<T0, T1, T2, TResult> target
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, TResult>
                        (Start, End, target);
                    return runner;                
                }

            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, TResult>
                For<T0, T1, T2, TResult>
                (
                    Func<T0, T1, T2, TResult> target,
                    Func<int, ArgList<T0, T1, T2>> argProvider
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, TResult>
                        (Start, End, target);

                    return runner.WithArgs(argProvider);                
                }

        
            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, TResult>
                For<T0, T1, T2, T3, TResult>
                (
                    Func<T0, T1, T2, T3, TResult> target
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, TResult>
                        (Start, End, target);
                    return runner;                
                }

            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, TResult>
                For<T0, T1, T2, T3, TResult>
                (
                    Func<T0, T1, T2, T3, TResult> target,
                    Func<int, ArgList<T0, T1, T2, T3>> argProvider
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, TResult>
                        (Start, End, target);

                    return runner.WithArgs(argProvider);                
                }

        
            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, T4, TResult>
                For<T0, T1, T2, T3, T4, TResult>
                (
                    Func<T0, T1, T2, T3, T4, TResult> target
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, T4, TResult>
                        (Start, End, target);
                    return runner;                
                }

            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, T4, TResult>
                For<T0, T1, T2, T3, T4, TResult>
                (
                    Func<T0, T1, T2, T3, T4, TResult> target,
                    Func<int, ArgList<T0, T1, T2, T3, T4>> argProvider
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, T4, TResult>
                        (Start, End, target);

                    return runner.WithArgs(argProvider);                
                }

        
            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, T4, T5, TResult>
                For<T0, T1, T2, T3, T4, T5, TResult>
                (
                    Func<T0, T1, T2, T3, T4, T5, TResult> target
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, T4, T5, TResult>
                        (Start, End, target);
                    return runner;                
                }

            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, T4, T5, TResult>
                For<T0, T1, T2, T3, T4, T5, TResult>
                (
                    Func<T0, T1, T2, T3, T4, T5, TResult> target,
                    Func<int, ArgList<T0, T1, T2, T3, T4, T5>> argProvider
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, T4, T5, TResult>
                        (Start, End, target);

                    return runner.WithArgs(argProvider);                
                }

        
            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, T4, T5, T6, TResult>
                For<T0, T1, T2, T3, T4, T5, T6, TResult>
                (
                    Func<T0, T1, T2, T3, T4, T5, T6, TResult> target
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, T4, T5, T6, TResult>
                        (Start, End, target);
                    return runner;                
                }

            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, T4, T5, T6, TResult>
                For<T0, T1, T2, T3, T4, T5, T6, TResult>
                (
                    Func<T0, T1, T2, T3, T4, T5, T6, TResult> target,
                    Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6>> argProvider
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, T4, T5, T6, TResult>
                        (Start, End, target);

                    return runner.WithArgs(argProvider);                
                }

        
            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, T4, T5, T6, T7, TResult>
                For<T0, T1, T2, T3, T4, T5, T6, T7, TResult>
                (
                    Func<T0, T1, T2, T3, T4, T5, T6, T7, TResult> target
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, TResult>
                        (Start, End, target);
                    return runner;                
                }

            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, T4, T5, T6, T7, TResult>
                For<T0, T1, T2, T3, T4, T5, T6, T7, TResult>
                (
                    Func<T0, T1, T2, T3, T4, T5, T6, T7, TResult> target,
                    Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7>> argProvider
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, TResult>
                        (Start, End, target);

                    return runner.WithArgs(argProvider);                
                }

        
            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>
                For<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>
                (
                    Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult> target
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>
                        (Start, End, target);
                    return runner;                
                }

            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>
                For<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>
                (
                    Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult> target,
                    Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8>> argProvider
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>
                        (Start, End, target);

                    return runner.WithArgs(argProvider);                
                }

        
            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
                For<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
                (
                    Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> target
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
                        (Start, End, target);
                    return runner;                
                }

            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
                For<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
                (
                    Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> target,
                    Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>> argProvider
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
                        (Start, End, target);

                    return runner.WithArgs(argProvider);                
                }

        
            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
                For<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
                (
                    Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> target
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
                        (Start, End, target);
                    return runner;                
                }

            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
                For<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
                (
                    Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> target,
                    Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> argProvider
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
                        (Start, End, target);

                    return runner.WithArgs(argProvider);                
                }

        
            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>
                For<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>
                (
                    Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> target
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>
                        (Start, End, target);
                    return runner;                
                }

            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>
                For<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>
                (
                    Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> target,
                    Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> argProvider
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>
                        (Start, End, target);

                    return runner.WithArgs(argProvider);                
                }

        
            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>
                For<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>
                (
                    Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> target
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>
                        (Start, End, target);
                    return runner;                
                }

            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>
                For<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>
                (
                    Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> target,
                    Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> argProvider
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>
                        (Start, End, target);

                    return runner.WithArgs(argProvider);                
                }

        
            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>
                For<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>
                (
                    Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> target
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>
                        (Start, End, target);
                    return runner;                
                }

            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>
                For<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>
                (
                    Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> target,
                    Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> argProvider
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>
                        (Start, End, target);

                    return runner.WithArgs(argProvider);                
                }

        
            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>
                For<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>
                (
                    Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> target
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>
                        (Start, End, target);
                    return runner;                
                }

            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>
                For<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>
                (
                    Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> target,
                    Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> argProvider
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>
                        (Start, End, target);

                    return runner.WithArgs(argProvider);                
                }

        
            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>
                For<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>
                (
                    Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> target
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>
                        (Start, End, target);
                    return runner;                
                }

            /// <summary>
            /// Multi processor parallel runner, accepting an argument provider
            /// </summary>
            /// <param name="target">The target method to execute on the external processor.</param>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            public ParallelFunction
                <T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>
                For<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>
                (
                    Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> target,
                    Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> argProvider
                )
                {
                    var runner = new ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>
                        (Start, End, target);

                    return runner.WithArgs(argProvider);                
                }

                }

    #endregion



    #region ParallelFunction

#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, TResult> 
            : ParallelFunctionRunner<TResult>
        {

            private Func<int, ArgList<T0>> argProvider = null!;

            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(int fromInclusive, int toExclusive, Func<T0, TResult> target)
                : base(fromInclusive, toExclusive)
            {
                Target = target;
            }

            public Func<T0, TResult> Target { get; }

            public TResult Execute(T0 arg0)
            {
                var result = MpiRunner.Exec(Target, arg0);
                return result;
            }

            
            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, TResult> 
                WithArgs(Func<int, T0> value)
            {
                this.argProvider= (i => new(value(i)));
                this.ArgProvider = this.argProvider;
                return this;
            }

            
            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, TResult> 
                WithArgs(T0 arg0)
            {
                this.argProvider = (i => new(arg0));
                this.ArgProvider = this.argProvider;
                return this;
            }
          
            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, TResult>
                WithArgs(Func<int, ArgList<T0>> argProvider)
            {
                this.argProvider = argProvider;
                this.ArgProvider = this.argProvider;
                return this;
            }

            protected override void RunThread(NamedPipeServerStream pipeServer, string pipeName, int threadIndex, Func<int, IArgListProvider> argProvider)
            {
                var args = argProvider(threadIndex).ToArray();


                Console.WriteLine($"[{DateTime.Now}] {id} [Thread {threadIndex}] Executing ParallelRunner.{nameof(Run)}(pipeServer, {pipeName}, {string.Join(",", args)})");
                Console.WriteLine($"[{DateTime.Now}] {id} Executing ParallelRunner:PipeServer.WaitForConnection()");

                pipeServer.WaitForConnection();



                var callData = MpiRunner.GetRemoteCallData(Target.Method, args);

                if (Logger.InfoEnabled)
                {
                    var debugJson = callData.DebugJson();
                    Logger.Info($"[{DateTime.Now}] {id} Sending call data to {pipeName} {threadIndex}: {debugJson}");
                }

                if(args!=null && args.Length> 0 && (int)args[0] != threadIndex)
                {
                    throw new Exception("Invalid arg for {threadIndex}: {args[0]}");
                }

                using (var bw = new BinaryWriter(pipeServer, Encoding.UTF8, true))
                {
                    byte[] callDataBytes = callData.ToByteArray();
                    bw.Write(callDataBytes.Length);
                    bw.Write(callDataBytes);
                }
                
                // will be executed remote on the client.
                //ExecuteAndSend(pipeName);
            }
        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, TResult> 
            : ParallelFunctionRunner<TResult>
        {

            private Func<int, ArgList<T0, T1>> argProvider = null!;

            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(int fromInclusive, int toExclusive, Func<T0, T1, TResult> target)
                : base(fromInclusive, toExclusive)
            {
                Target = target;
            }

            public Func<T0, T1, TResult> Target { get; }

            public TResult Execute(T0 arg0, T1 arg1)
            {
                var result = MpiRunner.Exec(Target, arg0, arg1);
                return result;
            }

            
            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, TResult> 
                WithArgs(T0 arg0, T1 arg1)
            {
                this.argProvider = (i => new(arg0, arg1));
                this.ArgProvider = this.argProvider;
                return this;
            }
          
            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, TResult>
                WithArgs(Func<int, ArgList<T0, T1>> argProvider)
            {
                this.argProvider = argProvider;
                this.ArgProvider = this.argProvider;
                return this;
            }

            protected override void RunThread(NamedPipeServerStream pipeServer, string pipeName, int threadIndex, Func<int, IArgListProvider> argProvider)
            {
                var args = argProvider(threadIndex).ToArray();


                Console.WriteLine($"[{DateTime.Now}] {id} [Thread {threadIndex}] Executing ParallelRunner.{nameof(Run)}(pipeServer, {pipeName}, {string.Join(",", args)})");
                Console.WriteLine($"[{DateTime.Now}] {id} Executing ParallelRunner:PipeServer.WaitForConnection()");

                pipeServer.WaitForConnection();



                var callData = MpiRunner.GetRemoteCallData(Target.Method, args);

                if (Logger.InfoEnabled)
                {
                    var debugJson = callData.DebugJson();
                    Logger.Info($"[{DateTime.Now}] {id} Sending call data to {pipeName} {threadIndex}: {debugJson}");
                }

                if(args!=null && args.Length> 0 && (int)args[0] != threadIndex)
                {
                    throw new Exception("Invalid arg for {threadIndex}: {args[0]}");
                }

                using (var bw = new BinaryWriter(pipeServer, Encoding.UTF8, true))
                {
                    byte[] callDataBytes = callData.ToByteArray();
                    bw.Write(callDataBytes.Length);
                    bw.Write(callDataBytes);
                }
                
                // will be executed remote on the client.
                //ExecuteAndSend(pipeName);
            }
        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, TResult> 
            : ParallelFunctionRunner<TResult>
        {

            private Func<int, ArgList<T0, T1, T2>> argProvider = null!;

            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(int fromInclusive, int toExclusive, Func<T0, T1, T2, TResult> target)
                : base(fromInclusive, toExclusive)
            {
                Target = target;
            }

            public Func<T0, T1, T2, TResult> Target { get; }

            public TResult Execute(T0 arg0, T1 arg1, T2 arg2)
            {
                var result = MpiRunner.Exec(Target, arg0, arg1, arg2);
                return result;
            }

            
            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, TResult> 
                WithArgs(T0 arg0, T1 arg1, T2 arg2)
            {
                this.argProvider = (i => new(arg0, arg1, arg2));
                this.ArgProvider = this.argProvider;
                return this;
            }
          
            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2>> argProvider)
            {
                this.argProvider = argProvider;
                this.ArgProvider = this.argProvider;
                return this;
            }

            protected override void RunThread(NamedPipeServerStream pipeServer, string pipeName, int threadIndex, Func<int, IArgListProvider> argProvider)
            {
                var args = argProvider(threadIndex).ToArray();


                Console.WriteLine($"[{DateTime.Now}] {id} [Thread {threadIndex}] Executing ParallelRunner.{nameof(Run)}(pipeServer, {pipeName}, {string.Join(",", args)})");
                Console.WriteLine($"[{DateTime.Now}] {id} Executing ParallelRunner:PipeServer.WaitForConnection()");

                pipeServer.WaitForConnection();



                var callData = MpiRunner.GetRemoteCallData(Target.Method, args);

                if (Logger.InfoEnabled)
                {
                    var debugJson = callData.DebugJson();
                    Logger.Info($"[{DateTime.Now}] {id} Sending call data to {pipeName} {threadIndex}: {debugJson}");
                }

                if(args!=null && args.Length> 0 && (int)args[0] != threadIndex)
                {
                    throw new Exception("Invalid arg for {threadIndex}: {args[0]}");
                }

                using (var bw = new BinaryWriter(pipeServer, Encoding.UTF8, true))
                {
                    byte[] callDataBytes = callData.ToByteArray();
                    bw.Write(callDataBytes.Length);
                    bw.Write(callDataBytes);
                }
                
                // will be executed remote on the client.
                //ExecuteAndSend(pipeName);
            }
        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, TResult> 
            : ParallelFunctionRunner<TResult>
        {

            private Func<int, ArgList<T0, T1, T2, T3>> argProvider = null!;

            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(int fromInclusive, int toExclusive, Func<T0, T1, T2, T3, TResult> target)
                : base(fromInclusive, toExclusive)
            {
                Target = target;
            }

            public Func<T0, T1, T2, T3, TResult> Target { get; }

            public TResult Execute(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
            {
                var result = MpiRunner.Exec(Target, arg0, arg1, arg2, arg3);
                return result;
            }

            
            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, TResult> 
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
            {
                this.argProvider = (i => new(arg0, arg1, arg2, arg3));
                this.ArgProvider = this.argProvider;
                return this;
            }
          
            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3>> argProvider)
            {
                this.argProvider = argProvider;
                this.ArgProvider = this.argProvider;
                return this;
            }

            protected override void RunThread(NamedPipeServerStream pipeServer, string pipeName, int threadIndex, Func<int, IArgListProvider> argProvider)
            {
                var args = argProvider(threadIndex).ToArray();


                Console.WriteLine($"[{DateTime.Now}] {id} [Thread {threadIndex}] Executing ParallelRunner.{nameof(Run)}(pipeServer, {pipeName}, {string.Join(",", args)})");
                Console.WriteLine($"[{DateTime.Now}] {id} Executing ParallelRunner:PipeServer.WaitForConnection()");

                pipeServer.WaitForConnection();



                var callData = MpiRunner.GetRemoteCallData(Target.Method, args);

                if (Logger.InfoEnabled)
                {
                    var debugJson = callData.DebugJson();
                    Logger.Info($"[{DateTime.Now}] {id} Sending call data to {pipeName} {threadIndex}: {debugJson}");
                }

                if(args!=null && args.Length> 0 && (int)args[0] != threadIndex)
                {
                    throw new Exception("Invalid arg for {threadIndex}: {args[0]}");
                }

                using (var bw = new BinaryWriter(pipeServer, Encoding.UTF8, true))
                {
                    byte[] callDataBytes = callData.ToByteArray();
                    bw.Write(callDataBytes.Length);
                    bw.Write(callDataBytes);
                }
                
                // will be executed remote on the client.
                //ExecuteAndSend(pipeName);
            }
        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, T4, TResult> 
            : ParallelFunctionRunner<TResult>
        {

            private Func<int, ArgList<T0, T1, T2, T3, T4>> argProvider = null!;

            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(int fromInclusive, int toExclusive, Func<T0, T1, T2, T3, T4, TResult> target)
                : base(fromInclusive, toExclusive)
            {
                Target = target;
            }

            public Func<T0, T1, T2, T3, T4, TResult> Target { get; }

            public TResult Execute(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            {
                var result = MpiRunner.Exec(Target, arg0, arg1, arg2, arg3, arg4);
                return result;
            }

            
            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, TResult> 
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            {
                this.argProvider = (i => new(arg0, arg1, arg2, arg3, arg4));
                this.ArgProvider = this.argProvider;
                return this;
            }
          
            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3, T4>> argProvider)
            {
                this.argProvider = argProvider;
                this.ArgProvider = this.argProvider;
                return this;
            }

            protected override void RunThread(NamedPipeServerStream pipeServer, string pipeName, int threadIndex, Func<int, IArgListProvider> argProvider)
            {
                var args = argProvider(threadIndex).ToArray();


                Console.WriteLine($"[{DateTime.Now}] {id} [Thread {threadIndex}] Executing ParallelRunner.{nameof(Run)}(pipeServer, {pipeName}, {string.Join(",", args)})");
                Console.WriteLine($"[{DateTime.Now}] {id} Executing ParallelRunner:PipeServer.WaitForConnection()");

                pipeServer.WaitForConnection();



                var callData = MpiRunner.GetRemoteCallData(Target.Method, args);

                if (Logger.InfoEnabled)
                {
                    var debugJson = callData.DebugJson();
                    Logger.Info($"[{DateTime.Now}] {id} Sending call data to {pipeName} {threadIndex}: {debugJson}");
                }

                if(args!=null && args.Length> 0 && (int)args[0] != threadIndex)
                {
                    throw new Exception("Invalid arg for {threadIndex}: {args[0]}");
                }

                using (var bw = new BinaryWriter(pipeServer, Encoding.UTF8, true))
                {
                    byte[] callDataBytes = callData.ToByteArray();
                    bw.Write(callDataBytes.Length);
                    bw.Write(callDataBytes);
                }
                
                // will be executed remote on the client.
                //ExecuteAndSend(pipeName);
            }
        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, T4, T5, TResult> 
            : ParallelFunctionRunner<TResult>
        {

            private Func<int, ArgList<T0, T1, T2, T3, T4, T5>> argProvider = null!;

            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(int fromInclusive, int toExclusive, Func<T0, T1, T2, T3, T4, T5, TResult> target)
                : base(fromInclusive, toExclusive)
            {
                Target = target;
            }

            public Func<T0, T1, T2, T3, T4, T5, TResult> Target { get; }

            public TResult Execute(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            {
                var result = MpiRunner.Exec(Target, arg0, arg1, arg2, arg3, arg4, arg5);
                return result;
            }

            
            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, TResult> 
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            {
                this.argProvider = (i => new(arg0, arg1, arg2, arg3, arg4, arg5));
                this.ArgProvider = this.argProvider;
                return this;
            }
          
            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3, T4, T5>> argProvider)
            {
                this.argProvider = argProvider;
                this.ArgProvider = this.argProvider;
                return this;
            }

            protected override void RunThread(NamedPipeServerStream pipeServer, string pipeName, int threadIndex, Func<int, IArgListProvider> argProvider)
            {
                var args = argProvider(threadIndex).ToArray();


                Console.WriteLine($"[{DateTime.Now}] {id} [Thread {threadIndex}] Executing ParallelRunner.{nameof(Run)}(pipeServer, {pipeName}, {string.Join(",", args)})");
                Console.WriteLine($"[{DateTime.Now}] {id} Executing ParallelRunner:PipeServer.WaitForConnection()");

                pipeServer.WaitForConnection();



                var callData = MpiRunner.GetRemoteCallData(Target.Method, args);

                if (Logger.InfoEnabled)
                {
                    var debugJson = callData.DebugJson();
                    Logger.Info($"[{DateTime.Now}] {id} Sending call data to {pipeName} {threadIndex}: {debugJson}");
                }

                if(args!=null && args.Length> 0 && (int)args[0] != threadIndex)
                {
                    throw new Exception("Invalid arg for {threadIndex}: {args[0]}");
                }

                using (var bw = new BinaryWriter(pipeServer, Encoding.UTF8, true))
                {
                    byte[] callDataBytes = callData.ToByteArray();
                    bw.Write(callDataBytes.Length);
                    bw.Write(callDataBytes);
                }
                
                // will be executed remote on the client.
                //ExecuteAndSend(pipeName);
            }
        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, T4, T5, T6, TResult> 
            : ParallelFunctionRunner<TResult>
        {

            private Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6>> argProvider = null!;

            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(int fromInclusive, int toExclusive, Func<T0, T1, T2, T3, T4, T5, T6, TResult> target)
                : base(fromInclusive, toExclusive)
            {
                Target = target;
            }

            public Func<T0, T1, T2, T3, T4, T5, T6, TResult> Target { get; }

            public TResult Execute(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            {
                var result = MpiRunner.Exec(Target, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
                return result;
            }

            
            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, TResult> 
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            {
                this.argProvider = (i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6));
                this.ArgProvider = this.argProvider;
                return this;
            }
          
            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6>> argProvider)
            {
                this.argProvider = argProvider;
                this.ArgProvider = this.argProvider;
                return this;
            }

            protected override void RunThread(NamedPipeServerStream pipeServer, string pipeName, int threadIndex, Func<int, IArgListProvider> argProvider)
            {
                var args = argProvider(threadIndex).ToArray();


                Console.WriteLine($"[{DateTime.Now}] {id} [Thread {threadIndex}] Executing ParallelRunner.{nameof(Run)}(pipeServer, {pipeName}, {string.Join(",", args)})");
                Console.WriteLine($"[{DateTime.Now}] {id} Executing ParallelRunner:PipeServer.WaitForConnection()");

                pipeServer.WaitForConnection();



                var callData = MpiRunner.GetRemoteCallData(Target.Method, args);

                if (Logger.InfoEnabled)
                {
                    var debugJson = callData.DebugJson();
                    Logger.Info($"[{DateTime.Now}] {id} Sending call data to {pipeName} {threadIndex}: {debugJson}");
                }

                if(args!=null && args.Length> 0 && (int)args[0] != threadIndex)
                {
                    throw new Exception("Invalid arg for {threadIndex}: {args[0]}");
                }

                using (var bw = new BinaryWriter(pipeServer, Encoding.UTF8, true))
                {
                    byte[] callDataBytes = callData.ToByteArray();
                    bw.Write(callDataBytes.Length);
                    bw.Write(callDataBytes);
                }
                
                // will be executed remote on the client.
                //ExecuteAndSend(pipeName);
            }
        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, TResult> 
            : ParallelFunctionRunner<TResult>
        {

            private Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7>> argProvider = null!;

            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(int fromInclusive, int toExclusive, Func<T0, T1, T2, T3, T4, T5, T6, T7, TResult> target)
                : base(fromInclusive, toExclusive)
            {
                Target = target;
            }

            public Func<T0, T1, T2, T3, T4, T5, T6, T7, TResult> Target { get; }

            public TResult Execute(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            {
                var result = MpiRunner.Exec(Target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                return result;
            }

            
            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, TResult> 
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            {
                this.argProvider = (i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7));
                this.ArgProvider = this.argProvider;
                return this;
            }
          
            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7>> argProvider)
            {
                this.argProvider = argProvider;
                this.ArgProvider = this.argProvider;
                return this;
            }

            protected override void RunThread(NamedPipeServerStream pipeServer, string pipeName, int threadIndex, Func<int, IArgListProvider> argProvider)
            {
                var args = argProvider(threadIndex).ToArray();


                Console.WriteLine($"[{DateTime.Now}] {id} [Thread {threadIndex}] Executing ParallelRunner.{nameof(Run)}(pipeServer, {pipeName}, {string.Join(",", args)})");
                Console.WriteLine($"[{DateTime.Now}] {id} Executing ParallelRunner:PipeServer.WaitForConnection()");

                pipeServer.WaitForConnection();



                var callData = MpiRunner.GetRemoteCallData(Target.Method, args);

                if (Logger.InfoEnabled)
                {
                    var debugJson = callData.DebugJson();
                    Logger.Info($"[{DateTime.Now}] {id} Sending call data to {pipeName} {threadIndex}: {debugJson}");
                }

                if(args!=null && args.Length> 0 && (int)args[0] != threadIndex)
                {
                    throw new Exception("Invalid arg for {threadIndex}: {args[0]}");
                }

                using (var bw = new BinaryWriter(pipeServer, Encoding.UTF8, true))
                {
                    byte[] callDataBytes = callData.ToByteArray();
                    bw.Write(callDataBytes.Length);
                    bw.Write(callDataBytes);
                }
                
                // will be executed remote on the client.
                //ExecuteAndSend(pipeName);
            }
        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult> 
            : ParallelFunctionRunner<TResult>
        {

            private Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8>> argProvider = null!;

            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(int fromInclusive, int toExclusive, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult> target)
                : base(fromInclusive, toExclusive)
            {
                Target = target;
            }

            public Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult> Target { get; }

            public TResult Execute(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            {
                var result = MpiRunner.Exec(Target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                return result;
            }

            
            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult> 
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            {
                this.argProvider = (i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));
                this.ArgProvider = this.argProvider;
                return this;
            }
          
            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8>> argProvider)
            {
                this.argProvider = argProvider;
                this.ArgProvider = this.argProvider;
                return this;
            }

            protected override void RunThread(NamedPipeServerStream pipeServer, string pipeName, int threadIndex, Func<int, IArgListProvider> argProvider)
            {
                var args = argProvider(threadIndex).ToArray();


                Console.WriteLine($"[{DateTime.Now}] {id} [Thread {threadIndex}] Executing ParallelRunner.{nameof(Run)}(pipeServer, {pipeName}, {string.Join(",", args)})");
                Console.WriteLine($"[{DateTime.Now}] {id} Executing ParallelRunner:PipeServer.WaitForConnection()");

                pipeServer.WaitForConnection();



                var callData = MpiRunner.GetRemoteCallData(Target.Method, args);

                if (Logger.InfoEnabled)
                {
                    var debugJson = callData.DebugJson();
                    Logger.Info($"[{DateTime.Now}] {id} Sending call data to {pipeName} {threadIndex}: {debugJson}");
                }

                if(args!=null && args.Length> 0 && (int)args[0] != threadIndex)
                {
                    throw new Exception("Invalid arg for {threadIndex}: {args[0]}");
                }

                using (var bw = new BinaryWriter(pipeServer, Encoding.UTF8, true))
                {
                    byte[] callDataBytes = callData.ToByteArray();
                    bw.Write(callDataBytes.Length);
                    bw.Write(callDataBytes);
                }
                
                // will be executed remote on the client.
                //ExecuteAndSend(pipeName);
            }
        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> 
            : ParallelFunctionRunner<TResult>
        {

            private Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>> argProvider = null!;

            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(int fromInclusive, int toExclusive, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> target)
                : base(fromInclusive, toExclusive)
            {
                Target = target;
            }

            public Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> Target { get; }

            public TResult Execute(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
            {
                var result = MpiRunner.Exec(Target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                return result;
            }

            
            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> 
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
            {
                this.argProvider = (i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
                this.ArgProvider = this.argProvider;
                return this;
            }
          
            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>> argProvider)
            {
                this.argProvider = argProvider;
                this.ArgProvider = this.argProvider;
                return this;
            }

            protected override void RunThread(NamedPipeServerStream pipeServer, string pipeName, int threadIndex, Func<int, IArgListProvider> argProvider)
            {
                var args = argProvider(threadIndex).ToArray();


                Console.WriteLine($"[{DateTime.Now}] {id} [Thread {threadIndex}] Executing ParallelRunner.{nameof(Run)}(pipeServer, {pipeName}, {string.Join(",", args)})");
                Console.WriteLine($"[{DateTime.Now}] {id} Executing ParallelRunner:PipeServer.WaitForConnection()");

                pipeServer.WaitForConnection();



                var callData = MpiRunner.GetRemoteCallData(Target.Method, args);

                if (Logger.InfoEnabled)
                {
                    var debugJson = callData.DebugJson();
                    Logger.Info($"[{DateTime.Now}] {id} Sending call data to {pipeName} {threadIndex}: {debugJson}");
                }

                if(args!=null && args.Length> 0 && (int)args[0] != threadIndex)
                {
                    throw new Exception("Invalid arg for {threadIndex}: {args[0]}");
                }

                using (var bw = new BinaryWriter(pipeServer, Encoding.UTF8, true))
                {
                    byte[] callDataBytes = callData.ToByteArray();
                    bw.Write(callDataBytes.Length);
                    bw.Write(callDataBytes);
                }
                
                // will be executed remote on the client.
                //ExecuteAndSend(pipeName);
            }
        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> 
            : ParallelFunctionRunner<TResult>
        {

            private Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> argProvider = null!;

            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(int fromInclusive, int toExclusive, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> target)
                : base(fromInclusive, toExclusive)
            {
                Target = target;
            }

            public Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> Target { get; }

            public TResult Execute(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
            {
                var result = MpiRunner.Exec(Target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                return result;
            }

            
            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> 
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
            {
                this.argProvider = (i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10));
                this.ArgProvider = this.argProvider;
                return this;
            }
          
            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> argProvider)
            {
                this.argProvider = argProvider;
                this.ArgProvider = this.argProvider;
                return this;
            }

            protected override void RunThread(NamedPipeServerStream pipeServer, string pipeName, int threadIndex, Func<int, IArgListProvider> argProvider)
            {
                var args = argProvider(threadIndex).ToArray();


                Console.WriteLine($"[{DateTime.Now}] {id} [Thread {threadIndex}] Executing ParallelRunner.{nameof(Run)}(pipeServer, {pipeName}, {string.Join(",", args)})");
                Console.WriteLine($"[{DateTime.Now}] {id} Executing ParallelRunner:PipeServer.WaitForConnection()");

                pipeServer.WaitForConnection();



                var callData = MpiRunner.GetRemoteCallData(Target.Method, args);

                if (Logger.InfoEnabled)
                {
                    var debugJson = callData.DebugJson();
                    Logger.Info($"[{DateTime.Now}] {id} Sending call data to {pipeName} {threadIndex}: {debugJson}");
                }

                if(args!=null && args.Length> 0 && (int)args[0] != threadIndex)
                {
                    throw new Exception("Invalid arg for {threadIndex}: {args[0]}");
                }

                using (var bw = new BinaryWriter(pipeServer, Encoding.UTF8, true))
                {
                    byte[] callDataBytes = callData.ToByteArray();
                    bw.Write(callDataBytes.Length);
                    bw.Write(callDataBytes);
                }
                
                // will be executed remote on the client.
                //ExecuteAndSend(pipeName);
            }
        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> 
            : ParallelFunctionRunner<TResult>
        {

            private Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> argProvider = null!;

            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(int fromInclusive, int toExclusive, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> target)
                : base(fromInclusive, toExclusive)
            {
                Target = target;
            }

            public Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> Target { get; }

            public TResult Execute(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
            {
                var result = MpiRunner.Exec(Target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                return result;
            }

            
            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> 
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
            {
                this.argProvider = (i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11));
                this.ArgProvider = this.argProvider;
                return this;
            }
          
            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> argProvider)
            {
                this.argProvider = argProvider;
                this.ArgProvider = this.argProvider;
                return this;
            }

            protected override void RunThread(NamedPipeServerStream pipeServer, string pipeName, int threadIndex, Func<int, IArgListProvider> argProvider)
            {
                var args = argProvider(threadIndex).ToArray();


                Console.WriteLine($"[{DateTime.Now}] {id} [Thread {threadIndex}] Executing ParallelRunner.{nameof(Run)}(pipeServer, {pipeName}, {string.Join(",", args)})");
                Console.WriteLine($"[{DateTime.Now}] {id} Executing ParallelRunner:PipeServer.WaitForConnection()");

                pipeServer.WaitForConnection();



                var callData = MpiRunner.GetRemoteCallData(Target.Method, args);

                if (Logger.InfoEnabled)
                {
                    var debugJson = callData.DebugJson();
                    Logger.Info($"[{DateTime.Now}] {id} Sending call data to {pipeName} {threadIndex}: {debugJson}");
                }

                if(args!=null && args.Length> 0 && (int)args[0] != threadIndex)
                {
                    throw new Exception("Invalid arg for {threadIndex}: {args[0]}");
                }

                using (var bw = new BinaryWriter(pipeServer, Encoding.UTF8, true))
                {
                    byte[] callDataBytes = callData.ToByteArray();
                    bw.Write(callDataBytes.Length);
                    bw.Write(callDataBytes);
                }
                
                // will be executed remote on the client.
                //ExecuteAndSend(pipeName);
            }
        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> 
            : ParallelFunctionRunner<TResult>
        {

            private Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> argProvider = null!;

            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(int fromInclusive, int toExclusive, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> target)
                : base(fromInclusive, toExclusive)
            {
                Target = target;
            }

            public Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> Target { get; }

            public TResult Execute(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
            {
                var result = MpiRunner.Exec(Target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                return result;
            }

            
            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> 
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
            {
                this.argProvider = (i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12));
                this.ArgProvider = this.argProvider;
                return this;
            }
          
            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> argProvider)
            {
                this.argProvider = argProvider;
                this.ArgProvider = this.argProvider;
                return this;
            }

            protected override void RunThread(NamedPipeServerStream pipeServer, string pipeName, int threadIndex, Func<int, IArgListProvider> argProvider)
            {
                var args = argProvider(threadIndex).ToArray();


                Console.WriteLine($"[{DateTime.Now}] {id} [Thread {threadIndex}] Executing ParallelRunner.{nameof(Run)}(pipeServer, {pipeName}, {string.Join(",", args)})");
                Console.WriteLine($"[{DateTime.Now}] {id} Executing ParallelRunner:PipeServer.WaitForConnection()");

                pipeServer.WaitForConnection();



                var callData = MpiRunner.GetRemoteCallData(Target.Method, args);

                if (Logger.InfoEnabled)
                {
                    var debugJson = callData.DebugJson();
                    Logger.Info($"[{DateTime.Now}] {id} Sending call data to {pipeName} {threadIndex}: {debugJson}");
                }

                if(args!=null && args.Length> 0 && (int)args[0] != threadIndex)
                {
                    throw new Exception("Invalid arg for {threadIndex}: {args[0]}");
                }

                using (var bw = new BinaryWriter(pipeServer, Encoding.UTF8, true))
                {
                    byte[] callDataBytes = callData.ToByteArray();
                    bw.Write(callDataBytes.Length);
                    bw.Write(callDataBytes);
                }
                
                // will be executed remote on the client.
                //ExecuteAndSend(pipeName);
            }
        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> 
            : ParallelFunctionRunner<TResult>
        {

            private Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> argProvider = null!;

            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(int fromInclusive, int toExclusive, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> target)
                : base(fromInclusive, toExclusive)
            {
                Target = target;
            }

            public Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> Target { get; }

            public TResult Execute(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
            {
                var result = MpiRunner.Exec(Target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                return result;
            }

            
            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> 
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
            {
                this.argProvider = (i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13));
                this.ArgProvider = this.argProvider;
                return this;
            }
          
            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> argProvider)
            {
                this.argProvider = argProvider;
                this.ArgProvider = this.argProvider;
                return this;
            }

            protected override void RunThread(NamedPipeServerStream pipeServer, string pipeName, int threadIndex, Func<int, IArgListProvider> argProvider)
            {
                var args = argProvider(threadIndex).ToArray();


                Console.WriteLine($"[{DateTime.Now}] {id} [Thread {threadIndex}] Executing ParallelRunner.{nameof(Run)}(pipeServer, {pipeName}, {string.Join(",", args)})");
                Console.WriteLine($"[{DateTime.Now}] {id} Executing ParallelRunner:PipeServer.WaitForConnection()");

                pipeServer.WaitForConnection();



                var callData = MpiRunner.GetRemoteCallData(Target.Method, args);

                if (Logger.InfoEnabled)
                {
                    var debugJson = callData.DebugJson();
                    Logger.Info($"[{DateTime.Now}] {id} Sending call data to {pipeName} {threadIndex}: {debugJson}");
                }

                if(args!=null && args.Length> 0 && (int)args[0] != threadIndex)
                {
                    throw new Exception("Invalid arg for {threadIndex}: {args[0]}");
                }

                using (var bw = new BinaryWriter(pipeServer, Encoding.UTF8, true))
                {
                    byte[] callDataBytes = callData.ToByteArray();
                    bw.Write(callDataBytes.Length);
                    bw.Write(callDataBytes);
                }
                
                // will be executed remote on the client.
                //ExecuteAndSend(pipeName);
            }
        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> 
            : ParallelFunctionRunner<TResult>
        {

            private Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> argProvider = null!;

            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(int fromInclusive, int toExclusive, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> target)
                : base(fromInclusive, toExclusive)
            {
                Target = target;
            }

            public Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> Target { get; }

            public TResult Execute(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
            {
                var result = MpiRunner.Exec(Target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                return result;
            }

            
            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> 
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
            {
                this.argProvider = (i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14));
                this.ArgProvider = this.argProvider;
                return this;
            }
          
            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> argProvider)
            {
                this.argProvider = argProvider;
                this.ArgProvider = this.argProvider;
                return this;
            }

            protected override void RunThread(NamedPipeServerStream pipeServer, string pipeName, int threadIndex, Func<int, IArgListProvider> argProvider)
            {
                var args = argProvider(threadIndex).ToArray();


                Console.WriteLine($"[{DateTime.Now}] {id} [Thread {threadIndex}] Executing ParallelRunner.{nameof(Run)}(pipeServer, {pipeName}, {string.Join(",", args)})");
                Console.WriteLine($"[{DateTime.Now}] {id} Executing ParallelRunner:PipeServer.WaitForConnection()");

                pipeServer.WaitForConnection();



                var callData = MpiRunner.GetRemoteCallData(Target.Method, args);

                if (Logger.InfoEnabled)
                {
                    var debugJson = callData.DebugJson();
                    Logger.Info($"[{DateTime.Now}] {id} Sending call data to {pipeName} {threadIndex}: {debugJson}");
                }

                if(args!=null && args.Length> 0 && (int)args[0] != threadIndex)
                {
                    throw new Exception("Invalid arg for {threadIndex}: {args[0]}");
                }

                using (var bw = new BinaryWriter(pipeServer, Encoding.UTF8, true))
                {
                    byte[] callDataBytes = callData.ToByteArray();
                    bw.Write(callDataBytes.Length);
                    bw.Write(callDataBytes);
                }
                
                // will be executed remote on the client.
                //ExecuteAndSend(pipeName);
            }
        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> 
            : ParallelFunctionRunner<TResult>
        {

            private Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> argProvider = null!;

            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(int fromInclusive, int toExclusive, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> target)
                : base(fromInclusive, toExclusive)
            {
                Target = target;
            }

            public Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> Target { get; }

            public TResult Execute(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
            {
                var result = MpiRunner.Exec(Target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                return result;
            }

            
            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> 
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
            {
                this.argProvider = (i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15));
                this.ArgProvider = this.argProvider;
                return this;
            }
          
            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> argProvider)
            {
                this.argProvider = argProvider;
                this.ArgProvider = this.argProvider;
                return this;
            }

            protected override void RunThread(NamedPipeServerStream pipeServer, string pipeName, int threadIndex, Func<int, IArgListProvider> argProvider)
            {
                var args = argProvider(threadIndex).ToArray();


                Console.WriteLine($"[{DateTime.Now}] {id} [Thread {threadIndex}] Executing ParallelRunner.{nameof(Run)}(pipeServer, {pipeName}, {string.Join(",", args)})");
                Console.WriteLine($"[{DateTime.Now}] {id} Executing ParallelRunner:PipeServer.WaitForConnection()");

                pipeServer.WaitForConnection();



                var callData = MpiRunner.GetRemoteCallData(Target.Method, args);

                if (Logger.InfoEnabled)
                {
                    var debugJson = callData.DebugJson();
                    Logger.Info($"[{DateTime.Now}] {id} Sending call data to {pipeName} {threadIndex}: {debugJson}");
                }

                if(args!=null && args.Length> 0 && (int)args[0] != threadIndex)
                {
                    throw new Exception("Invalid arg for {threadIndex}: {args[0]}");
                }

                using (var bw = new BinaryWriter(pipeServer, Encoding.UTF8, true))
                {
                    byte[] callDataBytes = callData.ToByteArray();
                    bw.Write(callDataBytes.Length);
                    bw.Write(callDataBytes);
                }
                
                // will be executed remote on the client.
                //ExecuteAndSend(pipeName);
            }
        }

#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
 
    #endregion

    }
}