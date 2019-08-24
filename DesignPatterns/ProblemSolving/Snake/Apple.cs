namespace ProblemSolving.SnakeGame
{
    public class Apple : Fruit
    {
        public Apple(string name, int point) : base(name, point)
        {
        }
    }

    public class PoisonFruit : Fruit
    {
        public PoisonFruit(string name, int point) : base(name, point)
        {
        }
    }
}
