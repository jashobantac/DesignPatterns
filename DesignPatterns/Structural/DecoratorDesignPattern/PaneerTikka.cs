namespace Structural.DecoratorDesignPattern
{
    public class PaneerTikka : Topping
    {
        public override string Name { get; set; } = "Paneer Tikka";
        public override double UnitPrice { get; set; } = 50;
    }
}
