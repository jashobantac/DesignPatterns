using AlgorithmsAndDataStructures.Misc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsUnitTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestGetSubarrayIndex()
        {
            //int[] items = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //int sum = 15;

            int[] items = new int[] { 1, 2, 3, 1, 4 };
            int sum = 10;
            System.Collections.Generic.List<int> indexes = StringProgramming.GetSubarrayIndex(items, sum);
            Assert.IsTrue(indexes.Count == 2);
        }

        [TestMethod]
        public void TestEvenOddSwap()
        {
            int num = 23;
            long final = StringProgramming.SwapOddBits(num);
        }

        [TestMethod]
        public void TestMaximumIndexProblem()
        {
            MaxIndexStrategy strategy;
            strategy = new NormalStrategy();

            int[] items = new int[] { 34, 8, 10, 3, 2, 80, 30, 33, 1 };
            int final = StringProgramming.MaximumIndexProblem(items, strategy);
            Assert.IsTrue(final == 6);

            items = new int[] { 9, 2, 3, 4, 5, 6, 7, 8, 18, 0 };
            final = StringProgramming.MaximumIndexProblem(items, strategy);
            Assert.IsTrue(final == 8);

            items = new int[] { 1, 2, 3, 4, 5, 6 };
            final = StringProgramming.MaximumIndexProblem(items, strategy);
            Assert.IsTrue(final == 5);

            items = new int[] { 6, 5, 4, 3, 2, 1 };
            final = StringProgramming.MaximumIndexProblem(items, strategy);
            Assert.IsTrue(final == -1);
        }
    }
}
