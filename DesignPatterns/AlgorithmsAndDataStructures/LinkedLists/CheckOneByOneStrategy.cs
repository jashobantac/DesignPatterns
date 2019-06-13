namespace AlgorithmsAndDataStructures.LinkedLists
{
    public class CheckOneByOneStrategy : Strategy
    {
        public override bool DetectAndRemoveLoop(LLNode node)
        {
            LLNode slowNode = node;
            LLNode fastNode = node;

            while (slowNode != null && fastNode != null && fastNode.Next != null)
            {
                slowNode = slowNode.Next;
                fastNode = fastNode.Next.Next;
                System.Console.WriteLine("Slow Node {0} | Fast Node {1} ", slowNode.Data, fastNode.Data);
                if (slowNode == fastNode)
                {
                    // loop detected.
                    RemoveLoop(slowNode, node);
                    node.Print();
                    return true;
                }
            }
            return false;
        }

        private void RemoveLoop(LLNode slowNode, LLNode node)
        {
            System.Console.WriteLine("Loop Detected. Removing Loop.");

            LLNode ptr1 = node;
            LLNode ptr2 = null;

            while (true)
            {
                ptr2 = slowNode;
                System.Console.WriteLine("Ptr 1 : {0} ", ptr1.Data);
                System.Console.WriteLine("Ptr 2 : {0} ", ptr2.Data);

                while (ptr2.Next != slowNode && ptr2.Next != ptr1)
                {
                    ptr2 = ptr2.Next;
                    System.Console.WriteLine("Ptr 2 Updated : {0} ", ptr2.Data);
                }

                if (ptr2.Next == ptr1)
                {
                    System.Console.WriteLine("Ptr2 == Ptr1. Break.");
                    break;
                }
                ptr1 = ptr1.Next;
            }
            System.Console.WriteLine("Removing Loop from Ptr2 : {0}", ptr2.Data);
            ptr2.Next = null;
        }
    }
}
