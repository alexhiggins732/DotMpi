﻿/*
 Copyright (c) 2023 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 
 
 Source code for this software can be found at https://github.com/alexhiggins732/DotMpi
 
 This software is licensce under GNU General Public License version 3 as described in the LICENSE
 file at https://github.com/alexhiggins732/DotMpi/LICENSE
 
 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System.Text;
using System.IO.Pipes;

namespace DotMpi
{
    public partial class Mpi
    {
        public class FunctionExecutor
        {
            internal static void RunThread(int threadIndex, string pipeName)
            {

                if (Logger.InfoEnabled)
                    Logger.Info($"{id} Executing {nameof(RunThread)}: {string.Join(",", new object[] { threadIndex, pipeName })}");
                try
                {
                    using NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", pipeName);

                    if (Logger.DebugEnabled)
                        Logger.Debug($"{id} Executing {nameof(RunThread)}:{nameof(pipeClient)}.{nameof(pipeClient.Connect)}({pipeName})");
                    
                    pipeClient.Connect();

                    if (Logger.DebugEnabled)
                        Logger.Debug($"{id} Executed {nameof(RunThread)}:{nameof(pipeClient)}.{nameof(pipeClient.Connect)}({pipeName})");

                    using var reader = new BinaryReader(pipeClient);
                    using (var writer = new BinaryWriter(pipeClient))
                        try
                        {
                            if (Logger.DebugEnabled)
                                Logger.Debug($"{id} Calling {nameof(MpiRunner.HandleRemoteCall)}:{nameof(pipeClient)}.{nameof(pipeClient.Connect)}({pipeName})");
                            
                            MpiRunner.HandleRemoteCall(writer, reader, pipeName, threadIndex);

                            if (Logger.DebugEnabled)
                                Logger.Debug($"{id} Executed {nameof(MpiRunner.HandleRemoteCall)}:{nameof(pipeClient)}.{nameof(pipeClient.Connect)}({pipeName})");
                        }

                        catch (Exception ex)
                        {
                            var errorMessage = $"[{pipeName}] Error running thread {threadIndex}: {ex}";
                            if (Logger.ErrorEnabled)
                                Logger.Error(errorMessage);

                            if (pipeClient.IsConnected)
                            {
                                var serializeableResult = new SerializableValue(errorMessage);
                                var resultJson = serializeableResult.ToJson();
                                var resultData = Encoding.UTF8.GetBytes(resultJson);
                                writer.Write(resultData.Length);
                                writer.Write(resultData);
                            }
                        }
                }
                catch (Exception ex)
                {
                    var errorMessage = $"[{pipeName}] Error running thread {threadIndex}: {ex}";
                    if (Logger.ErrorEnabled)
                        Logger.Error(errorMessage);

                }
                if (Logger.InfoEnabled)
                    Logger.Info($"{id} Completed {nameof(RunThread)}: {string.Join(",", new object[] { threadIndex, pipeName })}");

            }
        }
    }
}

