using Behavioral.StateDesignPattern;

namespace Driver.Behavioral
{
    public class StateDemo : IDemo
    {
        public void Run()
        {
            Context context = new Context(new ConcreteStateA());
            context.Request();
            context.Request();
            context.Request();
        }
    }
}
