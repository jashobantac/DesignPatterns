using Behavioral.CommandDesignPattern;

namespace Driver.Behavioral
{
    public class CommandDemo : IDemo
    {
        public void Run()
        {
            //Receiver receiver = new Receiver();
            //Command cmd = new ConcreteCommand(receiver);
            //cmd.Execute();
            //Invoker invoker = new Invoker(cmd);
            //invoker.ExecuteCommand();

            Calculator cal = new Calculator();
            UserActions user = new UserActions(cal);
            user.Compute('+', 120);
            user.Compute('-', 20);
            user.Compute('*', 50);
            user.Compute('/', 10);

            user.Undo(4);
            user.Redo(4);
        }
    }
}
