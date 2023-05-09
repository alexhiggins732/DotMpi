using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotMpi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO.Pipes;

namespace DotMpi.MpiTests
{
    public partial class MpiTests
    {
        [TestClass()]
        public class MpiRunnerTests
        {
            [TestMethod()]
            public void RemoteCall_InvalidInstanceFuncTest()
            {
                Func<int, string> target = i => $"test {i}";

                var ex = Assert.ThrowsException<ArgumentException>(() => MpiRunner.GetRemoteCallData(target.Method));
                Assert.AreEqual("Can only execute static methods remotely", ex.Message);

            }

            [TestMethod()]
            public void RemoteCall_StaticTest()
            {
                Func<int, string> target = For;
                var data = MpiRunner.GetRemoteCallData(target.Method, 0);
                Assert.IsNotNull(data);
            }

            static string TimeoutTest(int arg)
            {
                Thread.Sleep(1000);
                return string.Empty;
            }


            [TestMethod()]
            public void RemoteCall_TimesOut()
            {
                Func<int, string> target = TimeoutTest;
                var timeout = TimeSpan.FromTicks(1);
                var ex = Assert.ThrowsException<TimeoutException>(() => Mpi.ParallelFor(1, target, 0).Run().Wait(timeout));
                Assert.IsTrue(ex.Message.StartsWith("Wait operation timed out after"));
            }



            [TestMethod()]
            public void RemoteCall_StaticDelegateTest()
            {
                Func<int, string> target = For;
                Delegate d = target;
                var data = MpiRunner.GetRemoteCallData(d.Method, 0);
                Assert.IsNotNull(data);

            }

            [TestMethod()]
            public void RemoteCall_StaticDelegate2Test()
            {
                Delegate d = (Func<int, string>)For;
                var data = MpiRunner.GetRemoteCallData(d.Method, 0);
                Assert.IsNotNull(data);

            }

            static string NotFoundMethod(int i) => $"{i}";
            [TestMethod()]
            public void RemoteCall_DirectMethod()
            {
                var method = this.GetType().GetMethod(nameof(NotFoundMethod));
                var ex = Assert.ThrowsException<ArgumentNullException>(() => MpiRunner.GetRemoteCallData(method, 0));
                Assert.AreEqual("Value cannot be null. (Parameter 'method')", ex.Message);

                method = this.GetType().GetMethod(nameof(NotFoundMethod), System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
                var data = MpiRunner.GetRemoteCallData(method, 0);
                Assert.IsNotNull(data);
                Assert.AreEqual(data.MethodInfo.MetaDataToken, method.MetadataToken);
            }

            [TestMethod()]
            public void GetArgInfos()
            {
                var info = MpiRunner.GetArgInfos();
                Assert.IsNotNull(info);
                Assert.IsTrue(info.Length == 0);

                info = MpiRunner.GetArgInfos(null);
                Assert.IsNotNull(info);
                Assert.IsTrue(info.Length == 0);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                var ex = Assert.ThrowsException<ArgumentNullException>(() => MpiRunner.GetArgInfos(new object[] { null }));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                Assert.IsNotNull(ex.Message);

                info = MpiRunner.GetArgInfos(1, "test");
                Assert.IsNotNull(info);


            }


            [TestMethod()]
            public void HandleRemoteCallTest()
            {
                Exception ex = Assert.ThrowsException<ArgumentNullException>(() => MpiRunner.HandleRemoteCall(null));
                Assert.AreEqual("Value cannot be null. (Parameter 'json')", ex.Message);


                ex = Assert.ThrowsException<JsonSerializationException>(() => MpiRunner.HandleRemoteCall("{"));
                Assert.IsTrue(ex.Message.StartsWith("Unexpected end when reading JSON"));

                ex = Assert.ThrowsException<ArgumentException>(() => MpiRunner.HandleRemoteCall("null"));
                Assert.IsTrue(ex.Message.StartsWith("Failed to deserialize Remote call data from json"));
            }


            static string StaticFnTest() => "Thread 0";
            [TestMethod()]
            public void ExecuteRemoteCallTest()
            {
                var debugEnabled = MpiRunner.Logger.DebugEnabled;
                var infoEnabled = MpiRunner.Logger.InfoEnabled;
                var verboseEnabled = MpiRunner.Logger.VerboseEnabled;

                MpiRunner.Logger.DebugEnabled
                    = MpiRunner.Logger.InfoEnabled
                    = MpiRunner.Logger.VerboseEnabled
                    = true;

                Func<int, string> target = For;
                var data = MpiRunner.GetRemoteCallData(target.Method, 0);
                Assert.IsNotNull(data);


                var result = MpiRunner.ExecuteRemoteCall<string>(data);
                Assert.IsTrue(result.StartsWith("Thread 0"));


                var result2 = MpiRunner.Exec<string>(target.Method, 0);
                Assert.IsNotNull(result2);
                Assert.IsTrue(result2.StartsWith("Thread 0"));




                data.MethodInfo.MetaDataToken = 0;

                Exception ex = Assert.ThrowsException<ArgumentException>(() => MpiRunner.ExecuteRemoteCall<string>(data));
                Assert.IsTrue(ex.Message.StartsWith("Token 0x00000000 is not a valid MethodBase token in the scope of module"));

                data.MethodInfo.MetaDataToken = data.MethodInfo.MetaDataToken - 50;

                ex = Assert.ThrowsException<ArgumentException>(() => MpiRunner.ExecuteRemoteCall<string>(data));
                var metaDataTokenHex = data.MethodInfo.MetaDataToken.ToString("x2");
                Assert.IsTrue(ex.Message.StartsWith($"Token 0x{metaDataTokenHex} is not a valid MethodBase token in the scope of module"));



                Func<string> fn = () => result2;
                ex = Assert.ThrowsException<ArgumentException>(() => MpiRunner.Exec(fn));
                Assert.AreEqual("Can only execute static methods remotely", ex.Message);


                Func<string> fn2 = StaticFnTest;
                var result3 = MpiRunner.Exec(fn2);
                Assert.IsTrue(result3.StartsWith("Thread 0"));


                MpiRunner.Logger.DebugEnabled = debugEnabled;
                MpiRunner.Logger.InfoEnabled = infoEnabled;
                MpiRunner.Logger.VerboseEnabled = verboseEnabled;
            }

            [TestMethod()]
            public void HandleRemoteCallTest2()
            {

                using var toBeWrittenTo = new MemoryStream();
                using var toBeReadStream = new MemoryStream();
                using var toBeReadWriter = new BinaryWriter(toBeReadStream);
                using var writer = new BinaryWriter(toBeWrittenTo);
                using var reader = new BinaryReader(toBeReadStream);
                using var writtenToReader = new BinaryReader(toBeWrittenTo);
                var pipe = "Test-HandleRemoteCallTest2";
                var threadIndex = 0;


                Func<int, string> target = For;
                var data = MpiRunner.GetRemoteCallData(target.Method, 0);
                var dataBytes = (byte[])data;
                toBeReadWriter.Write(dataBytes.Length);
                toBeReadWriter.Write(dataBytes);
                toBeReadWriter.Flush();
                toBeReadStream.Position = 0;

                var infoEnabled = MpiRunner.Logger.InfoEnabled;
                MpiRunner.Logger.InfoEnabled = true;
                MpiRunner.HandleRemoteCall(writer, reader, pipe, threadIndex);
                MpiRunner.Logger.InfoEnabled = infoEnabled;

                toBeWrittenTo.Position = 0;
                var resultLength = writtenToReader.ReadInt32();
                var resultData = writtenToReader.ReadBytes(resultLength);
                var resultJson = Encoding.UTF8.GetString(resultData);
                var serializedResult = JsonConvert.DeserializeObject<SerializableValue<string>>(resultJson);
                Assert.IsNotNull(serializedResult);
                var result = serializedResult.Result;
                Assert.IsNotNull(result);
                Assert.IsTrue(result.StartsWith("Thread 0"));


                toBeReadStream.Position = 0;
                dataBytes = Encoding.UTF8.GetBytes("null");
                toBeReadWriter.Write(dataBytes.Length);
                toBeReadWriter.Write(dataBytes);
                toBeReadWriter.Flush();
                toBeReadStream.Position = 0;
                toBeWrittenTo.Position = 0;
                infoEnabled = MpiRunner.Logger.InfoEnabled;
                MpiRunner.Logger.InfoEnabled = true;
                var ex = Assert.ThrowsException<ArgumentException>(() =>
                     MpiRunner.HandleRemoteCall(writer, reader, pipe, threadIndex));
                MpiRunner.Logger.InfoEnabled = infoEnabled;


            }

            static string ThrowException(int i) => throw new NotImplementedException();
            [TestMethod()]
            public void ProcessThrowsException()
            {
                Func<int, string> target = ThrowException;

                var result = Mpi.ParallelFor(1, ThrowException, 0).Run().Wait();

                Assert.IsTrue(result.Tasks[0].IsFaulted);
                Assert.IsNull(result.Results[0]);
            }

      
            [TestMethod()]
            public void TestLoadSystemDll()
            {
                Func<double, TimeSpan> target = TimeSpan.FromSeconds;
                var callData = MpiRunner.GetRemoteCallData(target.Method, 60);
                MpiRunner.ExecuteRemoteCall<TimeSpan>(callData);    
            }


            [TestMethod()]
            public void ReadProcessResultErrorTest()
            {
                Func<int, string> target = TimeoutTest;

                var fn = Mpi.ParallelFor(1, target, 0);
                var runner = fn.Run().Kill();
                var pipeName = "ReadProcessResultError";

                Exception ex = null!;
                var pipeServer = new NamedPipeServerStream(pipeName, PipeDirection.InOut);

                var clientTask = Task.Run(() =>
                {
                    var client = new NamedPipeClientStream(".", pipeName);
                    client.Connect();

                    using (var bw = new BinaryWriter(client, Encoding.UTF8, true))
                    {
                        byte[] callDataBytes = Encoding.UTF8.GetBytes("{}");
                        bw.Write(callDataBytes.Length);
                        bw.Write(callDataBytes);
                        bw.Flush();
                    }
                });
                pipeServer.WaitForConnection();
                var errorEnabled = MpiRunner.Logger.ErrorEnabled;
                MpiRunner.Logger.ErrorEnabled = true;
                ex = Assert.ThrowsException<ArgumentException>(() =>
                   runner.ReadProcessResult(0, runner.procs[0], pipeName, pipeServer, fn.ArgProvider(0))
                   );
                MpiRunner.Logger.ErrorEnabled = errorEnabled;


                Assert.IsTrue(ex.Message.StartsWith("AssemblyName not set"));



            }
        }
    }
}