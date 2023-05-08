/*
 Copyright (c) 2023 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 
 
 Source code for this software can be found at https://github.com/alexhiggins732/DotMpi
 
 This software is licensce under GNU General Public License version 3 as described in the LICENSE
 file at https://github.com/alexhiggins732/DotMpi/LICENSE
 
 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System.Text.Json.Serialization;

namespace DotMpi
{

    public class SerializableValue<TResult> : SerializableValue
    {
        public TResult? Result => (TResult?)ObjectValue;
        public SerializableValue() { }
        public SerializableValue(TResult? value)
            : base()
        {
            var type = value?.GetType() ?? typeof(TResult);
            if (type is null || type.FullName is null)
            {
                throw new Exception("Type must have a full name");
            }
            if (type.Assembly is null || type.Assembly.FullName is null)
            {
                throw new Exception("Type must have an assembly resolvable with a full name");
            }
            AssemblyName = type.Assembly.FullName;
            TypeName = type.FullName;
            ObjectValue = value;
        }

    }
}
