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
using System.Diagnostics;

namespace DotMpi
{
    public partial class Mpi
    {

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
   
    }
}