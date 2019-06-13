namespace Behavioral.CommandDesignPattern
{
    public class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver) : base(receiver)
        {
        }

        public override void Execute()
        {
            _receiver.Action();
        }

        public override void UnExecute()
        {
            throw new System.NotImplementedException();
        }
    }
}
