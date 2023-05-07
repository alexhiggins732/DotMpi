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
    internal partial class MpiRunner
    {

#pragma warning disable CS8604 // Possible null reference argument.

        public static TResult Exec<T0, TResult>
            (Func<T0, TResult> fn,
            T0 arg0)
                => Exec<TResult>(fn.Method, arg0);


        public static TResult Exec<T0, T1, TResult>
            (Func<T0, T1, TResult> fn,
            T0 arg0, T1 arg1)
                => Exec<TResult>(fn.Method, arg0, arg1);


        public static TResult Exec<T0, T1, T2, TResult>
            (Func<T0, T1, T2, TResult> fn,
            T0 arg0, T1 arg1, T2 arg2)
                => Exec<TResult>(fn.Method, arg0, arg1, arg2);


        public static TResult Exec<T0, T1, T2, T3, TResult>
            (Func<T0, T1, T2, T3, TResult> fn,
            T0 arg0, T1 arg1, T2 arg2, T3 arg3)
                => Exec<TResult>(fn.Method, arg0, arg1, arg2, arg3);


        public static TResult Exec<T0, T1, T2, T3, T4, TResult>
            (Func<T0, T1, T2, T3, T4, TResult> fn,
            T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
                => Exec<TResult>(fn.Method, arg0, arg1, arg2, arg3, arg4);


        public static TResult Exec<T0, T1, T2, T3, T4, T5, TResult>
            (Func<T0, T1, T2, T3, T4, T5, TResult> fn,
            T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
                => Exec<TResult>(fn.Method, arg0, arg1, arg2, arg3, arg4, arg5);


        public static TResult Exec<T0, T1, T2, T3, T4, T5, T6, TResult>
            (Func<T0, T1, T2, T3, T4, T5, T6, TResult> fn,
            T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
                => Exec<TResult>(fn.Method, arg0, arg1, arg2, arg3, arg4, arg5, arg6);


        public static TResult Exec<T0, T1, T2, T3, T4, T5, T6, T7, TResult>
            (Func<T0, T1, T2, T3, T4, T5, T6, T7, TResult> fn,
            T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
                => Exec<TResult>(fn.Method, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);


        public static TResult Exec<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>
            (Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult> fn,
            T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
                => Exec<TResult>(fn.Method, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);


        public static TResult Exec<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
            (Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> fn,
            T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
                => Exec<TResult>(fn.Method, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);


        public static TResult Exec<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
            (Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fn,
            T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
                => Exec<TResult>(fn.Method, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);


        public static TResult Exec<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>
            (Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> fn,
            T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
                => Exec<TResult>(fn.Method, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);


        public static TResult Exec<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>
            (Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> fn,
            T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
                => Exec<TResult>(fn.Method, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);


        public static TResult Exec<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>
            (Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> fn,
            T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
                => Exec<TResult>(fn.Method, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);


        public static TResult Exec<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>
            (Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> fn,
            T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
                => Exec<TResult>(fn.Method, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);


        public static TResult Exec<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>
            (Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> fn,
            T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
                => Exec<TResult>(fn.Method, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);

#pragma warning restore CS8604 // Possible null reference argument.

    }
}