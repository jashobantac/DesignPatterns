using System;
using System.Collections.Generic;

namespace ProblemSolving.HackerRank.Backtracking
{
    public class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }
    }
    public class NQueenProblem
    {
        public static Position[] GetPositions(int n)
        {
            Position[] validPositions = new Position[n];
            GetValidPositions(n, 0, validPositions);
            return validPositions;
        }

        private static bool GetAllValidPositions(int n,int row,Position[] validPositions,List<Position[]> positions)
        {
            throw new NotImplementedException();
        }

        private static bool GetValidPositions(int n, int row, Position[] validPositions)
        {
            if (row == n)
            {
                return true;
            }
            int column = 0;
            for (column = 0; column < n; column++)
            {
                bool isSafe = true;
                // Check if the position is safe.
                for (int queen = 0; queen < row; queen++)
                {
                    if (validPositions[queen].Column == column)
                    {
                        isSafe = false;
                        break;
                    }
                    if (validPositions[queen].Column - validPositions[queen].Row == column - row)
                    {
                        isSafe = false;
                        break;
                    }
                    if (validPositions[queen].Column + validPositions[queen].Row == column + row)
                    {
                        isSafe = false;
                        break;
                    }
                }
                if (isSafe == true)
                {
                    // attempt for the lower row.
                    validPositions[row] = new Position() { Row = row, Column = column };
                    bool isNextItemSafe = GetValidPositions(n, row + 1, validPositions);
                    if (isNextItemSafe == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
