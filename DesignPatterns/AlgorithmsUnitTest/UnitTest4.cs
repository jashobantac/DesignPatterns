using AlgorithmsAndDataStructures.SearchAndSort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsUnitTest
{
    [TestClass]
    public class GraphTest
    {
        [TestMethod]
        public void TestTraversal()
        {
            Graph g = new Graph(4);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            string dfs = g.DepthFirstTraversal(2).Trim();
            Assert.IsTrue(string.Equals(dfs, "2 0 1 3", System.StringComparison.OrdinalIgnoreCase));

            string bfs = g.BreadthFirstTraversal(2).Trim();
            Assert.IsTrue(string.Equals(bfs, "2 0 3 1", System.StringComparison.OrdinalIgnoreCase));

        }
    }
}
