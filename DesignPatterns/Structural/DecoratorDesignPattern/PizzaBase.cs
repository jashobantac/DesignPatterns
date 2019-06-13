namespace Structural.DecoratorDesignPattern
{
    public abstract class PizzaBase
    {
        public double Price { get; set; } = 100;
        public abstract double GetPrice();
    }
}
