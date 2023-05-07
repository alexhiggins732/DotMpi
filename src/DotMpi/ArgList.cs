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
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        
        public interface IArgListProvider
        {
            object[] ToArray();
        }
        
        public partial class ArgList
        {
  
            public static ArgList<T0> 
                Create<T0>
                (T0 arg0)
                => new(arg0);
               
  
            public static ArgList<T0, T1> 
                Create<T0, T1>
                (T0 arg0, T1 arg1)
                => new(arg0, arg1);
               
  
            public static ArgList<T0, T1, T2> 
                Create<T0, T1, T2>
                (T0 arg0, T1 arg1, T2 arg2)
                => new(arg0, arg1, arg2);
               
  
            public static ArgList<T0, T1, T2, T3> 
                Create<T0, T1, T2, T3>
                (T0 arg0, T1 arg1, T2 arg2, T3 arg3)
                => new(arg0, arg1, arg2, arg3);
               
  
            public static ArgList<T0, T1, T2, T3, T4> 
                Create<T0, T1, T2, T3, T4>
                (T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
                => new(arg0, arg1, arg2, arg3, arg4);
               
  
            public static ArgList<T0, T1, T2, T3, T4, T5> 
                Create<T0, T1, T2, T3, T4, T5>
                (T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
                => new(arg0, arg1, arg2, arg3, arg4, arg5);
               
  
            public static ArgList<T0, T1, T2, T3, T4, T5, T6> 
                Create<T0, T1, T2, T3, T4, T5, T6>
                (T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
                => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
               
  
            public static ArgList<T0, T1, T2, T3, T4, T5, T6, T7> 
                Create<T0, T1, T2, T3, T4, T5, T6, T7>
                (T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
                => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
               
  
            public static ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8> 
                Create<T0, T1, T2, T3, T4, T5, T6, T7, T8>
                (T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
                => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
               
  
            public static ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> 
                Create<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>
                (T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
                => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
               
  
            public static ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> 
                Create<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
                (T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
                => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
               
  
            public static ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> 
                Create<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
                (T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
                => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
               
  
            public static ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> 
                Create<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
                (T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
                => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
               
  
            public static ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> 
                Create<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
                (T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
                => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
               
  
            public static ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> 
                Create<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
                (T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
                => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
               
  
            public static ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> 
                Create<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
                (T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
                => new(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
               
    }

        public class ArgList<T0>
            : IArgListProvider
        {
            T0 arg0;
            
            public ArgList(T0 arg0)
            {
                this.arg0 = arg0;
                
            }

            public object[] ToArray() => new object[] { arg0 };
            public static implicit operator object[](ArgList<T0> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1>
            : IArgListProvider
        {
            T0 arg0;
            T1 arg1;
            
            public ArgList(T0 arg0, T1 arg1)
            {
                this.arg0 = arg0;
                this.arg1 = arg1;
                
            }

            public object[] ToArray() => new object[] { arg0, arg1 };
            public static implicit operator object[](ArgList<T0, T1> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2>
            : IArgListProvider
        {
            T0 arg0;
            T1 arg1;
            T2 arg2;
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2)
            {
                this.arg0 = arg0;
                this.arg1 = arg1;
                this.arg2 = arg2;
                
            }

            public object[] ToArray() => new object[] { arg0, arg1, arg2 };
            public static implicit operator object[](ArgList<T0, T1, T2> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3>
            : IArgListProvider
        {
            T0 arg0;
            T1 arg1;
            T2 arg2;
            T3 arg3;
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
            {
                this.arg0 = arg0;
                this.arg1 = arg1;
                this.arg2 = arg2;
                this.arg3 = arg3;
                
            }

            public object[] ToArray() => new object[] { arg0, arg1, arg2, arg3 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3, T4>
            : IArgListProvider
        {
            T0 arg0;
            T1 arg1;
            T2 arg2;
            T3 arg3;
            T4 arg4;
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            {
                this.arg0 = arg0;
                this.arg1 = arg1;
                this.arg2 = arg2;
                this.arg3 = arg3;
                this.arg4 = arg4;
                
            }

            public object[] ToArray() => new object[] { arg0, arg1, arg2, arg3, arg4 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3, T4> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3, T4, T5>
            : IArgListProvider
        {
            T0 arg0;
            T1 arg1;
            T2 arg2;
            T3 arg3;
            T4 arg4;
            T5 arg5;
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            {
                this.arg0 = arg0;
                this.arg1 = arg1;
                this.arg2 = arg2;
                this.arg3 = arg3;
                this.arg4 = arg4;
                this.arg5 = arg5;
                
            }

            public object[] ToArray() => new object[] { arg0, arg1, arg2, arg3, arg4, arg5 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3, T4, T5> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3, T4, T5, T6>
            : IArgListProvider
        {
            T0 arg0;
            T1 arg1;
            T2 arg2;
            T3 arg3;
            T4 arg4;
            T5 arg5;
            T6 arg6;
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            {
                this.arg0 = arg0;
                this.arg1 = arg1;
                this.arg2 = arg2;
                this.arg3 = arg3;
                this.arg4 = arg4;
                this.arg5 = arg5;
                this.arg6 = arg6;
                
            }

            public object[] ToArray() => new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3, T4, T5, T6> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3, T4, T5, T6, T7>
            : IArgListProvider
        {
            T0 arg0;
            T1 arg1;
            T2 arg2;
            T3 arg3;
            T4 arg4;
            T5 arg5;
            T6 arg6;
            T7 arg7;
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            {
                this.arg0 = arg0;
                this.arg1 = arg1;
                this.arg2 = arg2;
                this.arg3 = arg3;
                this.arg4 = arg4;
                this.arg5 = arg5;
                this.arg6 = arg6;
                this.arg7 = arg7;
                
            }

            public object[] ToArray() => new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3, T4, T5, T6, T7> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8>
            : IArgListProvider
        {
            T0 arg0;
            T1 arg1;
            T2 arg2;
            T3 arg3;
            T4 arg4;
            T5 arg5;
            T6 arg6;
            T7 arg7;
            T8 arg8;
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            {
                this.arg0 = arg0;
                this.arg1 = arg1;
                this.arg2 = arg2;
                this.arg3 = arg3;
                this.arg4 = arg4;
                this.arg5 = arg5;
                this.arg6 = arg6;
                this.arg7 = arg7;
                this.arg8 = arg8;
                
            }

            public object[] ToArray() => new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>
            : IArgListProvider
        {
            T0 arg0;
            T1 arg1;
            T2 arg2;
            T3 arg3;
            T4 arg4;
            T5 arg5;
            T6 arg6;
            T7 arg7;
            T8 arg8;
            T9 arg9;
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
            {
                this.arg0 = arg0;
                this.arg1 = arg1;
                this.arg2 = arg2;
                this.arg3 = arg3;
                this.arg4 = arg4;
                this.arg5 = arg5;
                this.arg6 = arg6;
                this.arg7 = arg7;
                this.arg8 = arg8;
                this.arg9 = arg9;
                
            }

            public object[] ToArray() => new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
            : IArgListProvider
        {
            T0 arg0;
            T1 arg1;
            T2 arg2;
            T3 arg3;
            T4 arg4;
            T5 arg5;
            T6 arg6;
            T7 arg7;
            T8 arg8;
            T9 arg9;
            T10 arg10;
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
            {
                this.arg0 = arg0;
                this.arg1 = arg1;
                this.arg2 = arg2;
                this.arg3 = arg3;
                this.arg4 = arg4;
                this.arg5 = arg5;
                this.arg6 = arg6;
                this.arg7 = arg7;
                this.arg8 = arg8;
                this.arg9 = arg9;
                this.arg10 = arg10;
                
            }

            public object[] ToArray() => new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
            : IArgListProvider
        {
            T0 arg0;
            T1 arg1;
            T2 arg2;
            T3 arg3;
            T4 arg4;
            T5 arg5;
            T6 arg6;
            T7 arg7;
            T8 arg8;
            T9 arg9;
            T10 arg10;
            T11 arg11;
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
            {
                this.arg0 = arg0;
                this.arg1 = arg1;
                this.arg2 = arg2;
                this.arg3 = arg3;
                this.arg4 = arg4;
                this.arg5 = arg5;
                this.arg6 = arg6;
                this.arg7 = arg7;
                this.arg8 = arg8;
                this.arg9 = arg9;
                this.arg10 = arg10;
                this.arg11 = arg11;
                
            }

            public object[] ToArray() => new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
            : IArgListProvider
        {
            T0 arg0;
            T1 arg1;
            T2 arg2;
            T3 arg3;
            T4 arg4;
            T5 arg5;
            T6 arg6;
            T7 arg7;
            T8 arg8;
            T9 arg9;
            T10 arg10;
            T11 arg11;
            T12 arg12;
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
            {
                this.arg0 = arg0;
                this.arg1 = arg1;
                this.arg2 = arg2;
                this.arg3 = arg3;
                this.arg4 = arg4;
                this.arg5 = arg5;
                this.arg6 = arg6;
                this.arg7 = arg7;
                this.arg8 = arg8;
                this.arg9 = arg9;
                this.arg10 = arg10;
                this.arg11 = arg11;
                this.arg12 = arg12;
                
            }

            public object[] ToArray() => new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
            : IArgListProvider
        {
            T0 arg0;
            T1 arg1;
            T2 arg2;
            T3 arg3;
            T4 arg4;
            T5 arg5;
            T6 arg6;
            T7 arg7;
            T8 arg8;
            T9 arg9;
            T10 arg10;
            T11 arg11;
            T12 arg12;
            T13 arg13;
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
            {
                this.arg0 = arg0;
                this.arg1 = arg1;
                this.arg2 = arg2;
                this.arg3 = arg3;
                this.arg4 = arg4;
                this.arg5 = arg5;
                this.arg6 = arg6;
                this.arg7 = arg7;
                this.arg8 = arg8;
                this.arg9 = arg9;
                this.arg10 = arg10;
                this.arg11 = arg11;
                this.arg12 = arg12;
                this.arg13 = arg13;
                
            }

            public object[] ToArray() => new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
            : IArgListProvider
        {
            T0 arg0;
            T1 arg1;
            T2 arg2;
            T3 arg3;
            T4 arg4;
            T5 arg5;
            T6 arg6;
            T7 arg7;
            T8 arg8;
            T9 arg9;
            T10 arg10;
            T11 arg11;
            T12 arg12;
            T13 arg13;
            T14 arg14;
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
            {
                this.arg0 = arg0;
                this.arg1 = arg1;
                this.arg2 = arg2;
                this.arg3 = arg3;
                this.arg4 = arg4;
                this.arg5 = arg5;
                this.arg6 = arg6;
                this.arg7 = arg7;
                this.arg8 = arg8;
                this.arg9 = arg9;
                this.arg10 = arg10;
                this.arg11 = arg11;
                this.arg12 = arg12;
                this.arg13 = arg13;
                this.arg14 = arg14;
                
            }

            public object[] ToArray() => new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
            : IArgListProvider
        {
            T0 arg0;
            T1 arg1;
            T2 arg2;
            T3 arg3;
            T4 arg4;
            T5 arg5;
            T6 arg6;
            T7 arg7;
            T8 arg8;
            T9 arg9;
            T10 arg10;
            T11 arg11;
            T12 arg12;
            T13 arg13;
            T14 arg14;
            T15 arg15;
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
            {
                this.arg0 = arg0;
                this.arg1 = arg1;
                this.arg2 = arg2;
                this.arg3 = arg3;
                this.arg4 = arg4;
                this.arg5 = arg5;
                this.arg6 = arg6;
                this.arg7 = arg7;
                this.arg8 = arg8;
                this.arg9 = arg9;
                this.arg10 = arg10;
                this.arg11 = arg11;
                this.arg12 = arg12;
                this.arg13 = arg13;
                this.arg14 = arg14;
                this.arg15 = arg15;
                
            }

            public object[] ToArray() => new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> argList)
                => argList.ToArray();
        }

#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}