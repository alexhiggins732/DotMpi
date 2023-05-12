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
    /// Serializable Value wrapper for Exceptions
    /// </summary>
    public class ErrorData : SerializableValue
    {
        public ErrorData() { }
        public ErrorData(Exception value)
            : base(value)
        {
        }

        /// <summary>
        /// Creates an exception wrapper of <see cref="ErrorData{TException}"/> type with the specified <paramref name="caught"/> exception for use with IPC communication
        /// </summary>
        /// <typeparam name="TException">The type of the exception to wrap.</typeparam>
        /// <param name="caught">The exception to wrap.</param>
        /// <returns>An <see cref="ErrorData"/> object wrapping the specified exception.</returns>
        internal static ErrorData? Create<TException>(TException caught)
            where TException : Exception
        {
            var data = new ErrorData<TException>(caught);
            return data;
        }

        /// <summary>
        /// Converts the <see cref="ErrorData"/> instance to an <see cref="Exception"/> instance.
        /// </summary>
        /// <param name="value">The <see cref="ErrorData"/> instance to convert.</param>
        /// <returns>The <see cref="Exception"/> instance represented by the <see cref="ErrorData"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown if the <paramref name="value"/> parameter is not an <see cref="ErrorData"/> instance.</exception>
        internal static Exception ToException(ErrorData value)
        {
            if (value is SerializableValue exceptionData
                && value.ObjectValue is not null
                && value.ObjectValue is Exception exception)
            {
                return exception;
            }
            else
            {
                throw new ArgumentException("Value must be an Error Data", nameof(value));
            }
        }

        /// <summary>
        /// Converts the current <see cref="ErrorData"/> instance to an <see cref="Exception"/>.
        /// </summary>
        /// <returns>The <see cref="Exception"/> instance represented by the current <see cref="ErrorData"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="SerializableValue.ObjectValue"/> property of the current <see cref="ErrorData"/> instance is not an <see cref="Exception"/>.</exception>

        public Exception ToException()
        {
            if (this.ObjectValue is not null && this.ObjectValue is Exception exception)
                return exception;
            throw new ArgumentException("ObjectValue must be an exception", nameof(ObjectValue));
        }
    }

}
