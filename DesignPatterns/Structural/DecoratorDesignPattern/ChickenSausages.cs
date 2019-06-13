namespace Structural.DecoratorDesignPattern
{
    public class ChickenSausages : Topping
    {
        public override string Name { get; set; } = "Chicken Sausage";
        public override double UnitPrice { get; set; } = 45;
    }
}
