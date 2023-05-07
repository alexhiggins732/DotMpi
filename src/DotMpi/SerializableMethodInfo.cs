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
            var declaringType = method.DeclaringType;
            if (declaringType is null
                || declaringType.FullName is null)
            {
                throw new Exception("Method must have an declaring type with resolvable with a full name");
            }
            var assembly = declaringType.Assembly;
            if (assembly is null
            || assembly.FullName is null)
            {
                throw new Exception("Method declaring type must have assembly resovable with a full name");
            }
            var methodType = method.GetType();
            if (methodType is null
                || methodType.FullName is null)
            {
                throw new Exception("Method must have type must have assembly resovable with a full name");
            }

            var methodTypeAssembly = methodType.Assembly;
            if (methodTypeAssembly is null
                || methodTypeAssembly.FullName is null)
            {
                throw new Exception("Method Assembly must have type must have assembly resovable with a full name");
            }

            TypeName = declaringType.FullName;
            AssemblyName = assembly.FullName;
            var methodPointer = method.MethodHandle.GetFunctionPointer();
            FunctionPointer = methodPointer.ToInt64();
            this.MetaDataToken = method.MetadataToken;
            MethodTypeAssemblyFullName = methodTypeAssembly.FullName;
            MethodTypeFullName = methodType.FullName;
        }

        //public string AssemblyName { get; }

    }
}
