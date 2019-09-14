namespace AlgorithmsAndDataStructures.Graphs
{
    public struct Position
    {
        public int X;
        public int Y;
    }
    public class GraphNode<T>
    {
        private static int _id = 0;
        public int Id { get; private set; }
        public T Value { get; set; }
        public Position Position { get; set; }
        public GraphNode()
        {
            _id++;
            Id = _id;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
