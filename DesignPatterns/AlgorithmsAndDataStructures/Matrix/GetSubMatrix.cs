namespace AlgorithmsAndDataStructures.Matrix
{
    public partial class MatrixProblems
    {
        public static void PrintSpiral(int[,] matrix, int rowStartIndex, int rowEndIndex, int columnStartIndex, int columnEndIndex)
        {
            if (rowStartIndex > rowEndIndex || columnStartIndex > columnEndIndex)
            {
                return;
            }

            // print first row.
            for (int i = columnStartIndex; i <= columnEndIndex; i++)
            {
                System.Console.Write(matrix[rowStartIndex, i] + " ");
            }

            // print middle row.
            int middleRowStartIndex = rowStartIndex + 1;
            int middleRowEndIndex = rowEndIndex - 1;
            if (middleRowStartIndex <= middleRowEndIndex)
            {
                for (int i = middleRowStartIndex; i <= middleRowEndIndex; i++)
                {
                    System.Console.Write(matrix[i, columnEndIndex] + " ");
                }
            }

            // print bottom row.
            int bottomColumnStartIndex = columnEndIndex;
            int bottomColumnEndIndex = columnStartIndex;

            if ((bottomColumnStartIndex >= bottomColumnEndIndex) && (rowStartIndex != rowEndIndex))
            {
                for (int i = bottomColumnStartIndex; i >= columnStartIndex; i--)
                {
                    System.Console.Write(matrix[rowEndIndex, i] + " ");
                }
            }

            // print left middle row.
            middleRowEndIndex = rowStartIndex + 1;
            middleRowStartIndex = rowEndIndex - 1;
            if (middleRowStartIndex >= middleRowEndIndex)
            {
                for (int i = middleRowStartIndex; i >= middleRowEndIndex; i--)
                {
                    System.Console.Write(matrix[i, columnStartIndex] + " ");
                }
            }

            PrintSpiral(matrix, ++rowStartIndex, --rowEndIndex, ++columnStartIndex, --columnEndIndex);
        }

        public static void RotateMatrix(int[,] matrix, int rowStartIndex, int rowEndIndex, int colStartIndex, int colEndIndex)
        {
            if (rowStartIndex > rowEndIndex || colStartIndex > colEndIndex)
            {
                return;
            }

            // Shift the top row.
            int last = matrix[rowStartIndex, colEndIndex];
            int temp;
            for (int i = colEndIndex; i > colStartIndex; i--)
            {
                matrix[rowStartIndex, i] = matrix[rowStartIndex, i - 1];
            }

            // Shift the middle right.
            if (rowStartIndex < rowEndIndex)
            {
                temp = last;
                last = matrix[rowEndIndex, colEndIndex];
                for (int i = rowEndIndex; i > rowStartIndex; i--)
                {
                    matrix[i, colEndIndex] = matrix[i - 1, colEndIndex];
                }
                matrix[rowStartIndex + 1, colEndIndex] = temp;
            }

            // Print the bottom row.
            if (colStartIndex < colEndIndex)
            {
                temp = last;
                last = matrix[rowEndIndex, colStartIndex];
                for (int i = colStartIndex; i < colEndIndex - 1; i++)
                {
                    matrix[rowEndIndex, i] = matrix[rowEndIndex, i + 1];
                }
                matrix[rowEndIndex, colEndIndex - 1] = temp;
            }

            // Print the left column.
            if (rowStartIndex < rowEndIndex)
            {
                temp = last;
                for (int i = 0; i < rowEndIndex - 1; i++)
                {
                    matrix[i, colStartIndex] = matrix[i + 1, colStartIndex];
                }
                matrix[rowEndIndex - 1, colStartIndex] = temp;
            }
            RotateMatrix(matrix, ++rowStartIndex, --rowEndIndex, ++colStartIndex, --colEndIndex);
            //PrintMatrix(matrix);
        }
    }
}
