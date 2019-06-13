using System;

using Driver.Behavioral;
using Driver.Structural;

namespace Driver
{
    internal class Program
    {
        private static IDemo _demo;
        private static void Main(string[] args)
        {
            //_demo = new AbstractFactoryDemo();
            _demo = new BuilderDemo();
            _demo = new PrototypeDemo();
            _demo = new AdapterDemo();


            _demo = new BridgeDemo();
            _demo = new DecoratorDemo();
            _demo = new FlyWeightDemo();

            _demo = new StateDemo();
            _demo = new StrategyDemo();
            _demo = new CommandDemo();

            _demo.Run();
            Console.ReadKey();
        }
    }
}
