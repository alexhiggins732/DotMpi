using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotMpi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;

namespace DotMpi.Tests
{
    [TestClass()]
    public class SerializableMethodInfoTests
    {
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        [TestMethod]
        public void TestNullMethodType()
        {
            // Arrange

            MethodBase method = null;

            var exceptionMsg = "Value cannot be null. (Parameter 'method')";

            // Act & Assert

            var ex = Assert.ThrowsException<ArgumentNullException>(() => new SerializableMethodInfo(method));


            Assert.AreEqual(exceptionMsg, ex.Message);
        }

        [TestMethod]
        public void TestNullType()
        {
            // Arrange
            Type type = null;
            var exceptionMsg = "Value cannot be null. (Parameter 'type')";

            // Act & Assert
            var ex = Assert.ThrowsException<ArgumentNullException>(() => new SerializableTypeInfo(type));

            Assert.AreEqual(exceptionMsg, ex.Message);
        }

        [TestMethod]
        public void TestSerializableValue()
        {
            // Arrange
            var value = new SerializableValue<string>();

            Assert.IsNull(value.Result);
        }
    }
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8604 // Possible null reference argument.
}