using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpAndWPF.AsyncDelegates;

namespace CSharpAndWPF
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //MulticastDelegateProgram pgm = new MulticastDelegateProgram();
            //pgm.Execute();

            using (TimeLogger timeLogger = new TimeLogger("Testing Thread Execution"))
            {
                Print();
            }
            Console.Read();
        }

        private static void Print()
        {
            //for (int i = 1; i <= 10; i++)
            //{
            //    Console.WriteLine(2 * i);
            //    Thread.Sleep(1000);
            //}

            Parallel.For(1, 10 + 1, new Action<int>((i) =>
            {
                Console.WriteLine(2 * i);
                Thread.Sleep(1000);
            }));
        }
    }
}
