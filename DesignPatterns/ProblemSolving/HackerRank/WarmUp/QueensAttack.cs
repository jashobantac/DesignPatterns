namespace ProblemSolving.HackerRank.WarmUp
{
    //https://www.hackerrank.com/challenges/queens-attack-2/problem
    public class QueensAttackProblem
    {
        public static int QueensAttack(int n, int totalObstacles, int r_q, int c_q, int[][] obstacles)
        {
            int totalSquares = 0;

            int currentRight = r_q;
            int currentLeft = r_q;

            // Horizontal move right.

            // Vertical Move Up.

            // Vertical Move Down.

            // Diagonal top right.

            // Diagonal bottom right.

            // Diagonal bottom left.

            // Diagonal top left.

            return totalSquares;
        }

        public static int GetTotalHorizontalPossibleMoves(int n, int r_q, int c_q, int[,] obstacles)
        {
            int totalRightMoves = 0;
            int totalLeftMoves = 0;

            int currentPosition = c_q - 1;
            while (currentPosition < n - 1)
            {
                totalRightMoves++;
                currentPosition++;
            }

            currentPosition = c_q - 1;
            while (currentPosition > 0)
            {
                totalLeftMoves++;
                currentPosition--;
            }
            return totalLeftMoves + totalRightMoves;
        }

        public int GetTotalVerticalPossibleMoves(int n, int r_q, int c_q, int[][] obstacles)
        {
            int totalTopMoves = 0;
            int totalBottomMoves = 0;
            int currentPosition = r_q - 1;
            while (currentPosition < n - 1)
            {
                totalTopMoves++;
                currentPosition++;
            }

            currentPosition = r_q - 1;
            while (currentPosition > 0)
            {
                totalBottomMoves++;
                currentPosition--;
            }
            return totalBottomMoves + totalTopMoves;
        }

        public int GetTotalDiagonalPossibleMoves(int n, int c_q, int r_q, int[][] obstacles)
        {
            int totalTopLeft = 0;
            int totalBottomLeft = 0;
            int totalBottomRight = 0;
            int totalTopRight = 0;

            return totalBottomLeft + totalTopLeft + totalTopRight + totalBottomRight;
        }
    }
}
