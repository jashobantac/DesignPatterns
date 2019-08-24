using ProblemSolving.SnakeGame.Base;

namespace ProblemSolving.SnakeGame
{
    public class Point : ModelBase
    {
        #region Public Properties.

        //private string _direction;
        //public string Direction
        //{
        //    get => _direction;
        //    set
        //    {
        //        _direction = value;
        //        RaisePropertyChanged(nameof(Direction));
        //    }
        //}

        private int _x;
        public int X
        {
            get => _x;
            set
            {
                _x = value;
                RaisePropertyChanged(nameof(X));
            }
        }

        private int _y;
        public int Y
        {
            get => _y;
            set
            {
                _y = value;
                RaisePropertyChanged(nameof(Y));
            }
        }

        #endregion

        #region Constructors.

        public Point(int x, int y)
        {
            X = x;
            Y = y;
            //Direction = type;
        }

        #endregion
    }
}