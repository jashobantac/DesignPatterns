using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Graphs
{
    /// <summary>
    /// Adjacency List representation of Graph.
    /// </summary>
    public class GraphAdjList
    {
        /// <summary>
        /// The number of vertices.
        /// </summary>
        public int V { get; set; }

        public List<int>[] AdjacencyList { get; private set; }

        public GraphAdjList(int v)
        {
            V = v;
            AdjacencyList = new List<int>[v];

            for (int i = 0; i < V; i++)
            {
                AdjacencyList[i] = new List<int>();
            }
        }

        public void AddEdge(int src, int dest)
        {
            AdjacencyList[src].Add(dest);
        }

        private void DepthFirstVisit(int v, bool[] visited, ref string str)
        {
            visited[v] = true;
            str += v + " ";
            for (int i = 0; i < AdjacencyList[v].Count; i++)
            {
                int current = AdjacencyList[v][i];
                if (!visited[current])
                {
                    DepthFirstVisit(current, visited, ref str);
                }
            }
        }

        public string DepthFirstTraversal(int v)
        {
            string str = string.Empty;
            bool[] visited = new bool[AdjacencyList.Length];

            DepthFirstVisit(v, visited, ref str);
            return str;
        }


        private void BreadthFirstTraversal(int v, bool[] visited, ref string str)
        {
            visited[v] = true;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(v);

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                str += current + " ";

                for (int i = 0; i < AdjacencyList[current].Count; i++)
                {
                    int item = AdjacencyList[current][i];
                    if (!visited[item])
                    {
                        visited[item] = true;
                        queue.Enqueue(AdjacencyList[current][i]);
                    }
                }
            }
        }

        public string BreadthFirstTraversal(int v)
        {
            string str = string.Empty;
            bool[] visited = new bool[AdjacencyList.Length];

            BreadthFirstTraversal(v, visited, ref str);
            return str;
        }
    }
}
