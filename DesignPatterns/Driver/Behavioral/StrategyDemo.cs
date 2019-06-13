using Behavioral.StrategyDesignPattern;

namespace Driver.Behavioral
{
    public class StrategyDemo : IDemo
    {
        public void Run()
        {
            SortedList list = new SortedList();
            list.AddItem("Jashobanta");
            list.AddItem("Test");

            list.Sort(new QuickSortStrategy());
            list.Sort(new MergeSortStrategy());
        }
    }
}
