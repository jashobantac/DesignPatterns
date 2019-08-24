namespace AlgorithmsAndDataStructures.Matrix
{
    public class MatrixDemo : IDemo
    {
        private readonly int[,] matrix = new int[,] {
                { 0,1,2,3 },
                { 4,5,6,7 },
                { 8,9,10,11 },
                { 12,13,14,15 }
            };

        public void Run()
        {
            System.Console.WriteLine("Printing Matrix.");
            MatrixProblems.PrintMatrix(matrix);

            //MatrixProblems.PrintSpiral(matrix, 0, matrix.GetLength(0) - 1, 0, matrix.GetLength(1) - 1);

            //System.Console.WriteLine("\nRotating Clockwise.");
            //MatrixProblems.RotateMatrix(matrix, 0, matrix.GetLength(0) - 1, 0, matrix.GetLength(1) - 1);
            //MatrixProblems.PrintMatrix(matrix);

            MatrixProblems.RotateMatrix90DegAntiClockWise(matrix);
            MatrixProblems.PrintMatrix(matrix);
        }
    }
}
