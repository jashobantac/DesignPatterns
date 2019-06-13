namespace Behavioral.CommandDesignPattern
{
    public class Invoker
    {
        private readonly Command _command;

        public Invoker(Command command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }
}
