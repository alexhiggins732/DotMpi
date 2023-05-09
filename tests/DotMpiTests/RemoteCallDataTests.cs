using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotMpi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotMpi.Tests
{
    [TestClass()]
    public class RemoteCallDataTests
    {
        [TestMethod()]
        public void RemoteCallDataTest()
        {
            var byteData = new byte[] { };
            Assert.ThrowsException<ArgumentException>(()=>
            {
                RemoteCallData data = byteData;
            });
        }
    }
}