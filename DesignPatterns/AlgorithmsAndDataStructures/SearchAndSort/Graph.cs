using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.SearchAndSort
{
    public class Graph
    {
        /// <summary>
        /// The number of vertices.
        /// </summary>
        public int V { get; set; }

        public List<int>[] Adj { get; private set; }

        public Graph(int v)
        {
            V = v;
            Adj = new List<int>[v];

            for (int i = 0; i < V; i++)
            {
                Adj[i] = new List<int>();
            }
        }

        public void AddEdge(int src, int dest)
        {
            Adj[src].Add(dest);
        }

        private void DepthFirstVisit(int v, bool[] visited, ref string str)
        {
            visited[v] = true;
            str += v + " ";
            for (int i = 0; i < Adj[v].Count; i++)
            {
                int current = Adj[v][i];
                if (!visited[current])
                {
                    DepthFirstVisit(current, visited, ref str);
                }
            }
        }

        public string DepthFirstTraversal(int v)
        {
            string str = string.Empty;
            bool[] visited = new bool[Adj.Length];

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

                for (int i = 0; i < Adj[current].Count; i++)
                {
                    int item = Adj[current][i];
                    if (!visited[item])
                    {
                        visited[item] = true;
                        queue.Enqueue(Adj[current][i]);
                    }
                }
            }
        }

        public string BreadthFirstTraversal(int v)
        {
            string str = string.Empty;
            bool[] visited = new bool[Adj.Length];

            BreadthFirstTraversal(v, visited, ref str);
            return str;

        }
    }
}
