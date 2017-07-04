using System;
using System.IO;

namespace Bat.Vm.Log {
    public static class Logger {
        public const Color DEFAULT_LOGLEVEL_COLOR = Color.White;
        public const Color INFO_LOGLEVEL_COLOR = Color.DarkBlue;
        public const Color DEBUG_LOGLEVEL_COLOR = Color.Green;
        public const Color WARNING_LOGLEVEL_COLOR = Color.Red;
        public const Color ERROR_LOGLEVEL_COLOR = Color.DarkMagenta;

        private static string LogTemplate = "{0}: ";

        public static void Write(string text, bool colored = false, bool writeLogLevel = true) {
            Write(text, LogLevel.DEFAULT, colored, writeLogLevel);
        }

        public static void Write(string text, LogLevel logLevel, bool colored = false, bool writeLogLevel = true) {
            Write(text, logLevel, Console.Out, colored, writeLogLevel);
        }

        public static void Write(string text, LogLevel logLevel, TextWriter logStream, bool colored = false, bool writeLogLevel = true) {
            if (writeLogLevel) {
                WriteLogText(logLevel, logStream, colored);
            }
            logStream.Write(text);
        }

        public static void WriteLine(string text, bool colored = false, bool writeLogLevel = true) {
            WriteLine(text, LogLevel.DEFAULT, colored, writeLogLevel);
        }

        public static void WriteLine(string text, LogLevel logLevel, bool colored = false, bool writeLogLevel = true) {
            WriteLine(text, logLevel, Console.Out, colored, writeLogLevel);
        }

        public static void WriteLine(string text, LogLevel logLevel, TextWriter logStream, bool colored = false, bool writeLogLevel = true) {
            Write(text + "\n", logLevel, logStream, colored, writeLogLevel);
        }

        private static void WriteLogText(LogLevel logLevel, TextWriter logStream, bool colored) {
            string logText = string.Format(LogTemplate, GetTextFromLogLevel(logLevel));

            if (colored && logStream == Console.Out) {
                Color color = GetColorFromLogLevel(logLevel);
                ChangeConsoleColor(ColorToConsoleColor(color));
            }

            logStream.Write(logText);

            if (colored && logStream == Console.Out) {
                ResetConsoleColor();
            }
        }

        private static void ChangeConsoleColor(ConsoleColor color) {
            Console.ForegroundColor = color;
        }

        private static void ResetConsoleColor() {
            Console.ForegroundColor = ConsoleColor.White;
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
                case LogLevel.DEFAULT:
                default:
                    return "[DEFAULT]";
            }
        }

        private static Color GetColorFromLogLevel(LogLevel logLevel) {
            switch (logLevel) {
                case LogLevel.DEFAULT:
                    return DEFAULT_LOGLEVEL_COLOR;
                case LogLevel.INFO:
                    return INFO_LOGLEVEL_COLOR;
                case LogLevel.DEBUG:
                    return DEBUG_LOGLEVEL_COLOR;
                case LogLevel.WARNING:
                    return WARNING_LOGLEVEL_COLOR;
                case LogLevel.ERROR:
                    return ERROR_LOGLEVEL_COLOR;
                default:
                    return DEFAULT_LOGLEVEL_COLOR;
            }
        }

        private static ConsoleColor ColorToConsoleColor(Color color) {
            switch (color) {
                case Color.Black:
                    return ConsoleColor.Black;
                case Color.White:
                    return ConsoleColor.White;
                case Color.Blue:
                    return ConsoleColor.Blue;
                case Color.Cyan:
                    return ConsoleColor.Cyan;
                case Color.Gray:
                    return ConsoleColor.Gray;
                case Color.Green:
                    return ConsoleColor.Green;
                case Color.Magenta:
                    return ConsoleColor.Magenta;
                case Color.Red:
                    return ConsoleColor.Red;
                case Color.Yellow:
                    return ConsoleColor.Yellow;
                case Color.DarkBlue:
                    return ConsoleColor.DarkBlue;
                case Color.DarkCyan:
                    return ConsoleColor.DarkCyan;
                case Color.DarkGray:
                    return ConsoleColor.DarkGray;
                case Color.DarkGreen:
                    return ConsoleColor.DarkGreen;
                case Color.DarkMagenta:
                    return ConsoleColor.DarkMagenta;
                case Color.DarkRed:
                    return ConsoleColor.DarkRed;
                case Color.DarkYellow:
                    return ConsoleColor.DarkYellow;
                default:
                    return ConsoleColor.White;
            }
        }
    }
}
