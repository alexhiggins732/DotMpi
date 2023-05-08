using System.IO.Pipes;
using System.Text;


namespace DotMpi
{


    public partial class Mpi
    {
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        
        public interface IArgProvider
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
            : IArgProvider
        {
            public T0 Arg0 {get;}
            
            public ArgList(T0 arg0)
            {
                this.Arg0 = arg0;
                
            }

            public object[] ToArray() => new object[] { Arg0 };
            public static implicit operator object[](ArgList<T0> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1>
            : IArgProvider
        {
            public T0 Arg0 {get;}
            public T1 Arg1 {get;}
            
            public ArgList(T0 arg0, T1 arg1)
            {
                this.Arg0 = arg0;
                this.Arg1 = arg1;
                
            }

            public object[] ToArray() => new object[] { Arg0, Arg1 };
            public static implicit operator object[](ArgList<T0, T1> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2>
            : IArgProvider
        {
            public T0 Arg0 {get;}
            public T1 Arg1 {get;}
            public T2 Arg2 {get;}
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2)
            {
                this.Arg0 = arg0;
                this.Arg1 = arg1;
                this.Arg2 = arg2;
                
            }

            public object[] ToArray() => new object[] { Arg0, Arg1, Arg2 };
            public static implicit operator object[](ArgList<T0, T1, T2> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3>
            : IArgProvider
        {
            public T0 Arg0 {get;}
            public T1 Arg1 {get;}
            public T2 Arg2 {get;}
            public T3 Arg3 {get;}
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
            {
                this.Arg0 = arg0;
                this.Arg1 = arg1;
                this.Arg2 = arg2;
                this.Arg3 = arg3;
                
            }

            public object[] ToArray() => new object[] { Arg0, Arg1, Arg2, Arg3 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3, T4>
            : IArgProvider
        {
            public T0 Arg0 {get;}
            public T1 Arg1 {get;}
            public T2 Arg2 {get;}
            public T3 Arg3 {get;}
            public T4 Arg4 {get;}
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            {
                this.Arg0 = arg0;
                this.Arg1 = arg1;
                this.Arg2 = arg2;
                this.Arg3 = arg3;
                this.Arg4 = arg4;
                
            }

            public object[] ToArray() => new object[] { Arg0, Arg1, Arg2, Arg3, Arg4 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3, T4> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3, T4, T5>
            : IArgProvider
        {
            public T0 Arg0 {get;}
            public T1 Arg1 {get;}
            public T2 Arg2 {get;}
            public T3 Arg3 {get;}
            public T4 Arg4 {get;}
            public T5 Arg5 {get;}
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            {
                this.Arg0 = arg0;
                this.Arg1 = arg1;
                this.Arg2 = arg2;
                this.Arg3 = arg3;
                this.Arg4 = arg4;
                this.Arg5 = arg5;
                
            }

            public object[] ToArray() => new object[] { Arg0, Arg1, Arg2, Arg3, Arg4, Arg5 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3, T4, T5> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3, T4, T5, T6>
            : IArgProvider
        {
            public T0 Arg0 {get;}
            public T1 Arg1 {get;}
            public T2 Arg2 {get;}
            public T3 Arg3 {get;}
            public T4 Arg4 {get;}
            public T5 Arg5 {get;}
            public T6 Arg6 {get;}
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            {
                this.Arg0 = arg0;
                this.Arg1 = arg1;
                this.Arg2 = arg2;
                this.Arg3 = arg3;
                this.Arg4 = arg4;
                this.Arg5 = arg5;
                this.Arg6 = arg6;
                
            }

            public object[] ToArray() => new object[] { Arg0, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3, T4, T5, T6> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3, T4, T5, T6, T7>
            : IArgProvider
        {
            public T0 Arg0 {get;}
            public T1 Arg1 {get;}
            public T2 Arg2 {get;}
            public T3 Arg3 {get;}
            public T4 Arg4 {get;}
            public T5 Arg5 {get;}
            public T6 Arg6 {get;}
            public T7 Arg7 {get;}
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            {
                this.Arg0 = arg0;
                this.Arg1 = arg1;
                this.Arg2 = arg2;
                this.Arg3 = arg3;
                this.Arg4 = arg4;
                this.Arg5 = arg5;
                this.Arg6 = arg6;
                this.Arg7 = arg7;
                
            }

            public object[] ToArray() => new object[] { Arg0, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3, T4, T5, T6, T7> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8>
            : IArgProvider
        {
            public T0 Arg0 {get;}
            public T1 Arg1 {get;}
            public T2 Arg2 {get;}
            public T3 Arg3 {get;}
            public T4 Arg4 {get;}
            public T5 Arg5 {get;}
            public T6 Arg6 {get;}
            public T7 Arg7 {get;}
            public T8 Arg8 {get;}
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            {
                this.Arg0 = arg0;
                this.Arg1 = arg1;
                this.Arg2 = arg2;
                this.Arg3 = arg3;
                this.Arg4 = arg4;
                this.Arg5 = arg5;
                this.Arg6 = arg6;
                this.Arg7 = arg7;
                this.Arg8 = arg8;
                
            }

            public object[] ToArray() => new object[] { Arg0, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>
            : IArgProvider
        {
            public T0 Arg0 {get;}
            public T1 Arg1 {get;}
            public T2 Arg2 {get;}
            public T3 Arg3 {get;}
            public T4 Arg4 {get;}
            public T5 Arg5 {get;}
            public T6 Arg6 {get;}
            public T7 Arg7 {get;}
            public T8 Arg8 {get;}
            public T9 Arg9 {get;}
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
            {
                this.Arg0 = arg0;
                this.Arg1 = arg1;
                this.Arg2 = arg2;
                this.Arg3 = arg3;
                this.Arg4 = arg4;
                this.Arg5 = arg5;
                this.Arg6 = arg6;
                this.Arg7 = arg7;
                this.Arg8 = arg8;
                this.Arg9 = arg9;
                
            }

            public object[] ToArray() => new object[] { Arg0, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
            : IArgProvider
        {
            public T0 Arg0 {get;}
            public T1 Arg1 {get;}
            public T2 Arg2 {get;}
            public T3 Arg3 {get;}
            public T4 Arg4 {get;}
            public T5 Arg5 {get;}
            public T6 Arg6 {get;}
            public T7 Arg7 {get;}
            public T8 Arg8 {get;}
            public T9 Arg9 {get;}
            public T10 Arg10 {get;}
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
            {
                this.Arg0 = arg0;
                this.Arg1 = arg1;
                this.Arg2 = arg2;
                this.Arg3 = arg3;
                this.Arg4 = arg4;
                this.Arg5 = arg5;
                this.Arg6 = arg6;
                this.Arg7 = arg7;
                this.Arg8 = arg8;
                this.Arg9 = arg9;
                this.Arg10 = arg10;
                
            }

            public object[] ToArray() => new object[] { Arg0, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9, Arg10 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
            : IArgProvider
        {
            public T0 Arg0 {get;}
            public T1 Arg1 {get;}
            public T2 Arg2 {get;}
            public T3 Arg3 {get;}
            public T4 Arg4 {get;}
            public T5 Arg5 {get;}
            public T6 Arg6 {get;}
            public T7 Arg7 {get;}
            public T8 Arg8 {get;}
            public T9 Arg9 {get;}
            public T10 Arg10 {get;}
            public T11 Arg11 {get;}
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
            {
                this.Arg0 = arg0;
                this.Arg1 = arg1;
                this.Arg2 = arg2;
                this.Arg3 = arg3;
                this.Arg4 = arg4;
                this.Arg5 = arg5;
                this.Arg6 = arg6;
                this.Arg7 = arg7;
                this.Arg8 = arg8;
                this.Arg9 = arg9;
                this.Arg10 = arg10;
                this.Arg11 = arg11;
                
            }

            public object[] ToArray() => new object[] { Arg0, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9, Arg10, Arg11 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
            : IArgProvider
        {
            public T0 Arg0 {get;}
            public T1 Arg1 {get;}
            public T2 Arg2 {get;}
            public T3 Arg3 {get;}
            public T4 Arg4 {get;}
            public T5 Arg5 {get;}
            public T6 Arg6 {get;}
            public T7 Arg7 {get;}
            public T8 Arg8 {get;}
            public T9 Arg9 {get;}
            public T10 Arg10 {get;}
            public T11 Arg11 {get;}
            public T12 Arg12 {get;}
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
            {
                this.Arg0 = arg0;
                this.Arg1 = arg1;
                this.Arg2 = arg2;
                this.Arg3 = arg3;
                this.Arg4 = arg4;
                this.Arg5 = arg5;
                this.Arg6 = arg6;
                this.Arg7 = arg7;
                this.Arg8 = arg8;
                this.Arg9 = arg9;
                this.Arg10 = arg10;
                this.Arg11 = arg11;
                this.Arg12 = arg12;
                
            }

            public object[] ToArray() => new object[] { Arg0, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9, Arg10, Arg11, Arg12 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
            : IArgProvider
        {
            public T0 Arg0 {get;}
            public T1 Arg1 {get;}
            public T2 Arg2 {get;}
            public T3 Arg3 {get;}
            public T4 Arg4 {get;}
            public T5 Arg5 {get;}
            public T6 Arg6 {get;}
            public T7 Arg7 {get;}
            public T8 Arg8 {get;}
            public T9 Arg9 {get;}
            public T10 Arg10 {get;}
            public T11 Arg11 {get;}
            public T12 Arg12 {get;}
            public T13 Arg13 {get;}
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
            {
                this.Arg0 = arg0;
                this.Arg1 = arg1;
                this.Arg2 = arg2;
                this.Arg3 = arg3;
                this.Arg4 = arg4;
                this.Arg5 = arg5;
                this.Arg6 = arg6;
                this.Arg7 = arg7;
                this.Arg8 = arg8;
                this.Arg9 = arg9;
                this.Arg10 = arg10;
                this.Arg11 = arg11;
                this.Arg12 = arg12;
                this.Arg13 = arg13;
                
            }

            public object[] ToArray() => new object[] { Arg0, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9, Arg10, Arg11, Arg12, Arg13 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
            : IArgProvider
        {
            public T0 Arg0 {get;}
            public T1 Arg1 {get;}
            public T2 Arg2 {get;}
            public T3 Arg3 {get;}
            public T4 Arg4 {get;}
            public T5 Arg5 {get;}
            public T6 Arg6 {get;}
            public T7 Arg7 {get;}
            public T8 Arg8 {get;}
            public T9 Arg9 {get;}
            public T10 Arg10 {get;}
            public T11 Arg11 {get;}
            public T12 Arg12 {get;}
            public T13 Arg13 {get;}
            public T14 Arg14 {get;}
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
            {
                this.Arg0 = arg0;
                this.Arg1 = arg1;
                this.Arg2 = arg2;
                this.Arg3 = arg3;
                this.Arg4 = arg4;
                this.Arg5 = arg5;
                this.Arg6 = arg6;
                this.Arg7 = arg7;
                this.Arg8 = arg8;
                this.Arg9 = arg9;
                this.Arg10 = arg10;
                this.Arg11 = arg11;
                this.Arg12 = arg12;
                this.Arg13 = arg13;
                this.Arg14 = arg14;
                
            }

            public object[] ToArray() => new object[] { Arg0, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9, Arg10, Arg11, Arg12, Arg13, Arg14 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> argList)
                => argList.ToArray();
        }

        public class ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
            : IArgProvider
        {
            public T0 Arg0 {get;}
            public T1 Arg1 {get;}
            public T2 Arg2 {get;}
            public T3 Arg3 {get;}
            public T4 Arg4 {get;}
            public T5 Arg5 {get;}
            public T6 Arg6 {get;}
            public T7 Arg7 {get;}
            public T8 Arg8 {get;}
            public T9 Arg9 {get;}
            public T10 Arg10 {get;}
            public T11 Arg11 {get;}
            public T12 Arg12 {get;}
            public T13 Arg13 {get;}
            public T14 Arg14 {get;}
            public T15 Arg15 {get;}
            
            public ArgList(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
            {
                this.Arg0 = arg0;
                this.Arg1 = arg1;
                this.Arg2 = arg2;
                this.Arg3 = arg3;
                this.Arg4 = arg4;
                this.Arg5 = arg5;
                this.Arg6 = arg6;
                this.Arg7 = arg7;
                this.Arg8 = arg8;
                this.Arg9 = arg9;
                this.Arg10 = arg10;
                this.Arg11 = arg11;
                this.Arg12 = arg12;
                this.Arg13 = arg13;
                this.Arg14 = arg14;
                this.Arg15 = arg15;
                
            }

            public object[] ToArray() => new object[] { Arg0, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9, Arg10, Arg11, Arg12, Arg13, Arg14, Arg15 };
            public static implicit operator object[](ArgList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> argList)
                => argList.ToArray();
        }

#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}