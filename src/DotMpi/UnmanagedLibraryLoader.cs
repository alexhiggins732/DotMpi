/*
 Copyright (c) 2023 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 
 
 Source code for this software can be found at https://github.com/alexhiggins732/DotMpi
 
 This software is licensce under GNU General Public License version 3 as described in the LICENSE
 file at https://github.com/alexhiggins732/DotMpi/LICENSE
 
 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System.Reflection;
using System.Runtime.InteropServices;

namespace DotMpi
{

    public partial class MpiRunner
    {
        /// <summary>
        /// Loads an unmanaged library unmanaged library (i.e., a native DLL or shared library) at runtime dynamically at runtime that are located in the DotNet ./runtimes directory, based on the current operating system
        /// and processor architecture. It handles the AssemblyLoadContext.Default.ResolvingUnmanagedDll event to handle resolving unmanaged DLLs not directly in the application folder
        /// which is the case with nuget packages that are compiled for multiple platforms and architectures.
        /// </summary>
  
        private class UnmanagedLibraryLoader : IDisposable
        {
            public readonly IntPtr OsHandle;
            private bool _disposed;


            /// <summary>
            /// Initializes a new instance of the <see cref="UnmanagedLibraryLoader"/> class,
            /// and loads an unmanaged library with the specified name into the current process.
            /// </summary>
            /// <param name="loadingAssembly">The assembly that is loading the unmanaged library.</param>
            /// <param name="libraryName">The name of the unmanaged library to load.</param>

            public UnmanagedLibraryLoader(Assembly loadingAssembly, string libraryName)
            {
                OsHandle = LoadUnmanagedDll(loadingAssembly, libraryName);
            }
 

            /// <summary>
            /// Releases all resources used by the current instance of the <see cref="UnmanagedLibraryLoader"/> class.
            /// </summary>
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            /// <summary>
            /// Finalizes an instance of the <see cref="UnmanagedLibraryLoader"/> class.
            /// </summary>
            ~UnmanagedLibraryLoader()
            {
                Dispose(false);
            }

            /// <summary>
            /// Frees the unmanaged library handle if it has not already been disposed.
            /// </summary>
            /// <param name="disposing">True if called from Dispose(), false if called from the finalizer.</param>
            protected virtual void Dispose(bool disposing)
            {
                if (!_disposed)
                {
                    _disposed = true;
                    NativeLibrary.Free(OsHandle);
                }
            }

            /// <summary>
            /// Loads an unmanaged DLL into the current process.
            /// </summary>
            /// <param name="loadingAssembly">The assembly that is loading the unmanaged library.</param>
            /// <param name="libraryName">The name of the unmanaged library to load.</param>
            /// <returns>A handle to the loaded library.</returns>

            private IntPtr LoadUnmanagedDll(Assembly loadingAssembly, string libraryName)
            {
                var proc = RuntimeInformation.ProcessArchitecture;
                var os = RuntimeInformation.OSArchitecture;
                var rtId = RuntimeInformation.RuntimeIdentifier;
                var plat = RuntimeInformation.OSDescription;
                var desc = RuntimeInformation.FrameworkDescription;
                if (Logger.VerboseEnabled)
                    Logger.Verbose($"Called Resolving unmanaged {loadingAssembly.FullName}, {libraryName} for {os} {proc} {rtId} {plat} {desc}");

                if (!Directory.Exists("./runtimes"))
                {
                    return IntPtr.Zero;
                }


                var osPlatform = "win";
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    osPlatform = "linux";
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    osPlatform = "osx";
                }
                string architecture = $"{osPlatform}-{proc}".ToLower();

                if (Logger.VerboseEnabled)
                    Logger.Verbose($"{id} Searching for {libraryName} in ./runtimes/{architecture}");

                // search in the /runtimes/[architecture] and then the /runtimes/[architecture]/native directories.
                string libraryPath = System.IO.Path.Combine(AppContext.BaseDirectory, "runtimes", architecture, libraryName);

                if (!System.IO.File.Exists(libraryPath))
                {
                    if (Logger.VerboseEnabled)
                        Logger.Verbose($"{id} Library {libraryName} was not found in {libraryPath}");

                    libraryPath = System.IO.Path.Combine(AppContext.BaseDirectory, "runtimes", architecture, "native", libraryName);

                    if (!System.IO.File.Exists(libraryPath))
                    {
                        if (Logger.VerboseEnabled)
                            Logger.Verbose($"{id} Library {libraryName} was not found in {libraryPath}");
                        return IntPtr.Zero;
                    }
                }
                if (Logger.VerboseEnabled)
                    Logger.Verbose($"{id} Found unmanaged library {libraryPath}");

                var result = NativeLibrary.Load(libraryPath);

                return result;
            }
        }
    }
}

