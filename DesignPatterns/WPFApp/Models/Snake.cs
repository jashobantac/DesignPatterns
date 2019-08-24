
using WPFApp.Models.Base;

namespace WPFApp.Models
{
    public class Snake : ModelBase
    {
        private readonly Field _field;
        private readonly string validPoints = "WFB";

        #region Public Properties.

        public Cell Head { get; private set; }
        public Cell Tail { get; private set; }

        #endregion

        #region Constructors.

        public Snake(Field field, Cell start, int length)
        {
            _field = field;
            ValidateSnake(field, start, length);
        }

        #endregion

        public int Move(string direction)
        {
            Cell next = null;

            _field.UpdateValue(Head.X, Head.Y, direction);
            switch (direction)
            {
                // X is decreasing on UP.
                case "U":
                    if (Head.X - 1 < 0 || !IsMoveAllowed(Head.X - 1, Head.Y))
                    {
                        return -1;
                    }
                    Head.X = Head.X - 1;
                    next = _field.GetCell(Head.X, Head.Y);
                    _field.UpdateValue(Head.X, Head.Y, direction);
                    if (next.Type == null || (next?.Type != null && !(validPoints.Contains(next.Type))))
                    {
                        RemoveTail();
                    }
                    break;

                // Y is increasing on RIGHT.
                case "R":
                    if (Head.Y + 1 >= _field.Width || !IsMoveAllowed(Head.X, Head.Y + 1))
                    {
                        return -1;
                    }
                    Head.Y = Head.Y + 1;
                    next = _field.GetCell(Head.X, Head.Y);
                    if (next.Type == null || (next?.Type != null && !(validPoints.Contains(next.Type))))
                    {
                        RemoveTail();
                    }
                    _field.UpdateValue(Head.X, Head.Y, direction);
                    break;
                // X is increasing on DOWN>
                case "D":
                    if (Head.X + 1 >= _field.Height || !IsMoveAllowed(Head.X + 1, Head.Y))
                    {
                        return -1;
                    }
                    Head.X = Head.X + 1;
                    next = _field.GetCell(Head.X, Head.Y);
                    if (next.Type == null || (next?.Type != null && !(validPoints.Contains(next.Type))))
                    {
                        RemoveTail();
                    }
                    _field.UpdateValue(Head.X, Head.Y, direction);
                    break;
                // Y is decreasing with L.
                case "L":
                    if (Head.Y - 1 < 0 || !IsMoveAllowed(Head.X, Head.Y - 1))
                    {
                        return -1;
                    }
                    Head.Y = Head.Y - 1;
                    next = _field.GetCell(Head.X, Head.Y);
                    if (next.Type == null || (next?.Type != null && !(validPoints.Contains(next.Type))))
                    {
                        RemoveTail();
                    }
                    _field.UpdateValue(Head.X, Head.Y, direction);
                    break;
            }
            return 1;
        }

        private bool IsMoveAllowed(int x, int y)
        {
            //List<string> validPoints = new List<string>() { "A", "F" };
            return _field.GetCell(x, y) == null
                || string.IsNullOrEmpty(_field.GetCell(x, y).Type)
                || validPoints.Contains(_field.GetCell(x, y).Type);
        }

        private void RemoveTail()
        {
            string direction = _field.GetCell(Tail.X, Tail.Y).Type;
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
        }

        private void ValidateSnake(Field field, Cell start, int length)
        {
            Head = start;
            for (int i = 0; i < length; i++)
            {
                field.GetCell(Head.X, Head.Y + i).Type = "L";
            }
            Tail = new Cell(Head.X, Head.Y + length - 1);
        }
    }
}
