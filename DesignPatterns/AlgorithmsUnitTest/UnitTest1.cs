using AlgorithmsAndDataStructures.LinkedLists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsUnitTest
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void CreateLinkedListTest()
        {
            int totalNodes = 5;
            LLNode nodes = LLGenerator.CreateLinkedList(totalNodes);
            Assert.IsTrue(nodes.Count() == totalNodes);
        }
    }
}
