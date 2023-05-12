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
using System.Reflection;
using System.Text;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Data;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.ComponentModel;
using static DotMpi.Mpi;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;

namespace DotMpi
{

    public partial class MpiRunner
    {
        private static string _id = "unknown";
        public static string id { get => $"[{_id}]"; set => _id = value; }
        internal static Logger Logger = Logger.Instance;

        public static RemoteCallData GetRemoteCallData(MethodInfo? method, params object[] args)
        {
            if (method is null)
            {
                throw new ArgumentNullException(nameof(method));
            }

            SerializableMethodInfo methodInfo = null!;
            if (method.IsStatic == false)
            {
                //var body = method.GetMethodBody();
                //if (body is null)
                //{
                //    throw new Exception("Could not read il body from method");
                //}
                //var ilBodyArray = body.GetILAsByteArray();
                //if (ilBodyArray is null)
                //{
                //    throw new ArgumentException("Could not read IL from method");
                //}
                //var ilBody = ilBodyArray.ToList();

                //var idx = ilBody.IndexOf(40);
                //var targetMetaDataTokenBytes = ilBody.Skip(idx + 1).Take(4).ToArray();
                //var metaDataToken = BitConverter.ToInt32(targetMetaDataTokenBytes);
                //var methodBase = method.DeclaringType.Assembly.ManifestModule.ResolveMethod(metaDataToken);


                //debug info: Instannce func's will call .ctor to the generated display classe.
                //var idx = ilBody.IndexOf(40);
                //var targetMetaDataTokenBytes = ilBody.Skip(idx+1).Take(4).ToArray();
                //var metaDataToken = BitConverter.ToInt32(targetMetaDataTokenBytes);
                //var methodBase = method.DeclaringType.Assembly.ManifestModule.ResolveMethod(metaDataToken);

                throw new ArgumentException("Can only execute static methods remotely");

            }

            var argInfo = GetArgInfos(args);
            var returnInfo = new SerializableTypeInfo(method.ReturnType);
            methodInfo ??= new SerializableMethodInfo(method);
            var remoteCallData = new RemoteCallData(methodInfo, returnInfo, argInfo);
            return remoteCallData;
        }



        //TODO: delete method, use strongly typed function call data class.

        internal static TResult Exec<TResult>(MethodInfo method, params object[] args)
        {
            var callData = GetRemoteCallData(method, args);
            var result = ExecuteRemoteCall<TResult>(callData);
            return result;
        }

        //TODO: delete method, use strongly typed function call data class.

        internal static TResult
            Exec<TResult>(Func<TResult> fn)
            => Exec<TResult>(fn.Method);


        internal static SerializableValue[] GetArgInfos(params object[] args)
        {
            if (args is null || args.Length == 0) return new SerializableValue[] { };
            for (var i = 0; i < args.Length; i++)
            {
                if (args[i] is null)
                {
                    throw new ArgumentNullException($"args{i}", "Type info cannot be determine. pass null arguments use the appropriate SerializableValue<T> constructor or GetArgInfo<T> to retain type info.");
                }
            }
            return args.Select(x => GetArgInfo(x)).ToArray();
        }


        internal static SerializableValue GetArgInfo<T>(T value)
        {
            var argInfo = new SerializableValue<T>(value);
            return argInfo;
        }




        internal static TResult ExecuteRemoteCall<TResult>(RemoteCallData callData)
        {
            var json = JsonConvert.SerializeObject(callData);
            var result = ExecuteRemoteCall<TResult>(json);
            return result;
        }

        internal static TResult ExecuteRemoteCall<TResult>(string json)
        {

            var resultObject = HandleRemoteCall(json);
            if (resultObject.HasError && resultObject.ErrorData is not null)
            {
                Exception ex = resultObject.ErrorData.ToException();
                throw ex;
            }
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            var result = (TResult)resultObject.ObjectValue;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8603 // Possible null reference return.
            return result;
#pragma warning restore CS8603 // Possible null reference return.
        }

        //Clients read json from IPC stream and pass it to this method to deserialize the method parameters, execute it, and return a result
        public static SerializableValue HandleRemoteCall(string json)
        {
            if (json is null)
            {
                throw new ArgumentNullException(nameof(json));
            }
            if (Logger.InfoEnabled)
            {
                Logger.Info($"{id} Deserializing Json.");
            }

            var callData = JsonConvert.DeserializeObject<RemoteCallData>(json);

            if (callData is null)
            {
                throw new ArgumentException($"Failed to deserialize Remote call data from json: {json}");
            }

            if (Logger.InfoEnabled)
            {
                Logger.Info($"{id} Calling Execute(method, {string.Join(", ", callData.ArgInfo.Select(x => x.ObjectValue))}).");
            }

            Exception? caught = null;

            object? objectResult = null;
            try
            {
                objectResult = Execute(callData);
            }
            catch (Exception ex)
            {
                caught = ex;
            }


            SerializableValue result = new SerializableValue(objectResult);
            if (objectResult is null)
            {
                result.TypeName = callData.ReturnInfo.TypeName;
                result.AssemblyName = callData.ReturnInfo.AssemblyName;
            }
            if (caught != null)
            {
                var errorData = ErrorData.Create(caught);
                result.ErrorData = errorData;
            }
            return result;

        }

        private static ConcurrentDictionary<string, Assembly> assemblyRefs = new();

        internal static object? Execute(RemoteCallData callData)
        {
            var assemblyName = callData.MethodInfo.AssemblyName.Split(",")[0];
            Assembly asm = null!;
            try
            {
                asm = assemblyRefs.GetOrAdd(assemblyName, x =>
                {
                    if (File.Exists($"{assemblyName}.dll"))
                    {
                        var fullPath = Path.GetFullPath($"{assemblyName}.dll");
                        return Assembly.UnsafeLoadFrom(fullPath);
                    }
                    else
                    {
                        return Assembly.Load(callData.MethodInfo.AssemblyName);
                    }
                });
            }
            catch (Exception ex)
            {
                if (Logger.ErrorEnabled)
                {
                    Logger.Error($"{id} Failed To Load Assembly '{assemblyName}' to execute method", ex);
                    throw;
                }
            }

            var m = asm.ManifestModule.ResolveMethod(callData.MethodInfo.MetaDataToken);
            if (m == null)
            {
                throw new MissingMethodException($"Failed to resolve method token: {callData.MethodInfo.MetaDataToken}");
            }
            var args = callData.ArgInfo.Select(x => x.ObjectValue).ToArray();

            var sw = Stopwatch.StartNew();
            object? methodResult = null!;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            try
            {
                methodResult = m.Invoke(null, args);
            }
            catch (Exception ex)
            {
                if (Logger.ErrorEnabled)
                {
                    try
                    {
                        Logger.Error($"{id} Error executing method '{m.Name}({string.Join(", ", args)})'", ex);
                    }
                    catch (Exception logException)
                    {
                        Logger.Error($"{id} Error logging error when executing method {logException.Message} - Original error: '{m.Name}({string.Join(", ", args)})' - {ex.Message}");
                    }
                    throw;
                }
            }
            sw.Stop();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            if (Logger.InfoEnabled)
            {
                var resultJson = JsonConvert.SerializeObject(methodResult);
                Logger.Info($"{id} {m.Name}({string.Join(",", args)}) took {sw.Elapsed} and returned {resultJson}");
            }
            return methodResult;
        }

        internal static void HandleRemoteCall(BinaryWriter writer, BinaryReader reader, string pipe, int threadIndex)
        {
            var sw = Stopwatch.StartNew();
            var length = reader.ReadInt32();
            var bytes = reader.ReadBytes(length);
            var json = Encoding.UTF8.GetString(bytes);
            sw.Stop();

            SerializableValue objectResult = null!;
            if (Logger.InfoEnabled)
            {
                Logger.Info($"{id} [{pipe}] [Thread {threadIndex}] reading call data took {sw.Elapsed}");

                sw.Restart();
                var callData = JsonConvert.DeserializeObject<RemoteCallData>(json);

                if (callData is null)
                {
                    throw new ArgumentException($"Failed to deserialize call data: {json}");
                }
                var debugJson = callData.DebugJson();
                sw.Stop();

                Logger.Info($"{id} [{pipe}] [Thread {threadIndex}] deserialized call data in {sw.Elapsed}: {debugJson}");      
            }

            sw.Restart();
            objectResult = HandleRemoteCall(json);
            sw.Stop();

            if (Logger.InfoEnabled)
            {
                Logger.Info($"{id} [{pipe}] [Thread {threadIndex}] HandleRemoteCall took {sw.Elapsed}");
            }


            sw.Restart();
            var resultData = objectResult.ToByteArray();
            writer.Write(resultData.Length);
            writer.Write(resultData);
            sw.Stop();

            if (Logger.InfoEnabled)
            {
                Logger.Info($"{id} [{pipe}] [Thread {threadIndex}] Send call results took {sw.Elapsed}");
            }

        }



    }
}

