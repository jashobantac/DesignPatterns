using System;

using AlgorithmsAndDataStructures.Demo;
using AlgorithmsAndDataStructures.Misc;

namespace AlgorithmsAndDataStructures
{
    public class Driver
    {
        private static IDemo _demo;
        public static void Main(string[] args)
        {
            //int totalNodes = 5;
            //LLNode nodes = LLGenerator.CreateLinkedList(totalNodes);
            //nodes.Print();

            //Console.WriteLine("\nREVERSING");
            //LLNode reverseLinkedList = nodes.Reverse();
            //reverseLinkedList.Print();

            _demo = new DetectAndRemoveLinkedListLoopDemo();

            string fibonacci = IntProgramming.GetFibonacciSeries(20);

            bool isPrime = IntProgramming.IsPrime(13);

            _demo = new InsertionSortDemo();

            _demo.Run();
            Console.ReadLine();
        }
    }
}
