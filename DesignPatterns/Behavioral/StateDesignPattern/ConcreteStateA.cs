namespace Behavioral.StateDesignPattern
{
    public class ConcreteStateA : State
    {
        public override void Handle(Context context)
        {
            System.Console.WriteLine("Handling Concrete State A");
            context.State = new ConcreteStateB();
        }
    }
}
