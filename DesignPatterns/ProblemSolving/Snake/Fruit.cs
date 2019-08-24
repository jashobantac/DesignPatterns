using ProblemSolving.SnakeGame.Base;

namespace ProblemSolving.SnakeGame
{
    public abstract class Fruit : ModelBase
    {
        private int _point;
        public virtual int Point
        {
            get => _point;
            set
            {
                _point = value;
                RaisePropertyChanged(nameof(Point));
            }
        }

        private string _name;
        public virtual string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public Fruit(string name, int point)
        {
            Name = name;
            Point = point;
        }
    }
}
