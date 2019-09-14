using AlgorithmsAndDataStructures.Graphs;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsUnitTest
{
    [TestClass]
    public class GraphTest
    {
        [TestMethod]
        public void TestAdjacencyMatrixGraphRepresentation()
        {
            GraphAdjMatrix<string> graphAdjMatrix = new GraphAdjMatrix<string>(4);
            graphAdjMatrix.AddNode(0, 1, "A");
            graphAdjMatrix.AddNode(0, 2, "B");
            graphAdjMatrix.AddNode(1, 2, "C");
            graphAdjMatrix.AddNode(2, 0, "D");
            graphAdjMatrix.AddNode(2, 3, "E");
            graphAdjMatrix.AddNode(3, 3, "F");

            //string dfs = graphAdjMatrix.BFS(2).Trim();
        }

        [TestMethod]
        public void TestAdjacencyListGraphTraversal()
        {
            GraphAdjList g = new GraphAdjList(4);
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
