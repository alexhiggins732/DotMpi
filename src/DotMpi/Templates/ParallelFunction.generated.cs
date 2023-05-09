/*
 Copyright (c) 2023 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 
 
 Source code for this software can be found at https://github.com/alexhiggins732/DotMpi
 
 This software is licensce under GNU General Public License version 3 as described in the LICENSE
 file at https://github.com/alexhiggins732/DotMpi/LICENSE
 
 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System.Diagnostics;
using System.IO.Pipes;

namespace DotMpi
{
    public partial class Mpi
    {
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, TResult>
            : ParallelFunction<TResult>
        {
            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(
                int fromInclusive,
                int toExclusive,
                Func<T0, TResult> target
                )
                : base(fromInclusive, toExclusive)
            {
                this.Target = target;
            }


            public new Func<int, ArgList<T0>> ArgProvider
            {
                get => (Func<int, ArgList<T0>>)base.ArgProvider;
                private set => base.ArgProvider = value;
            }

            public Func<T0, TResult> Target
            {
                get => (Func<T0, TResult>)base.Delegate;
                private set => base.Delegate = value;
            }


            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, TResult>
                WithArgs(Func<int, T0> value)
                => WithArgs(i => new(value(i)));

            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, TResult>
                WithArgs(T0 arg0)
                => WithArgs(i => new(arg0));

            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, TResult>
                WithArgs(Func<int, ArgList<T0>> argProvider)
            {
                this.ArgProvider = argProvider;
                return this;
            }


        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, TResult>
            : ParallelFunction<TResult>
        {
            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, TResult> target
                )
                : base(fromInclusive, toExclusive)
            {
                this.Target = target;
            }


            public new Func<int, ArgList<T0, T1>> ArgProvider
            {
                get => (Func<int, ArgList<T0, T1>>)base.ArgProvider;
                private set => base.ArgProvider = value;
            }

            public Func<T0, T1, TResult> Target
            {
                get => (Func<T0, T1, TResult>)base.Delegate;
                private set => base.Delegate = value;
            }


            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, TResult>
                WithArgs(T0 arg0, T1 arg1)
                => WithArgs(i => new(arg0, arg1));

            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, TResult>
                WithArgs(Func<int, ArgList<T0, T1>> argProvider)
            {
                this.ArgProvider = argProvider;
                return this;
            }


        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, TResult>
            : ParallelFunction<TResult>
        {
            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, TResult> target
                )
                : base(fromInclusive, toExclusive)
            {
                this.Target = target;
            }


            public new Func<int, ArgList<T0, T1, T2>> ArgProvider
            {
                get => (Func<int, ArgList<T0, T1, T2>>)base.ArgProvider;
                private set => base.ArgProvider = value;
            }

            public Func<T0, T1, T2, TResult> Target
            {
                get => (Func<T0, T1, T2, TResult>)base.Delegate;
                private set => base.Delegate = value;
            }


            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, TResult>
                WithArgs(T0 arg0, T1 arg1, T2 arg2)
                => WithArgs(i => new(arg0, arg1, arg2));

            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2>> argProvider)
            {
                this.ArgProvider = argProvider;
                return this;
            }


        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, TResult>
            : ParallelFunction<TResult>
        {
            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, TResult> target
                )
                : base(fromInclusive, toExclusive)
            {
                this.Target = target;
            }


            public new Func<int, ArgList<T0, T1, T2, T3>> ArgProvider
            {
                get => (Func<int, ArgList<T0, T1, T2, T3>>)base.ArgProvider;
                private set => base.ArgProvider = value;
            }

            public Func<T0, T1, T2, T3, TResult> Target
            {
                get => (Func<T0, T1, T2, T3, TResult>)base.Delegate;
                private set => base.Delegate = value;
            }


            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, TResult>
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
                => WithArgs(i => new(arg0, arg1, arg2, arg3));

            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3>> argProvider)
            {
                this.ArgProvider = argProvider;
                return this;
            }


        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, T4, TResult>
            : ParallelFunction<TResult>
        {
            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, TResult> target
                )
                : base(fromInclusive, toExclusive)
            {
                this.Target = target;
            }


            public new Func<int, ArgList<T0, T1, T2, T3, T4>> ArgProvider
            {
                get => (Func<int, ArgList<T0, T1, T2, T3, T4>>)base.ArgProvider;
                private set => base.ArgProvider = value;
            }

            public Func<T0, T1, T2, T3, T4, TResult> Target
            {
                get => (Func<T0, T1, T2, T3, T4, TResult>)base.Delegate;
                private set => base.Delegate = value;
            }


            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, TResult>
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
                => WithArgs(i => new(arg0, arg1, arg2, arg3, arg4));

            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3, T4>> argProvider)
            {
                this.ArgProvider = argProvider;
                return this;
            }


        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, T4, T5, TResult>
            : ParallelFunction<TResult>
        {
            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, TResult> target
                )
                : base(fromInclusive, toExclusive)
            {
                this.Target = target;
            }


            public new Func<int, ArgList<T0, T1, T2, T3, T4, T5>> ArgProvider
            {
                get => (Func<int, ArgList<T0, T1, T2, T3, T4, T5>>)base.ArgProvider;
                private set => base.ArgProvider = value;
            }

            public Func<T0, T1, T2, T3, T4, T5, TResult> Target
            {
                get => (Func<T0, T1, T2, T3, T4, T5, TResult>)base.Delegate;
                private set => base.Delegate = value;
            }


            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, TResult>
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
                => WithArgs(i => new(arg0, arg1, arg2, arg3, arg4, arg5));

            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3, T4, T5>> argProvider)
            {
                this.ArgProvider = argProvider;
                return this;
            }


        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, T4, T5, T6, TResult>
            : ParallelFunction<TResult>
        {
            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, TResult> target
                )
                : base(fromInclusive, toExclusive)
            {
                this.Target = target;
            }


            public new Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6>> ArgProvider
            {
                get => (Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6>>)base.ArgProvider;
                private set => base.ArgProvider = value;
            }

            public Func<T0, T1, T2, T3, T4, T5, T6, TResult> Target
            {
                get => (Func<T0, T1, T2, T3, T4, T5, T6, TResult>)base.Delegate;
                private set => base.Delegate = value;
            }


            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, TResult>
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
                => WithArgs(i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6));

            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6>> argProvider)
            {
                this.ArgProvider = argProvider;
                return this;
            }


        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, TResult>
            : ParallelFunction<TResult>
        {
            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, TResult> target
                )
                : base(fromInclusive, toExclusive)
            {
                this.Target = target;
            }


            public new Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7>> ArgProvider
            {
                get => (Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7>>)base.ArgProvider;
                private set => base.ArgProvider = value;
            }

            public Func<T0, T1, T2, T3, T4, T5, T6, T7, TResult> Target
            {
                get => (Func<T0, T1, T2, T3, T4, T5, T6, T7, TResult>)base.Delegate;
                private set => base.Delegate = value;
            }


            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, TResult>
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
                => WithArgs(i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7));

            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7>> argProvider)
            {
                this.ArgProvider = argProvider;
                return this;
            }


        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>
            : ParallelFunction<TResult>
        {
            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult> target
                )
                : base(fromInclusive, toExclusive)
            {
                this.Target = target;
            }


            public new Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8>> ArgProvider
            {
                get => (Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8>>)base.ArgProvider;
                private set => base.ArgProvider = value;
            }

            public Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult> Target
            {
                get => (Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>)base.Delegate;
                private set => base.Delegate = value;
            }


            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
                => WithArgs(i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));

            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8>> argProvider)
            {
                this.ArgProvider = argProvider;
                return this;
            }


        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
            : ParallelFunction<TResult>
        {
            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> target
                )
                : base(fromInclusive, toExclusive)
            {
                this.Target = target;
            }


            public new Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>> ArgProvider
            {
                get => (Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>>)base.ArgProvider;
                private set => base.ArgProvider = value;
            }

            public Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> Target
            {
                get => (Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)base.Delegate;
                private set => base.Delegate = value;
            }


            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
                => WithArgs(i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));

            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>> argProvider)
            {
                this.ArgProvider = argProvider;
                return this;
            }


        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
            : ParallelFunction<TResult>
        {
            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> target
                )
                : base(fromInclusive, toExclusive)
            {
                this.Target = target;
            }


            public new Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> ArgProvider
            {
                get => (Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>)base.ArgProvider;
                private set => base.ArgProvider = value;
            }

            public Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> Target
            {
                get => (Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>)base.Delegate;
                private set => base.Delegate = value;
            }


            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
                => WithArgs(i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10));

            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> argProvider)
            {
                this.ArgProvider = argProvider;
                return this;
            }


        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>
            : ParallelFunction<TResult>
        {
            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> target
                )
                : base(fromInclusive, toExclusive)
            {
                this.Target = target;
            }


            public new Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> ArgProvider
            {
                get => (Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>)base.ArgProvider;
                private set => base.ArgProvider = value;
            }

            public Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> Target
            {
                get => (Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>)base.Delegate;
                private set => base.Delegate = value;
            }


            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
                => WithArgs(i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11));

            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> argProvider)
            {
                this.ArgProvider = argProvider;
                return this;
            }


        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>
            : ParallelFunction<TResult>
        {
            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> target
                )
                : base(fromInclusive, toExclusive)
            {
                this.Target = target;
            }


            public new Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> ArgProvider
            {
                get => (Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>)base.ArgProvider;
                private set => base.ArgProvider = value;
            }

            public Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> Target
            {
                get => (Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>)base.Delegate;
                private set => base.Delegate = value;
            }


            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
                => WithArgs(i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12));

            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> argProvider)
            {
                this.ArgProvider = argProvider;
                return this;
            }


        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>
            : ParallelFunction<TResult>
        {
            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> target
                )
                : base(fromInclusive, toExclusive)
            {
                this.Target = target;
            }


            public new Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> ArgProvider
            {
                get => (Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>)base.ArgProvider;
                private set => base.ArgProvider = value;
            }

            public Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> Target
            {
                get => (Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>)base.Delegate;
                private set => base.Delegate = value;
            }


            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
                => WithArgs(i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13));

            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> argProvider)
            {
                this.ArgProvider = argProvider;
                return this;
            }


        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>
            : ParallelFunction<TResult>
        {
            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> target
                )
                : base(fromInclusive, toExclusive)
            {
                this.Target = target;
            }


            public new Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> ArgProvider
            {
                get => (Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>)base.ArgProvider;
                private set => base.ArgProvider = value;
            }

            public Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> Target
            {
                get => (Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>)base.Delegate;
                private set => base.Delegate = value;
            }


            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
                => WithArgs(i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14));

            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> argProvider)
            {
                this.ArgProvider = argProvider;
                return this;
            }


        }


        /// <summary>
        /// Multi processor parallel runner
        /// </summary>
        public class ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>
            : ParallelFunction<TResult>
        {
            /// <summary>
            /// Multi processor parallel runner
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(
                int fromInclusive,
                int toExclusive,
                Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> target
                )
                : base(fromInclusive, toExclusive)
            {
                this.Target = target;
            }


            public new Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> ArgProvider
            {
                get => (Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>)base.ArgProvider;
                private set => base.ArgProvider = value;
            }

            public Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> Target
            {
                get => (Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>)base.Delegate;
                private set => base.Delegate = value;
            }


            /// <summary>
            /// Registers a strongly typed generic arguments to provide to each process
            /// </summary>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>
                WithArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
                => WithArgs(i => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15));

            /// <summary>
            /// Registers a delegate function to provide arguments for each process.
            /// </summary>
            /// <param name="argProvider">Delegate function to provide arguments for each process.</param>
            /// <returns></returns>
            public ParallelFunction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>
                WithArgs(Func<int, ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> argProvider)
            {
                this.ArgProvider = argProvider;
                return this;
            }


        }

#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    }
}