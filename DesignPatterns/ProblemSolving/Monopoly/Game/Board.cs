using System.Linq;
using ProblemSolving.Monopoly.Game.Cells;

namespace ProblemSolving.Monopoly.Game
{
    public class Board
    {
        //private readonly int _currentDiceIndex = 0;
        private readonly CellFactory _cellFactory;
        public Cell StartCell { get; private set; }

        #region Constructors.

        public Board(CellFactory cellFactory, string input)
        {
            _cellFactory = cellFactory;
            StartCell = CreateCells(input);
        }

        #endregion

        private Cell CreateCells(string input)
        {
            string[] cellTypes = input.Split(',');

            Cell currentCell = _cellFactory.CreateCell(cellTypes[0].ToString());
            Cell head = currentCell;
            foreach (string item in cellTypes.Skip(1))
            {
                Cell cell = _cellFactory.CreateCell(item); ;
                currentCell.Next = cell;
                currentCell = cell;
            }
            currentCell.Next = head;
            return head;

            //Cell previousCell = null;
            //foreach (string item in cellTypes)
            //{
            //    currentCell = _cellFactory.CreateCell(item.ToString());
            //    if (previousCell != null)
            //    {
            //        previousCell.Next = currentCell;
            //    }
            //    else
            //    {
            //        head = currentCell;
            //    }
            //    previousCell = currentCell;
            //}
            //currentCell.Next = head;
            //return head;
        }

        public int GetCurrentCellIndex(Cell cell)
        {
            int index = 1;

            Cell root = StartCell;
            Cell current = StartCell;
            if (current == cell)
            {
                return index;
            }
            while (current.Next != null && current.Next != root)
            {
                index++;
                current = current.Next;
                if (current == cell)
                {
                    return index;
                }
            }
            return -1;
        }

        public int TotalCells()
        {
            Cell root = StartCell;
            int count = 1;

            Cell start = StartCell;
            while (start.Next != null && start.Next != root)
            {
                count++;
                start = start.Next;
            }
            return count;
        }
    }
}
