using System;

namespace AlgorithmsAndDataStructures.LinkedLists
{
    public class LLGenerator
    {
        public static LLNode CreateLinkedList(int numberOfNodes)
        {
            if (numberOfNodes < 1)
            {
                throw new ArgumentException("Number of nodes must be greater than 0");
            }

            Random random = new Random();
            LLNode node = new LLNode
            {
                Data = random.Next(10, 100)
            };
            LLNode current = node;
            for (int i = 0; i < numberOfNodes - 1; i++)
            {
                LLNode newNode = new LLNode()
                {
                    Data = random.Next(10, 100)
                };
                current.Next = newNode;
                current = newNode;
            }
            return node;
        }
    }
}
