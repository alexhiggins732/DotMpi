﻿/*
 Copyright (c) 2023 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 
 
 Source code for this software can be found at https://github.com/alexhiggins732/DotMpi
 
 This software is licensce under GNU General Public License version 3 as described in the LICENSE
 file at https://github.com/alexhiggins732/DotMpi/LICENSE
 
 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Reflection;

namespace DotMpi
{
    public class ValueConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(SerializableValue).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);
            var assemblyToken = jsonObject[nameof(SerializableValue.AssemblyName)];
            if (assemblyToken is null)
            {
                throw new ArgumentException($"{nameof(SerializableValue.AssemblyName)} not set");
            }
            var typeToken = jsonObject[nameof(SerializableValue.TypeName)];
            if (typeToken is null)
            {
                throw new ArgumentException($"{nameof(SerializableValue.TypeName)} not set");
            }

            //what? nameof(SerializableValue.Value)
            var valueToken = jsonObject["Value"];
            if (valueToken is null)
            {
                throw new ArgumentException("Value not set");
            }
            string assemblyName = assemblyToken.ToString();
            string typeName = typeToken.ToString();
            var asm = Assembly.Load(assemblyName);
            var type = asm.GetType(typeName);
            if (type is null)
            {
                throw new TypeLoadException($"Failed to resolve type '{typeName}, {assemblyName}'");
            }



            JToken value = valueToken;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Converting null literal or possible null value to non-nullable type.
            object valueObject = null!;
            if (value != null)
                valueObject = value.ToObject(type);

            SerializableValue result = null!;
            if (objectType.IsGenericType)
            {
                var t = typeof(SerializableValue<>).MakeGenericType(type);
                ConstructorInfo constructor = t.GetConstructor(new Type[] { type });
#pragma warning disable CS8601 // Possible null reference assignment.
                object serializableValue = constructor.Invoke(new object[] { valueObject }); // creates a SerializableValue<int> with value 
#pragma warning restore CS8601 // Possible null reference assignment.
                result = (SerializableValue)serializableValue;
            }
            else
            {
                result = new SerializableValue(valueObject);
            }
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8602 // Converting null literal or possible null value to non-nullable type.


            var errorToken = jsonObject[nameof(SerializableValue.ErrorData)];
            if (errorToken != null && errorToken is JObject errorObject)
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                result.ErrorData = (ErrorData)errorToken.ToObject(typeof(ErrorData));
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            }

            return result;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value is not null)
            {
                var argInfo = (SerializableValue)value;
                writer.WriteStartObject();
                writer.WritePropertyName("AssemblyName");
                writer.WriteValue(argInfo.AssemblyName);
                writer.WritePropertyName("TypeName");
                writer.WriteValue(argInfo.TypeName);
                writer.WritePropertyName("Value");
                serializer.Serialize(writer, argInfo.ObjectValue);
                if (argInfo.ErrorData != null)
                {
                    writer.WritePropertyName("ErrorData");
                    serializer.Serialize(writer, argInfo.ErrorData);
                }
                writer.WriteEndObject();
            }
        }
    }


}
