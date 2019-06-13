using System;

namespace Behavioral.CommandDesignPattern
{
    public class Calculator : Receiver
    {
        private int _curr;

        public void Operation(char @operator, int operand)
        {
            switch (@operator)
            {
                case '+':
                    _curr += operand;
                    break;
                case '-':
                    _curr -= operand;
                    break;
                case '*':
                    _curr *= operand;
                    break;
                case '/':
                    _curr /= operand;
                    break;
                default:
                    break;
            }
            Console.WriteLine("(Operation {1} {2}) | Current value = {0,3}", _curr, @operator, operand);
        }
    }
}
