using System;

namespace Multithreading.Extensions
{
    public static class ColorConsole
    {
        public static void WriteInfo(object obj)
        {
            if (obj == null)
            {
                return;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("INFO : ");
            Console.ResetColor();
            Console.WriteLine(obj.ToString());
        }

        public static void WriteWarning(object obj)
        {
            if (obj == null)
            {
                return;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("WARN : ");
            Console.ResetColor();
            Console.WriteLine(obj.ToString());
        }

        public static void WriteError(object obj)
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

        public static void WriteException(object obj, string prefix = "EXCEPTION")
        {
            if (obj == null)
            {
                return;
            }
            if (string.IsNullOrEmpty(prefix))
            {
                prefix = "EXCEPTION";
            }
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(prefix + " : ");
            Console.ResetColor();
            Console.WriteLine(obj.ToString());
        }
    }
}
