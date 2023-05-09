/*
 Copyright (c) 2023 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 
 
 Source code for this software can be found at https://github.com/alexhiggins732/DotMpi
 
 This software is licensce under GNU General Public License version 3 as described in the LICENSE
 file at https://github.com/alexhiggins732/DotMpi/LICENSE
 
 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using Newtonsoft.Json;
using System.Text;
using System.Text.Unicode;

namespace DotMpi
{
    public class RemoteCallData
    {
        public SerializableValue[] ArgInfo { get; set; }
        public SerializableMethodInfo MethodInfo { get; set; }
        public SerializableTypeInfo ReturnInfo { get; set; }


        public RemoteCallData(
            SerializableMethodInfo methodInfo,
            SerializableTypeInfo returnInfo,
            params SerializableValue[] argInfo
            )
        {
            MethodInfo = methodInfo;
            ReturnInfo = returnInfo;
            ArgInfo = argInfo.ToArray();
        }

        internal byte[] ToByteArray()
        {
            var json = JsonConvert.SerializeObject(this);
            var bytes = Encoding.UTF8.GetBytes(json);
            return bytes;
        }

        internal string DebugJson()
        {
            var debugData = (new[] { this })
                   .Select(x => new
                   {
                       Args = string.Join(", ", x.ArgInfo.Select(x => x.ObjectValue)),
                       ReturnType = x.ReturnInfo.TypeName,
                       Method = x.MethodInfo.TypeName,

                   });
            return JsonConvert.SerializeObject(debugData);
        }


        public static implicit operator byte[](RemoteCallData data) 
            => data.ToByteArray();

        public static implicit operator RemoteCallData(byte[] data)
        {
            var json = Encoding.UTF8.GetString(data);
            var result = JsonConvert.DeserializeObject<RemoteCallData>(json);
            if (result is null)
            {
                throw new ArgumentException($"Failed to read {nameof(RemoteCallData)} from json:{json}");
            }
            return result;
        }

    }
}
