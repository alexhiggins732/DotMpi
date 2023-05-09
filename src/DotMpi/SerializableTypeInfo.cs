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
    public class SerializableTypeInfo
    {
        public string AssemblyName { get; set; } = null!;
        public string TypeName { get; set; } = null!;
        public SerializableTypeInfo()
        {

        }
        public SerializableTypeInfo(Type type)
        {
            if (type is null) throw new ArgumentNullException(nameof(type));
            //Type wil have assembly and fullname
#pragma warning disable CS8601 // Possible null reference assignment.
            AssemblyName = type.Assembly.FullName;
            TypeName = type.FullName;
#pragma warning restore CS8601 // Possible null reference assignment.

        }
    }
}
