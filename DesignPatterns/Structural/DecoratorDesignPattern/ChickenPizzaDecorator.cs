namespace Structural.DecoratorDesignPattern
{
    public class ChickenPizzaDecorator : Decorator
    {
        public ChickenPizzaDecorator(PizzaBase pizzaBase) : base(pizzaBase)
        {
            Topping chickenSausage = new ChickenSausages();
            AddTopping(chickenSausage);
        }
    }

    public class PaneerPizzaDecorator : Decorator
    {
        public PaneerPizzaDecorator(PizzaBase pizzaBase) : base(pizzaBase)
        {
            Topping paneerTopping = new PaneerTikka();
            AddTopping(paneerTopping);
        }
    }
}
