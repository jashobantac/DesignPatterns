using System;

namespace AlgorithmsAndDataStructures.LinkedLists
{
    public static class LLExtensions
    {
        public static void Print(this LLNode node)
        {
            if (node == null)
            {
                throw new NullReferenceException("Node cannot be null");
            }
            Console.Write("START ->");
            LLNode currentNode = node;
            do
            {
                Console.Write(string.Format("{0} ->", currentNode.Data));
                currentNode = currentNode.Next;
            } while (currentNode.Next != null);
            Console.Write(string.Format("{0} ->END", currentNode.Data));
        }

        public static int Count(this LLNode node)
        {
            if (node == null)
            {
                throw new NullReferenceException("Node cannot be null");
            }
            int count = 1;
            LLNode currentNode = node;
            while (currentNode.Next != null)
            {
                count++;
                currentNode = currentNode.Next;
            }
            return count;
        }

        public static LLNode Reverse(this LLNode node)
        {
            if (node == null)
            {
                return null;
            }
            LLNode prev = null;
            LLNode current = node;
            LLNode next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            return prev;
        }

        public static LLNode ReverseRecursive(this LLNode node)
        {
            return null;
        }
    }
}
