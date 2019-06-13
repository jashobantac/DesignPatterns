namespace Behavioral.CommandDesignPattern
{
    public class CalculatorCommand : Command
    {
        private readonly Calculator _calcualtor;
        private char _operator;
        private int _operand;

        public CalculatorCommand(Calculator calculator, char @operator, int operand) : base(calculator)
        {
            _calcualtor = calculator;
            _operator = @operator;
            _operand = operand;
        }

        public void SetOperator(char @operator)
        {
            _operator = @operator;
        }

        public void SetOperand(int operand)
        {
            _operand = operand;
        }

        public override void Execute()
        {
            _calcualtor.Operation(_operator, _operand);
        }

        public override void UnExecute()
        {
            _calcualtor.Operation(Undo(_operator), _operand);
        }

        private char Undo(char @operator)
        {
            switch (@operator)
            {
                case '+':
                    return '-';
                case '-':
                    return '+';
                case '*':
                    return '/';
                case '/':
                    return '*';
                default:
                    break;
            }
            return @operator;
        }
    }
}
