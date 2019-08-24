using System.Collections.Generic;

using ProblemSolving.SnakeGame.Base;

namespace ProblemSolving.SnakeGame
{
    public class Snake : ModelBase
    {
        private readonly Field _field;
        #region Public Properties.

        public Point Head { get; private set; }
        public Point Tail { get; private set; }

        #endregion

        #region Constructors.

        public Snake(Field field, Point start, int length)
        {
            _field = field;
            ValidateSnake(field, start, length);
        }

        private void ValidateSnake(Field field, Point start, int length)
        {
            if (start.X < 0 || start.X > field.Width - 1 || start.Y < 0 || start.Y > field.Height - 1)
            {
                throw new System.Exception("Invalid Start Point.");
            }
            if (length <= 1)
            {
                throw new System.Exception("Invalid Length");
            }
            if (start.X + length > field.Width - 1)
            {
                throw new System.Exception("Too Much Length");
            }

            Head = start;
            for (int i = 0; i < length; i++)
            {
                field.Points[Head.X, Head.Y + i] = "L";
            }
            Tail = new Point(Head.X, Head.Y + length - 1);
        }

        #endregion

        public bool Move(string direction)
        {
            string next = null;

            _field.UpdateValue(Head.X, Head.Y, direction);
            switch (direction)
            {
                // X is decreasing on UP.
                case "U":
                    if (Head.X - 1 < 0 || !IsMoveAllowed(Head.X - 1, Head.Y))
                    {
                        return false;
                    }
                    Head.X = Head.X - 1;
                    next = _field.Points[Head.X, Head.Y];
                    _field.UpdateValue(Head.X, Head.Y, direction);
                    if (next != "F")
                    {
                        RemoveTail();
                    }
                    break;

                // Y is increasing on RIGHT.
                case "R":
                    if (Head.Y + 1 >= _field.Width || !IsMoveAllowed(Head.X, Head.Y + 1))
                    {
                        return false;
                    }
                    Head.Y = Head.Y + 1;
                    next = _field.Points[Head.X, Head.Y];
                    if (next != "F")
                    {
                        RemoveTail();
                    }
                    _field.UpdateValue(Head.X, Head.Y, direction);
                    break;
                // X is increasing on DOWN>
                case "D":
                    if (Head.X + 1 >= _field.Height || !IsMoveAllowed(Head.X + 1, Head.Y))
                    {
                        return false;
                    }
                    Head.X = Head.X + 1;
                    next = _field.Points[Head.X, Head.Y];
                    if (next != "F")
                    {
                        RemoveTail();
                    }
                    _field.UpdateValue(Head.X, Head.Y, direction);
                    break;
                // Y is decreasing with L.
                case "L":
                    if (Head.Y - 1 < 0 || !IsMoveAllowed(Head.X, Head.Y - 1))
                    {
                        return false;
                    }
                    Head.Y = Head.Y - 1;
                    next = _field.Points[Head.X, Head.Y];
                    if (next != "F")
                    {
                        RemoveTail();
                    }
                    _field.UpdateValue(Head.X, Head.Y, direction);
                    break;
            }
            return true;
        }

        private bool IsMoveAllowed(int x, int y)
        {
            List<string> validPoints = new List<string>() { "A", "F" };
            return _field.Points[x, y] == null || validPoints.Contains(_field.Points[x, y]);
        }

        private void RemoveTail()
        {
            string direction = _field.Points[Tail.X, Tail.Y];
            _field.UpdateValue(Tail.X, Tail.Y, null);
            switch (direction)
            {
                case "U":
                    Tail.X = Tail.X - 1;
                    break;
                case "L":
                    Tail.Y = Tail.Y - 1;
                    break;
                case "R":
                    Tail.Y = Tail.Y + 1;
                    break;
                case "D":
                    Tail.X = Tail.X + 1;
                    break;
            }
            //_field.Points[Tail.X, Tail.Y] = null;
        }

        private void CheckCollision(Point head, string direction)
        {

        }

        public void AddNode()
        {

        }
    }
}
