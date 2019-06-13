namespace Structural.DecoratorDesignPattern
{
    public class ThincrustPizza : PizzaBase
    {
        public ThincrustPizza()
        {
            System.Console.WriteLine("Thin Crust Pizza");
        }

        public override double GetPrice()
        {
            return Price + 10;
        }
    }
}
