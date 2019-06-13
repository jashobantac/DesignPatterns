using System;
using AlgorithmsAndDataStructures.LinkedLists;

namespace AlgorithmsAndDataStructures
{
    public class Driver
    {
        public static void Main(string[] args)
        {
            int totalNodes = 5;
            LLNode nodes = LLGenerator.CreateLinkedList(totalNodes);
            nodes.Print();

            Console.WriteLine("\nREVERSING");
            LLNode reverseLinkedList = nodes.Reverse();
            reverseLinkedList.Print();

            Console.ReadLine();
        }
    }
}
