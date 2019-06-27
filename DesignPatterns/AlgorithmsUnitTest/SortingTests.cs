using AlgorithmsAndDataStructures.SearchAndSort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsUnitTest
{
    [TestClass]
    public class SortingTests
    {
        [TestMethod]
        public void TestInsertionSort()
        {
            int[] input = new int[] { 1, 5, 6, 2, 3, 4 };
            int[] output = SortingAlgorithms.InsertionSort(input);
            for (int i = 0; i < output.Length; i++)
            {
                Assert.IsTrue(output[i] == i + 1);
            }
        }
    }
}
