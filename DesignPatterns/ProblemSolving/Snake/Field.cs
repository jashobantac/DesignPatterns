namespace ProblemSolving.SnakeGame
{
    public class Field
    {
        #region Properties.

        public int Width { get; set; }
        public int Height { get; set; }

        public string[,] Points;

        #endregion

        #region Constructors.
        public Field(int x, int y)
        {
            Width = x;
            Height = y;
            Points = new string[x, y];
        }

        #endregion

        public void UpdateValue(int x, int y, string direction)
        {
            Points[x, y] = direction;
        }
    }
}
