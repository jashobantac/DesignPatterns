using System;
using System.Linq;
using System.Timers;

using Prism.Commands;

using WPFApp.Models;
using WPFApp.Models.Base;

namespace WPFApp
{
    public class GameViewModel : ModelBase
    {
        private readonly object _locker = new object();
        private Timer _moveTimer = null;
        private Timer _fruitTimer = null;
        private string _direction = "L";

        private int _score;
        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                RaisePropertyChanged(nameof(Score));
            }
        }

        private Field _field;
        public Field Field
        {
            get => _field;
            set
            {
                _field = value;
                RaisePropertyChanged(nameof(Field));
            }
        }

        private bool _isGameOver;
        public bool IsGameOver
        {
            get => _isGameOver;
            set
            {
                _isGameOver = value;
                RaisePropertyChanged(nameof(IsGameOver));
            }
        }

        public DelegateCommand<string> MoveCommand { get; private set; }
        public DelegateCommand StartGameCommand { get; set; }
        public DelegateCommand RestartGameCommand { get; set; }

        public GameViewModel()
        {
            CreateField();

            MoveCommand = new DelegateCommand<string>(DoMoveSnake);
            RestartGameCommand = new DelegateCommand(RestartGame);

            _moveTimer.Start();
            _fruitTimer.Start();
        }

        private void StartGame()
        {
            CreateField();
            _fruitTimer.Start();
            _moveTimer.Start();
        }
        private void CreateField()
        {
            _moveTimer = new Timer(200);
            _fruitTimer = new Timer(5000);

            _moveTimer.Elapsed -= OnTimerTick;
            _moveTimer.Elapsed += OnTimerTick;

            _fruitTimer.Elapsed -= OnFruitTimerTick;
            _fruitTimer.Elapsed += OnFruitTimerTick;

            Field = new Field(20, 20);
            Field.CreateSnake(new Cell(4, 4), 3);
        }
        private void RestartGame()
        {
            Score = 0;
            _moveTimer.Stop();
            _fruitTimer.Stop();
            CreateField();

            _moveTimer.Start();
            _fruitTimer.Start();
        }

        private void GameOver()
        {
            _moveTimer.Stop();
            _fruitTimer.Stop();
        }

        private void EndGame()
        {
            _moveTimer.Stop();
            _fruitTimer.Stop();

            Field.UpdateValue(Field.Snake.Head.X, Field.Snake.Head.Y, "C");
        }

        private void OnFruitTimerTick(object sender, ElapsedEventArgs e)
        {
            if (_moveTimer.Interval > 10)
            {
                _moveTimer.Interval = _moveTimer.Interval - 10;
            }
            string validPoints = "WFB";
            Cell fruit = Field.Points.FirstOrDefault(x => x.Type != null && validPoints.Contains(x.Type));
            if (fruit != null)
            {
                fruit.Type = null;
            }

            System.Collections.Generic.IEnumerable<Cell> cells = Field.Points.Where(x => string.IsNullOrEmpty(x.Type));
            int index = new Random().Next(0, cells.Count() - 1);
            //validPointIndex = ++validPointIndex % validPoints.Length;
            if (string.IsNullOrEmpty(Field.Points[index].Type))
            {
                Field.Points[index].Type = "F";
            }
        }
        private void OnTimerTick(object sender, ElapsedEventArgs e)
        {
            lock (_locker)
            {
                
                int score = Field.MoveSnake(_direction);
                if (score == -1)
                {
                    EndGame();
                }
                else
                {
                    Score += score;
                }
            }
        }

        private void DoMoveSnake(string direction)
        {
            lock (_locker)
            {
                if ((_direction == "L" && direction == "R") || (_direction == "R" && direction == "L"))
                {
                    return;
                }

                // prevent up when directioni is down and vice versa.
                if ((direction == "U" && _direction == "D") || (direction == "D" && _direction == "U"))
                {
                    return;
                }

                _direction = direction;
            }
        }
    }
}
