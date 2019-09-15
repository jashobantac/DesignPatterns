using System;

namespace Multithreading.Extensions
{
    public static class ColorConsole
    {
        private static readonly object _locker = new object();

        public static void WriteInfo(object obj, string prefix = "INFO")
        {
            lock (_locker)
            {
                if (obj == null)
                {
                    return;
                }
                if (prefix == null)
                {
                    prefix = "INFO";
                }
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                if (!prefix.Trim().EndsWith(":"))
                {
                    Console.Write(prefix + " : ");
                }
                Console.ResetColor();
                Console.WriteLine(obj.ToString());
            }
        }

        public static void WriteWarning(object obj, string prefix = "WARN")
        {
            lock (_locker)
            {
                if (obj == null)
                {
                    return;
                }
                if (prefix == null)
                {
                    prefix = "WARN";
                }
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                if (!prefix.Trim().EndsWith(":"))
                {
                    Console.Write(prefix + " : ");
                }
                Console.ResetColor();
                Console.WriteLine(obj.ToString());
            }
        }

        public static void WriteError(object obj)
        {
            lock (_locker)
            {
                if (obj == null)
                {
                    return;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("ERROR : ");
                Console.ResetColor();
                Console.WriteLine(obj.ToString());
            }
        }

        public static void WriteException(object obj, string prefix = "EXCEPTION")
        {
            lock (_locker)
            {
                if (obj == null)
                {
                    return;
                }
                if (prefix == null)
                {
                    prefix = "EXCEPTION";
                }
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                if (!prefix.Trim().EndsWith(":"))
                {
                    Console.Write(prefix + " : ");
                }
                Console.ResetColor();
                Console.WriteLine(obj.ToString());
            }
        }
    }
}
