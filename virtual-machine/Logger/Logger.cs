using System;
using System.IO;

namespace Bat.Vm.Log {
    public static class Logger {
        private static string LogTemplate = "{0}  \t: {1}";

        public static void Write(string text) {
            Write(text, LogLevel.DEFAULT);
        }

        public static void Write(string text, LogLevel logLevel) {
            Write(text, logLevel, Console.Out);
        }

        public static void Write(string text, LogLevel logLevel, TextWriter logStream) {
            string logText = string.Format(LogTemplate, GetTextFromLogLevel(logLevel), text);
            logStream.Write(logText);
        }

        public static void WriteLine(string text) {
            WriteLine(text, LogLevel.DEFAULT);
        }

        public static void WriteLine(string text, LogLevel logLevel) {
            WriteLine(text, logLevel, Console.Out);
        }

        public static void WriteLine(string text, LogLevel logLevel, TextWriter logStream) {
            string logText = string.Format(LogTemplate, GetTextFromLogLevel(logLevel), text);
            logStream.WriteLine(logText);
        }

        private static string GetTextFromLogLevel(LogLevel logLevel) {
            switch (logLevel) {
                case LogLevel.INFO:
                    return "[INFO]";
                case LogLevel.DEBUG:
                    return "[DEBUG]";
                case LogLevel.WARNING:
                    return "[WARNING]";
                case LogLevel.ERROR:
                    return "[ERROR]";
                case LogLevel.FATAL:
                    return "[FATAL]";
                case LogLevel.DEFAULT:
                default:
                    return "[DEFAULT]";
            }
        }
    }
}
