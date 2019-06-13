using System;

namespace AlgorithmsAndDataStructures.LinkedLists
{
    public class KCounterStrategy : Strategy
    {
        public override bool DetectAndRemoveLoop(LLNode node)
        {
            LLNode fastNode = node;
            LLNode slowNode = node;
            while (fastNode != null && slowNode != null && fastNode.Next != null)
            {
                fastNode = fastNode.Next.Next;
                slowNode = slowNode.Next;
                Console.WriteLine("Slow Node {0} | Fast Node {1} ", slowNode.Data, fastNode.Data);
                if (fastNode == slowNode)
                {
                    // Loop detected.
                    RemoveLoop(slowNode, node);
                    node.Print();
                    return true;
                }
            }
            Console.WriteLine("No Loop Present.");
            return false;
        }

        private void RemoveLoop(LLNode slowNode, LLNode node)
        {
            System.Console.WriteLine("Loop Detected. Removing Loop.");

            LLNode ptr1 = slowNode;
            LLNode ptr2 = slowNode;

            // Count the number of items in the loop.
            int k = 1;
            while (ptr1.Next != ptr2)
            {
                k++;
                ptr1 = ptr1.Next;
            }
            Console.WriteLine("Total Members in the Loop : {0}", k);

            // Fix one item to the head.
            ptr1 = node;
            ptr2 = node;
            for (int i = 0; i < k; i++)
            {
                ptr2 = ptr2.Next;
            }

            // Loop till both meet.
            while (ptr1 != ptr2)
            {
                ptr1 = ptr1.Next;
                ptr2 = ptr2.Next;
            }

            Console.WriteLine("Intersection at {0}", ptr1.Data);
            // Find the last node.
            while (ptr2.Next != ptr1)
            {
                ptr2 = ptr2.Next;
            }

            // Remove the link.
            Console.WriteLine("Removing Loop between {1} & {0}", ptr1.Data, ptr2.Data);
            ptr2.Next = null;
        }
    }
}
