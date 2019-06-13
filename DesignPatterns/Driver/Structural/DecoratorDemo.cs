using Structural.DecoratorDesignPattern;

namespace Driver.Structural
{
    public class DecoratorDemo : IDemo
    {
        public void Run()
        {
            ThincrustPizza thincrustPizza = new ThincrustPizza();
            double price = thincrustPizza.GetPrice();
            System.Console.WriteLine("Price : Rs " + price);

            Decorator vegPizzaDecorator = new PaneerPizzaDecorator(thincrustPizza);
            RoastedOnion roastedOnionTopping = new RoastedOnion();
            vegPizzaDecorator.AddTopping(roastedOnionTopping);
            price = vegPizzaDecorator.GetPrice();
            System.Console.WriteLine("Price : Rs " + price);

            vegPizzaDecorator.RemoveTopping(roastedOnionTopping);
            price = vegPizzaDecorator.GetPrice();
            System.Console.WriteLine("Price : Rs " + price);
        }
    }
}
