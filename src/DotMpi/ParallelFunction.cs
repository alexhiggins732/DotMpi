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
using System.Text;
using System.IO.Pipes;

namespace DotMpi
{
    public partial class Mpi
    {
        public class ParallelFunction<TResult> : IParalellFunction
        {
            /// <summary>
            /// A function to be ran in parallel on multipe processors
            /// </summary>
            /// <param name="fromInclusive">The start index, inclusive.</param>
            /// <param name="toExclusive">The end index, exclusive.</param>
            /// <exception cref="ArgumentException"></exception>
            public ParallelFunction(int fromInclusive, int toExclusive)

            {
                this.Start = fromInclusive;
                this.End = toExclusive;

            }

            public int Start { get; internal set; }
            public int End { get; internal set; }
            public int NumThreads => End - Start;
            public Func<int, IArgProvider>? ArgProvider { get; protected set; }
            public Delegate? Delegate { get; protected set; }

            public FunctionRunner<TResult> Build()
                => new FunctionRunner<TResult>(this);
            public FunctionRunner<TResult> Run()
                => Build().Run();
  
        }
    }
}

