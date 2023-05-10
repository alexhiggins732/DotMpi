/*
 Copyright (c) 2023 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 
 
 Source code for this software can be found at https://github.com/alexhiggins732/DotMpi
 
 This software is licensce under GNU General Public License version 3 as described in the LICENSE
 file at https://github.com/alexhiggins732/DotMpi/LICENSE
 
 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System.Reflection;

namespace DotMpi
{
    public class SerializableMethodInfo : SerializableTypeInfo
    {
        public long FunctionPointer { get; set; }
        public int MetaDataToken { get; set; }
        public string MethodTypeFullName { get; set; } = null!;
        public string MethodTypeAssemblyFullName { get; set; } = null!;
        public SerializableMethodInfo() { }
        public SerializableMethodInfo(MethodBase method)
        {
            if (method is null)
            {
                throw new ArgumentNullException(nameof(method));
            }
            var declaringType = method.DeclaringType;

            // A method will always have declaring type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var assembly = declaringType.Assembly;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            var methodType = method.GetType();
            var methodTypeAssembly = methodType.Assembly;


#pragma warning disable CS8601 // Possible null reference assignment.
            TypeName = declaringType.FullName;
            AssemblyName = assembly.FullName;

            var methodPointer = method.MethodHandle.GetFunctionPointer();
            FunctionPointer = methodPointer.ToInt64();
            this.MetaDataToken = method.MetadataToken;
            MethodTypeAssemblyFullName = methodTypeAssembly.FullName;
            MethodTypeFullName = methodType.FullName;
#pragma warning restore CS8601 // Possible null reference assignment.
        }

        //public string AssemblyName { get; }

    }
}
