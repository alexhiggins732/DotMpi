using System.Diagnostics;

namespace DotMpi
{
    public class Logger
    {
        public static bool DebugEnabled = false;
        public static bool VerboseEnabled = false;
        public static bool ErrorEnabled = true;
        public static bool InfoEnabled = false;

        public static void Debug(string message)
        {
            if (!DebugEnabled) return;
            Console.WriteLine($"[{nameof(Debug)}] {message}");
        }
        public static void Verbose(string message)
        {
            if (!VerboseEnabled) return;
            Console.WriteLine($"[{nameof(Verbose)}] {message}");
        }

        public static void Error(string message, Exception ex)
        {
            if (!ErrorEnabled) return;
            message += Environment.NewLine + ex.ToString();
            Console.WriteLine($"[{nameof(Error)}] {message}");
        }
        public static void Error(string message)
        {
            if (!ErrorEnabled) return;
            var stackTrace = new StackTrace(true);
            message += Environment.NewLine + stackTrace.ToString();
            Console.WriteLine($"[{nameof(Error)}] {message}");
        }

        public static void Info(string message)
        {
            if (!InfoEnabled) return;
            Console.WriteLine($"[{nameof(Info)}] {message}");
        }
    }
}
