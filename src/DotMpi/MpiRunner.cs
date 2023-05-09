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

namespace DotMpi
{

    public partial class MpiRunner
    {
        private static string _id = "unknown";
        public static string id { get => $"[{_id}]"; set => _id = value; }
        internal static Logger Logger = Logger.Instance;

        public static RemoteCallData GetRemoteCallData(MethodInfo method, params object[] args)
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
            var result = (TResult)resultObject.ObjectValue;
            return result;
        }

        //Clients read json from IPC stream and pass it to this method to deserialize the method parameters, execute it, and return a result
        public static SerializableValue HandleRemoteCall(string json)
        {
            if (json is null)
            {
                throw new ArgumentNullException(nameof(json));
            }

            var callData = JsonConvert.DeserializeObject<RemoteCallData>(json);

            if (callData is null)
            {
                throw new ArgumentException($"Failed to deserialize Remote call data from json: {json}");
            }
            var objectResult = Execute(callData);
            SerializableValue result = new SerializableValue(objectResult);
            if (objectResult is null)
            {
                result.TypeName = callData.ReturnInfo.TypeName;
                result.AssemblyName = callData.ReturnInfo.AssemblyName;
            }
            return result;

        }

        private static ConcurrentDictionary<string, Assembly> assemblyRefs = new();

        internal static object? Execute(RemoteCallData callData)
        {
            var assemblyName = callData.MethodInfo.AssemblyName.Split(",")[0];
            Assembly asm = assemblyRefs.GetOrAdd(assemblyName, x =>
            {
                if (File.Exists($"{assemblyName}.dll"))
                {
                    var fullPath = Path.GetFullPath($"{assemblyName}.dll");
                    return Assembly.LoadFile(fullPath);
                }
                else
                {
                    return Assembly.Load(callData.MethodInfo.AssemblyName);
                }
            });


            var m = asm.ManifestModule.ResolveMethod(callData.MethodInfo.MetaDataToken);
            var args = callData.ArgInfo.Select(x => x.ObjectValue).ToArray();

            var methodResult = m.Invoke(null, args);

            if (Logger.InfoEnabled)
            {
                var resultJson = JsonConvert.SerializeObject(methodResult);
                Logger.Info($"[{DateTime.Now}] {id} {m.Name}({string.Join(",", args)}) returned {resultJson}");
            }
            return methodResult;
        }

        internal static void HandleRemoteCall(BinaryWriter writer, BinaryReader reader, string pipe, int threadIndex)
        {
            var length = reader.ReadInt32();
            var bytes = reader.ReadBytes(length);
            var json = Encoding.UTF8.GetString(bytes);

            if (Logger.InfoEnabled)
            {
                var callData = JsonConvert.DeserializeObject<RemoteCallData>(json);

                if (callData is null)
                {
                    throw new ArgumentException($"Failed to deserialize call data: {json}");
                }
                var debugJson = callData.DebugJson();
                Logger.Info($"[{DateTime.Now}] {id} [{pipe}] [Thread {threadIndex}] call data: {debugJson}");
            }



            SerializableValue objectResult = HandleRemoteCall(json);
            var resultData = objectResult.ToByteArray();

            writer.Write(resultData.Length);
            writer.Write(resultData);
        }



    }
}

