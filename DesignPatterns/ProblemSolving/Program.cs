using System;

namespace ProblemSolving
{
    internal class Program
    {
        private static IDemo _demo;
        private static void Main(string[] args)
        {
            _demo = new MarsRoverDemo();
            //_demo = new IPodInventoryDemo();

            _demo.Run();
            Console.ReadLine();
        }
    }
}
