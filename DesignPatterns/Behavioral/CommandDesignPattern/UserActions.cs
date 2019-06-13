using System.Collections.Generic;

namespace Behavioral.CommandDesignPattern
{
    public class UserActions
    {
        private int _current;
        private readonly Calculator _calculator;
        private readonly List<Command> _cmdList;

        public UserActions(Calculator calculator)
        {
            _calculator = calculator;
            _cmdList = new List<Command>();

            System.Console.WriteLine("Current Value  : {0}", 0);
        }

        public void Redo(int levels = 1)
        {
            System.Console.WriteLine("Redo Level : {0}", levels);
            for (int i = 0; i < levels; i++)
            {
                if (_current <= _cmdList.Count - 1)
                {
                    _cmdList[_current].Execute();
                    _current = _current + 1;
                }
            }
        }

        public void Undo(int levels = 1)
        {
            System.Console.WriteLine("Undo Level : {0}", levels);
            for (int i = 0; i < levels; i++)
            {
                if (_current > 0)
                {
                    _current = _current - 1;
                    _cmdList[_current].UnExecute();
                }
            }
        }

        public void Compute(char @operator, int operand)
        {
            Command cmd = new CalculatorCommand(_calculator, @operator, operand);
            cmd.Execute();
            _cmdList.Add(cmd);

            _current++;
        }
    }
}
