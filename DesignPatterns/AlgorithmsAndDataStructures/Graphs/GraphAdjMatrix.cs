using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndDataStructures.Graphs
{
    public partial class GraphAdjMatrix<T>
    {
        public GraphNode<T>[,] Nodes { get; private set; }

        public GraphAdjMatrix(int totalNodes)
        {
            Nodes = new GraphNode<T>[totalNodes, totalNodes];
        }

        public bool AddNode(int start, int end, T value)
        {
            if (start > Nodes.GetLength(0) || end > Nodes.GetLength(0))
            {
                return false;
            }

            if (Nodes[start, end] == null)
            {
                GraphNode<T> node = new GraphNode<T>
                {
                    Value = value
                };
                Nodes[start, end] = node;
                node.Position = new Position()
                {
                    X = start,
                    Y = end
                };

                return true;
            }
            return false;
        }

        public string BFS(GraphNode<T> startNode)
        {
            List<T> nodeValues = new List<T>();
            bool[] visited = new bool[Nodes.Length];
            Queue<GraphNode<T>> queue = new Queue<GraphNode<T>>();
            queue.Enqueue(startNode);

            visited[startNode.Id] = true;
            nodeValues.Add(startNode.Value);

            while (queue.Count > 0)
            {
                GraphNode<T> nodeToProcess = queue.Dequeue();
                nodeValues.Add(nodeToProcess.Value);
                for (int i = 0; i < Nodes.Length; i++)
                {
                    GraphNode<T> adjacentNode = Nodes[nodeToProcess.Position.X, i];
                    if (adjacentNode != null && !visited[adjacentNode.Id])
                    {
                        visited[adjacentNode.Id] = true;
                        queue.Enqueue(adjacentNode);

                        nodeValues.Add(adjacentNode.Value);
                    }
                }
            }
            StringBuilder stringBuilder = new StringBuilder();
            foreach (T item in nodeValues)
            {
                stringBuilder.Append(item);
                stringBuilder.Append(" ");
            }
            System.Console.WriteLine(stringBuilder.ToString());
            return stringBuilder.ToString();
        }
    }
}
