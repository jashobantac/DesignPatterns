using System;

namespace ProblemSolving.MarsRover
{
    public class RoverClient
    {
        #region Private Variable Declarations.

        private readonly Rover _rover;
        private readonly int _maxWidth;
        private readonly int _maxHeight;

        #endregion

        #region Constructor.

        public RoverClient(Rover rover, int maxWidth, int maxHeight)
        {
            _rover = rover;
            _maxWidth = maxWidth;
            _maxHeight = maxHeight;
        }

        #endregion

        #region Public Method Declarations.

        public void ProcessCommand(string command)
        {
            Console.WriteLine(string.Format("Initial Position of Rover is : ({0},{1}),{2}",
                _rover.Position.X,
                _rover.Position.Y,
                _rover.Direction));

            char[] commandList = command.ToCharArray();
            foreach (char character in commandList)
            {
                if (Enum.IsDefined(typeof(Command), character.ToString()))
                {
                    Action((Command)(Enum.Parse(typeof(Command), character.ToString(), true)));
                    Console.WriteLine(string.Format("Position of Rover is : ({0},{1}),{2}",
                        _rover.Position.X,
                        _rover.Position.Y,
                        _rover.Direction));
                }
            }

            Console.WriteLine(string.Format("The Final Position of Rover is : ({0},{1}),{2}",
                _rover.Position.X,
                _rover.Position.Y,
                _rover.Direction));
        }

        #endregion

        #region Private Method Declarations.

        private void Action(Command command)
        {
            Console.WriteLine("Action : " + command.ToString());
            switch (command)
            {
                case Command.L:
                case Command.R:
                    RotateRover(command);
                    break;
                case Command.M:
                    MoveRover();
                    break;
            }
        }

        private void RotateRover(Command command)
        {
            // Left Command.
            if (command == Command.L)
            {
                switch (_rover.Direction)
                {
                    case Direction.N:
                        _rover.Direction = Direction.W;
                        break;
                    case Direction.E:
                        _rover.Direction = Direction.N;
                        break;
                    case Direction.W:
                        _rover.Direction = Direction.S;
                        break;
                    case Direction.S:
                        _rover.Direction = Direction.E;
                        break;
                    default:
                        break;
                }
            }
            // Right Command.
            if (command == Command.R)
            {
                switch (_rover.Direction)
                {
                    case Direction.N:
                        _rover.Direction = Direction.E;
                        break;
                    case Direction.E:
                        _rover.Direction = Direction.S;
                        break;
                    case Direction.W:
                        _rover.Direction = Direction.N;
                        break;
                    case Direction.S:
                        _rover.Direction = Direction.W;
                        break;
                    default:
                        break;
                }
            }
        }

        private void MoveRover(int steps = 1)
        {
            if (CanMove(_rover.Direction, steps) == false)
            {
                Console.WriteLine("Cannot Move.");
                return;
            }

            switch (_rover.Direction)
            {
                case Direction.N:
                    _rover.Position.Y = _rover.Position.Y + steps;
                    break;
                case Direction.E:
                    _rover.Position.X = _rover.Position.X + steps;
                    break;
                case Direction.W:
                    _rover.Position.X = _rover.Position.X - steps;
                    break;
                case Direction.S:
                    _rover.Position.Y = _rover.Position.Y - steps;
                    break;
                default:
                    break;
            }
        }

        private bool CanMove(Direction direction, int steps)
        {
            switch (direction)
            {
                case Direction.N:
                    return _rover.Position.Y + steps <= _maxHeight;
                case Direction.E:
                    return _rover.Position.X + steps <= _maxWidth;
                case Direction.W:
                    return _rover.Position.X - steps >= 0;
                case Direction.S:
                    return _rover.Position.Y - steps >= 0;
            }
            return false;
        }

        #endregion
    }
}