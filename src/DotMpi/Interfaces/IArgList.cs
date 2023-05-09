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
        public interface IArgProvider
        {
            object[] ToArray();
        }
    }

    public partial class Mpi
    {
        public interface IParalellFunction
        {
            int Start { get; }
            int End { get; }
            int NumThreads { get; }
            Delegate? Delegate { get; }
            Func<int, IArgProvider>? ArgProvider { get; }
        }
    }
}
