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
    /// <summary>
    /// Serializable value wrapper for exceptions of type <typeparamref name="TException"/>.
    /// </summary>
    /// <typeparam name="TException">The type of the exception.</typeparam>
    public class ErrorData<TException> : ErrorData
        where TException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorData{TException}"/> class.
        /// </summary>
        public ErrorData() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorData{TException}"/> class with the specified <paramref name="exception"/>.
        /// </summary>
        /// <param name="exception">The exception to wrap.</param>
        public ErrorData(TException exception)
            : base(exception)
        {

        }
    }

}
