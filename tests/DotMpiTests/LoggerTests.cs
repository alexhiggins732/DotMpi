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
using System.IO;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

namespace DotMpi.Tests
{
    [TestClass()]
    public class LoggerTests
    {
        [TestMethod()]
        public void InstanceLoggerTest()
        {
            var logger = Logger.Instance;
            logger.DebugEnabled = false;
            logger.InfoEnabled = false;
            logger.ErrorEnabled = false;
            logger.VerboseEnabled = false;


            Assert.IsFalse(logger.DebugEnabled);
            Assert.IsFalse(logger.InfoEnabled);
            Assert.IsFalse(logger.ErrorEnabled);
            Assert.IsFalse(logger.VerboseEnabled);

            logger.DebugEnabled = true;
            logger.InfoEnabled = true;
            logger.ErrorEnabled = true;
            logger.VerboseEnabled = true;

            Assert.IsTrue(logger.DebugEnabled);
            Assert.IsTrue(logger.InfoEnabled);
            Assert.IsTrue(logger.ErrorEnabled);
            Assert.IsTrue(logger.VerboseEnabled);


            Logger.StaticDebugEnabled = false;
            Logger.StaticInfoEnabled = false;
            Logger.StaticErrorEnabled = false;
            Logger.StaticVerboseEnabled = false;


            Assert.IsFalse(logger.DebugEnabled);
            Assert.IsFalse(logger.InfoEnabled);
            Assert.IsFalse(logger.ErrorEnabled);
            Assert.IsFalse(logger.VerboseEnabled);

            Logger.StaticDebugEnabled = true;
            Logger.StaticInfoEnabled = true;
            Logger.StaticErrorEnabled = true;
            Logger.StaticVerboseEnabled = true;

            Assert.IsTrue(logger.DebugEnabled);
            Assert.IsTrue(logger.InfoEnabled);
            Assert.IsTrue(logger.ErrorEnabled);
            Assert.IsTrue(logger.VerboseEnabled);

        }

        [TestMethod()]
        public void LoggerTest()
        {
            Logger logger = new(false, false, false, false);
            Assert.IsFalse(logger.DebugEnabled);
            Assert.IsFalse(logger.InfoEnabled);
            Assert.IsFalse(logger.ErrorEnabled);
            Assert.IsFalse(logger.VerboseEnabled);

            logger.DebugEnabled = true;
            logger.InfoEnabled = true;
            logger.ErrorEnabled = true;
            logger.VerboseEnabled = true;

            Assert.IsTrue(logger.DebugEnabled);
            Assert.IsTrue(logger.InfoEnabled);
            Assert.IsTrue(logger.ErrorEnabled);
            Assert.IsTrue(logger.VerboseEnabled);
        }


        [TestMethod()]
        public void DebugTest()
        {
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms, Encoding.UTF8);
            Logger logger = new(false, false, false, false, writer);


            logger.Debug("Test");
            writer.Flush();
            Assert.AreEqual(3, ms.Length, "Stream should only have byte encoding data set");

            logger.DebugEnabled = true;
            logger.Debug("Test");
            writer.Flush();

            ms.Position = 0;
            var reader = new StreamReader(ms, Encoding.UTF8);
            string result = reader.ReadToEnd();
            Assert.IsTrue(result.Contains($"[{nameof(logger.Debug)}] Test"));

        }

        [TestMethod()]
        public void VerboseTest()
        {
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms, Encoding.UTF8);
            Logger logger = new(false, false, false, false, writer);

            logger.Verbose("Test");
            writer.Flush();
            Assert.AreEqual(3, ms.Length, "Stream should only have byte encoding data set");

            logger.VerboseEnabled = true;
            logger.Verbose("Test");
            writer.Flush();

            ms.Position = 0;
            var reader = new StreamReader(ms, Encoding.UTF8);
            string result = reader.ReadToEnd();
            Assert.IsTrue(result.Contains($"[{nameof(logger.Verbose)}] Test"));
        }


        [TestMethod()]
        public void InfoTest()
        {
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms, Encoding.UTF8);
            Logger logger = new(false, false, false, false, writer);

            logger.Info("Test");
            writer.Flush();
            Assert.AreEqual(3, ms.Length, "Stream should only have byte encoding data set");

            logger.InfoEnabled = true;
            logger.Info("Test");
            writer.Flush();

            ms.Position = 0;
            var reader = new StreamReader(ms, Encoding.UTF8);
            string result = reader.ReadToEnd();
            Assert.IsTrue(result.Contains($"[{nameof(logger.Info)}] Test"));

        }



        [TestMethod()]
        public void ErrorTest()
        {
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms, Encoding.UTF8);
            Logger logger = new(false, false, false, false, writer);

            logger.Error("Test");
            writer.Flush();
            Assert.AreEqual(3, ms.Length, "Stream should only have byte encoding data set");

            logger.ErrorEnabled = true;
            logger.Error("Test");
            writer.Flush();

            ms.Position = 0;
            var reader = new StreamReader(ms, Encoding.UTF8);
            string result = reader.ReadToEnd();
            Assert.IsTrue(result.Contains($"[{nameof(logger.Error)}] Test"));

        }


        [TestMethod()]
        public void ErrorTest1()
        {
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms, Encoding.UTF8);
            Logger logger = new(false, false, false, false, writer);

            logger.Error("Test", new Exception("Test Exception"));
            writer.Flush();
            Assert.AreEqual(3, ms.Length, "Stream should only have byte encoding data set");

            logger.ErrorEnabled = true;
            logger.Error("Test", new Exception("Test Exception"));
            writer.Flush();
            Assert.IsTrue(ms.Length > 4);

            ms.Position = 0;
            var reader = new StreamReader(ms, Encoding.UTF8);
            string result = reader.ReadToEnd();
            Assert.IsTrue(result.Contains($"[{nameof(logger.Error)}] Test"));
            Assert.IsTrue(result.IndexOf("Test Exception") > 17);
        }

    }
}