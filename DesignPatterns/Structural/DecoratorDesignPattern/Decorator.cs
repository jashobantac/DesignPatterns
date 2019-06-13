using System.Collections.Generic;

namespace Structural.DecoratorDesignPattern
{
    public class Decorator : PizzaBase
    {
        public List<Topping> Toppings { get; private set; }

        private readonly PizzaBase _pizzaBase;

        public void AddTopping(Topping topping)
        {
            System.Console.WriteLine(string.Format("Added Topping {0}, Price : Rs {1}", topping.Name, topping.UnitPrice));
            Toppings.Add(topping);
        }

        public void RemoveTopping(Topping topping)
        {
            System.Console.WriteLine(string.Format("Removed Topping {0}, Price : Rs {1}", topping.Name, topping.UnitPrice));
            Toppings.Remove(topping);
        }

        public override double GetPrice()
        {
            double toppingPrice = 0;
            foreach (Topping topping in Toppings)
            {
                toppingPrice += topping.UnitPrice;
            }
            return _pizzaBase.GetPrice() + toppingPrice;
        }

        public Decorator(PizzaBase pizzaBase)
        {
            Toppings = new List<Topping>();
            _pizzaBase = pizzaBase;
        }
    }
}
