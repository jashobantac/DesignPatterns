namespace Behavioral.CommandDesignPattern
{
    public abstract class Command
    {
        protected readonly Receiver _receiver;
        public abstract void Execute();
        public abstract void UnExecute();
        public Command(Receiver receiver)
        {
            _receiver = receiver;
        }
    }
}
