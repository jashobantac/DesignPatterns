using AlgorithmsAndDataStructures.SearchAndSort;

namespace AlgorithmsAndDataStructures.Demo
{
    public class InsertionSortDemo : IDemo
    {
        public void Run()
        {
            int[] inputArray = new int[] { 2, 5, 3, 7, 4, 1, 6 };
            int[] sortedArray = SortingAlgorithms.InsertionSort(inputArray);
        }
    }
}
