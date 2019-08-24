using System;

namespace AlgorithmsAndDataStructures.Matrix
{
    public partial class MatrixProblems
    {
        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    System.Console.Write(matrix[i, j] + " ");
                }
                System.Console.WriteLine("\n");
            }
        }

        public static void PrintMatrix(object[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == null)
                    {
                        Console.Write(". ");
                    }
                    else
                    {
                        object item = matrix[i, j];
                        if (item.ToString() == "F")
                        {
                            Console.Write("X ");
                        }
                        else
                        {
                            Console.Write("■ ");
                        }
                    }
                }
                Console.WriteLine("\n");
            }
        }
    }
}
