using AlgorithmsAndDataStructures.LinkedLists;

namespace AlgorithmsAndDataStructures.Demo
{
    public class DetectAndRemoveLinkedListLoopDemo : IDemo
    {
        public void Run()
        {
            LLNode head = new LLNode(1);
            LLNode rootTwo = new LLNode(2);
            LLNode rootThree = new LLNode(3);
            LLNode rootFour = new LLNode(4);
            LLNode rootFive = new LLNode(5);
            LLNode rootSix = new LLNode(6);
            LLNode rootSeven = new LLNode(7);
            LLNode rootEight = new LLNode(8);

            head.Next = rootTwo;
            rootTwo.Next = rootThree;
            rootThree.Next = rootFour;
            rootFour.Next = rootFive;
            rootFive.Next = rootSix;
            rootSix.Next = rootSeven;
            rootSeven.Next = rootEight;
            //rootEight.Next = rootTwo;

            //Strategy strategy = null;
            //strategy = new CheckOneByOneStrategy();
            ////strategy = new KCounterStrategy();
            //head.DetectAndRemoveNode(strategy);

            LLNode node = head.FindMiddle();
        }
    }
}
