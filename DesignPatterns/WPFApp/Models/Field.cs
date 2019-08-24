using System.Collections.ObjectModel;
using System.Linq;

using WPFApp.Models.Base;

namespace WPFApp.Models
{
    public class Field : ModelBase
    {
        public Snake Snake { get; private set; }

        #region Properties.

        public int Width { get; set; }
        public int Height { get; set; }

        private ObservableCollection<Cell> _points;
        public ObservableCollection<Cell> Points
        {
            get => _points;
            set
            {
                _points = value;
                RaisePropertyChanged(nameof(Points));
            }
        }

        public int MoveSnake(string direction)
        {
            Cell head = Points.FirstOrDefault();
            return Snake.Move(direction);
        }

        #endregion

        #region Constructors.

        public Field(int x, int y)
        {
            Width = x;
            Height = y;
            Points = new ObservableCollection<Cell>();

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Cell cell = new Cell(i, j);
                    Points.Add(cell);
                }
            }
        }

        #endregion

        #region Public Properties.

        public void CreateSnake(Cell start, int length)
        {
            if (start.X < 0 || start.X > Width - 1 || start.Y < 0 || start.Y > Height - 1)
            {
                throw new System.Exception("Invalid Start Point.");
            }
            if (length <= 1)
            {
                throw new System.Exception("Invalid Length");
            }
            if (start.X + length > Width)
            {
                throw new System.Exception("Too Much Length");
            }

            Cell Head = start;
            for (int i = 0; i < length; i++)
            {
                Cell cell = GetCell(Head.X, Head.Y + i);
                if (cell != null)
                {
                    Points.Add(cell);
                }
            }
            Snake = new Snake(this, Head, length);
        }

        public void UpdateValue(int x, int y, string direction)
        {
            Cell current = Points.FirstOrDefault(cell => cell.X == x && cell.Y == y);
            if (current != null)
            {
                current.Type = direction;
            }
        }

        public Cell GetCell(int x, int y)
        {
            return Points.FirstOrDefault(cell => cell.X == x && cell.Y == y);
        }

        public void AddFruit(int x, int y, string fruitType)
        {
            Cell cell = GetCell(x, y);
            if (cell != null && string.IsNullOrEmpty(cell.Type))
            {
                cell.Type = fruitType;
            }
        }

        public void RemoveFruit(int x, int y)
        {
            Cell cell = GetCell(x, y);
            if (cell != null && !"LRUD".Contains(cell.Type))
            {
                Points.Remove(cell);
            }
        }

        #endregion
    }
}
