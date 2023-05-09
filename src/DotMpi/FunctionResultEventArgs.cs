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
        /// <summary>
        /// Provides data for the <see cref="FunctionResultReturned"/> event.
        /// </summary>
        /// <typeparam name="TResult">The type of the function result.</typeparam>
        public class FunctionResultEventArgs<TResult> : EventArgs
        {
            /// <summary>
            /// Gets the index of the thread that returned the result.
            /// </summary>
            public int ThreadIndex { get; }

            /// <summary>
            /// Gets the ID of the process that the thread was running in.
            /// </summary>
            public int ProcessId { get; }

            /// <summary>
            /// Gets the name of the named pipe that was used for communication.
            /// </summary>
            public string PipeName { get; }

            /// <summary>
            /// Gets the argument provider used to supply arguments for the executed parallel function.
            /// </summary>
            public IArgProvider ArgProvider { get; }

            /// <summary>
            /// Gets the function result as a nullable value.
            /// </summary>
            public TResult? Result { get => SerializedResult.Result; }

            /// <summary>
            /// Gets the function result as a serializable value.
            /// </summary>
            public SerializableValue<TResult?> SerializedResult { get; }

            /// <summary>
            /// Initializes a new instance of the <see cref="FunctionResultEventArgs{TResult}"/> class
            /// with the specified arguments.
            /// </summary>
            /// <param name="threadIndex">The index of the thread that returned the result.</param>
            /// <param name="processId">The ID of the process that the thread was running in.</param>
            /// <param name="pipeName">The name of the named pipe that was used for communication.</param>
            /// <param name="argProvider">The provider used to supply arguments to the function.</param>
            /// <param name="result">The function result as a serializable value.</param>
            public FunctionResultEventArgs(
                int threadIndex,
                int processId,
                string pipeName,
                IArgProvider argProvider,
                SerializableValue<TResult?> result)
            {
                ThreadIndex = threadIndex;
                ProcessId = processId;
                PipeName = pipeName;
                ArgProvider = argProvider;
                SerializedResult = result;
            }
        }


        /// <summary>
        /// Provides data for the <see cref="FunctionResultReturned"/> event.
        /// </summary>
        /// <typeparam name="TResult">The type of the function result.</typeparam>
        public class FunctionInvokedEventArgs<TResult> : EventArgs
        {
            /// <summary>
            /// Gets the index of the thread that returned the result.
            /// </summary>
            public int ThreadIndex { get; }

            /// <summary>
            /// Gets the ID of the process that the thread was running in.
            /// </summary>
            public int ProcessId { get; }

            /// <summary>
            /// Gets the name of the named pipe that was used for communication.
            /// </summary>
            public string PipeName { get; }

            /// <summary>
            /// Gets the argument provider used to supply arguments for the executed parallel function.
            /// </summary>
            public IArgProvider ArgProvider { get; }

            /// <summary>
            /// Gets the function call data sent to the invoke the function
            /// </summary>
            public RemoteCallData FunctionCallData {get;}



            /// <summary>
            /// Initializes a new instance of the <see cref="FunctionResultEventArgs{TResult}"/> class
            /// with the specified arguments.
            /// </summary>
            /// <param name="threadIndex">The index of the thread that returned the result.</param>
            /// <param name="processId">The ID of the process that the thread was running in.</param>
            /// <param name="pipeName">The name of the named pipe that was used for communication.</param>
            /// <param name="argProvider">The provider used to supply arguments to the function.</param>
            /// <param name="functionCallData">The function call data sent to the invoke the function.</param>
            public FunctionInvokedEventArgs(
                int threadIndex,
                int processId,
                string pipeName,
                IArgProvider argProvider,
                RemoteCallData functionCallData)
            {
                ThreadIndex = threadIndex;
                ProcessId = processId;
                PipeName = pipeName;
                ArgProvider = argProvider;
                FunctionCallData = functionCallData;
            }
        }

    }
}

