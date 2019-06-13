namespace Structural.DecoratorDesignPattern
{
    public class RoastedOnion : Topping
    {
        public override string Name { get; set; } = "Roasted Onion";
        public override double UnitPrice { get; set; } = 30;
    }
}
