using System;
using System.Collections.Generic;

namespace Behavioral.StrategyDesignPattern
{
    public class MergeSortStrategy : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            Console.WriteLine("Sorting using Merge Sort.");
        }
    }
}