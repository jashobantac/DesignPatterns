using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemSolving.SnakeGame;
using ProblemSolving.SnakeGame;

namespace AlgorithmsUnitTest
{
    [TestClass]
    public class SnakeGameTest
    {
        [TestMethod]
        public void CreateGame()
        {

        }

        [TestMethod]
        public void CreateSnake()
        {
            Field field = new Field(10, 10);
            Snake snake = new Snake(field, new Point(4, 4), 3);
            Assert.IsTrue(snake.Tail.X == 6);
            Assert.IsTrue(snake.Tail.Y == 4);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateLongSnake()
        {
            Field field = new Field(10, 10);
            Snake snake = new Snake(field, new Point(4, 4), 10);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateSmallSnake()
        {
            Field field = new Field(10, 10);
            Snake snake = new Snake(field, new Point(4, 4), 1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void PlayGame()
        {
            Field field = new Field(5, 5);
            Snake snake = new Snake(field, new Point(1, 2), 3);

            AlgorithmsAndDataStructures.Matrix.MatrixProblems.PrintMatrix(field.Points);

            string direction = "L";
            snake.Move(direction);
            snake.Move(direction);
            snake.Move(direction);

            AlgorithmsAndDataStructures.Matrix.MatrixProblems.PrintMatrix(field.Points);
        }

    }
}
