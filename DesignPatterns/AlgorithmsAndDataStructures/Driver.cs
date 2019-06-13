using System;
using AlgorithmsAndDataStructures.Demo;

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

            _demo.Run();
            Console.ReadLine();
        }
    }
}
