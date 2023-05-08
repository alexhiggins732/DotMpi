/*
 Copyright (c) 2023 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 
 
 Source code for this software can be found at https://github.com/alexhiggins732/DotMpi
 
 This software is licensce under GNU General Public License version 3 as described in the LICENSE
 file at https://github.com/alexhiggins732/DotMpi/LICENSE
 
 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DotMpi
{
    public class Logger
    {
        static bool staticDebugEnabled;
        static bool staticVerboseEnabled = false;
        static bool staticErrorEnabled = true;
        static bool staticInfoEnabled = false;

        public static bool StaticDebugEnabled { get => staticDebugEnabled; set => Instance.DebugEnabled = staticDebugEnabled = value; }
        public static bool StaticVerboseEnabled { get => staticVerboseEnabled; set => Instance.verboseEnabled = staticVerboseEnabled = value; }
        public static bool StaticErrorEnabled { get => staticErrorEnabled; set => Instance.ErrorEnabled = staticErrorEnabled = value; }
        public static bool StaticInfoEnabled { get => staticInfoEnabled; set => Instance.InfoEnabled = staticInfoEnabled = value; }

        private bool debugEnabled;
        private bool verboseEnabled;
        private bool errorEnabled;
        private bool infoEnabled;

        public bool DebugEnabled { get => debugEnabled; set => debugEnabled = value; }
        public bool VerboseEnabled { get => verboseEnabled; set => verboseEnabled = value; }
        public bool ErrorEnabled { get => errorEnabled; set => errorEnabled = value; }
        public bool InfoEnabled { get => infoEnabled; set => infoEnabled = value; }

        public static Logger Instance { get; private set; }
        public TextWriter OutputStream { get; set; }

        static Logger()
        {
            Instance = new Logger(StaticDebugEnabled, StaticVerboseEnabled, StaticErrorEnabled, StaticInfoEnabled);
            Instance.OutputStream = Console.Out;
        }

        public Logger(bool debugEnabled, bool verboseEnabled, bool errorEnabled, bool infoEnabled, TextWriter? output = null)
        {
            OutputStream = output ?? Console.Out;

            this.debugEnabled = debugEnabled;
            this.verboseEnabled = verboseEnabled;
            this.errorEnabled = errorEnabled;
            this.infoEnabled = infoEnabled;

        }

        public void Debug(string message)
        {
            if (!debugEnabled) return;
            OutputStream.WriteLine($"[{nameof(Debug)}] {message}");
        }
        public void Verbose(string message)
        {
            if (!verboseEnabled) return;
            OutputStream.WriteLine($"[{nameof(Verbose)}] {message}");
        }

        public void Error(string message, Exception ex)
        {
            if (!errorEnabled) return;
            message += Environment.NewLine + ex.ToString();
            OutputStream.WriteLine($"[{nameof(Error)}] {message}");
        }
        public void Error(string message)
        {
            if (!errorEnabled) return;
            var stackTrace = new StackTrace(true);
            message += Environment.NewLine + stackTrace.ToString();
            OutputStream.WriteLine($"[{nameof(Error)}] {message}");
        }

        public void Info(string message)
        {
            if (!infoEnabled) return;
            OutputStream.WriteLine($"[{nameof(Info)}] {message}");
        }
    }
}
