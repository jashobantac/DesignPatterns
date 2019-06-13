namespace Behavioral.StateDesignPattern
{
    public class ConcreteStateB : State
    {
        public override void Handle(Context context)
        {
            System.Console.WriteLine("Handling Concrete State B");
            context.State = new ConcreteStateA();
        }
    }
}
