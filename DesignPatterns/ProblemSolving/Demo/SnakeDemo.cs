using System;
using System.Text;
using System.Timers;

using ProblemSolving.SnakeGame;

namespace ProblemSolving.Demo
{
    public class SnakeDemo : IDemo
    {
        private readonly object _locker = new object();
        private bool isValid = true;
        private Timer _moveTimer = null;
        private Timer _fruitTimer = null;
        private Snake snake = null;
        private Field field = null;
        private string direction = "L";
        public void Run()
        {
            Console.OutputEncoding = Encoding.Unicode;
            field = new Field(10, 10);
            //field.UpdateValue(4, 0, "F");
            //field.UpdateValue(3, 2, "F");
            snake = new Snake(field, new Point(4, 4), 4);
            AlgorithmsAndDataStructures.Matrix.MatrixProblems.PrintMatrix(field.Points);

            _moveTimer = new Timer(500);
            _moveTimer.Elapsed -= OnTimerTick;
            _moveTimer.Elapsed += OnTimerTick;


            _fruitTimer = new Timer(5000);
            _fruitTimer.Elapsed -= OnFruitTimerTick;
            _fruitTimer.Elapsed += OnFruitTimerTick;

            _moveTimer.Start();
            _fruitTimer.Start();

            while (isValid)
            {
                ConsoleKeyInfo dir = Console.ReadKey();
                string key = dir.KeyChar.ToString().ToUpper();

                if (dir.Key == ConsoleKey.UpArrow)
                {
                    key = "U";
                }

                if (dir.Key == ConsoleKey.DownArrow)
                {
                    key = "D";
                }

                if (dir.Key == ConsoleKey.LeftArrow)
                {
                    key = "L";
                }

                if (dir.Key == ConsoleKey.RightArrow)
                {
                    key = "R";
                }
                if (string.Equals(key, "u", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(key, "d", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(key, "l", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(key, "r", StringComparison.OrdinalIgnoreCase))
                {
                    lock (_locker)
                    {
                        // prevent left when direction is right.
                        if ((direction == "L" && key == "R") || (direction == "R" && key == "L"))
                        {
                            continue;
                        }

                        // prevent up when directioni is down and vice versa.
                        if ((direction == "U" && key == "D") || (direction == "D" && key == "U"))
                        {
                            continue;
                        }
                        direction = key.ToUpper();
                    }
                }
            }
        }

        private int lastX = -1;
        private int lastY = -1;
        private void OnFruitTimerTick(object sender, ElapsedEventArgs e)
        {
            if (_moveTimer.Interval > 20)
            {
                _moveTimer.Interval = _moveTimer.Interval - 20;
            }

            Random random = new Random();
            int x = random.Next(0, field.Width - 1);
            int y = random.Next(0, field.Width - 1);

            if (lastX >= 0 && lastY >= 0 && field.Points[lastX, lastY] == "F")
            {
                field.Points[lastX, lastY] = null;
            }
            if (field.Points[x, y] == null)
            {
                lastX = x;
                lastY = y;
                field.Points[x, y] = "F";
            }
        }

        private void OnTimerTick(object sender, ElapsedEventArgs e)
        {
            lock (_locker)
            {
                isValid = snake.Move(direction);
            }
            if (!isValid)
            {
                Console.WriteLine("\n*************Game Over*************");
                _moveTimer.Stop();
                _fruitTimer.Stop();
                return;
            }
            Print(field);
        }

        private static void Print(Field field)
        {
            Console.Clear();
            AlgorithmsAndDataStructures.Matrix.MatrixProblems.PrintMatrix(field.Points);
        }
    }
}
