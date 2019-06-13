namespace Structural.DecoratorDesignPattern
{
    public class HandTossedPizza : PizzaBase
    {
        public HandTossedPizza()
        {
            System.Console.WriteLine("Hand Tossed Pizza");
        }

        public override double GetPrice()
        {
            return Price + 20;
        }
    }
}
