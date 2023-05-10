/*
 Copyright (c) 2023 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 
 
 Source code for this software can be found at https://github.com/alexhiggins732/DotMpi
 
 This software is licensce under GNU General Public License version 3 as described in the LICENSE
 file at https://github.com/alexhiggins732/DotMpi/LICENSE
 
 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotMpi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DotMpi.Tests
{
    [TestClass()]
    public class ValueConverterTests
    {
        [TestMethod()]
        public void CanConvertTest()
        {
            var convert = new ValueConverter();
            var ser = new SerializableValue(1);
            var serT = new SerializableValue<int>(1);

            Assert.IsTrue(convert.CanConvert(ser.GetType()));
            Assert.IsTrue(convert.CanConvert(serT.GetType()));
            Assert.IsFalse(convert.CanConvert(typeof(int)));
        }

        [TestMethod()]
        public void ReadJsonTest()
        {
            var ser = new SerializableValue(1);
            var jsonFull = JsonConvert.SerializeObject(ser);



            var json = "{}";
            Assert.ThrowsException<ArgumentException>(() => JsonConvert.DeserializeObject<SerializableValue>(json));

            json = "{\"AssemblyName\":\"System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e\"}";
            Assert.ThrowsException<ArgumentException>(() => JsonConvert.DeserializeObject<SerializableValue>(json));

            json = "{\"AssemblyName\":\"System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e\",\"TypeName\":\"System.Int32\"}";
            Assert.ThrowsException<ArgumentException>(() => JsonConvert.DeserializeObject<SerializableValue>(json));

            json = "{\"AssemblyName\":\"System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e\",\"TypeName\":\"System.Int32a\",\"Value\":\"1\"}";
            Assert.ThrowsException<TypeLoadException>(() => JsonConvert.DeserializeObject<SerializableValue>(json));

            json = "{\"AssemblyName\":\"System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e\",\"TypeName\":\"System.String\",\"Value\":null}";
            var result = JsonConvert.DeserializeObject<SerializableValue>(json);
            Assert.IsNotNull(result);
            Assert.IsNull(result.ObjectValue);


        }

        [TestMethod()]
        public void WriteJsonTest()
        {
            var json = "{\"AssemblyName\":\"System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e\",\"TypeName\":\"System.String\",\"Value\":null}";
            var result = JsonConvert.DeserializeObject<SerializableValue<string>>(json);
            Assert.IsNotNull(result);
            Assert.IsNull(result.ObjectValue);

            var resultJson = JsonConvert.SerializeObject(result);
            var comp = json.CompareTo(resultJson);
            Assert.AreEqual(json, resultJson);

            result = null;
            var nullJson = JsonConvert.SerializeObject(result);
            Assert.IsTrue(nullJson == "null");

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            SerializableValue a = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            var t = new { b = "tests", a = a };
            json = JsonConvert.SerializeObject(a);
            Assert.IsNotNull(json);

        }



        public class WithNoPublicConstructor<T>
        {
            T Value;
            public WithNoPublicConstructor(T value) { Value = value; }
        }
        [TestMethod()]
        public void ParallelFunction_ConvertToJson()
        {
            var value = new WithNoPublicConstructor<int>(1);

            var ser = new SerializableValue<WithNoPublicConstructor<int>>(value);
            var json = JsonConvert.SerializeObject(ser);
            var objectFromJson = JsonConvert.DeserializeObject<SerializableValue<WithNoPublicConstructor<int>>>(json);

            Assert.IsNotNull(objectFromJson);
        }

    }
}