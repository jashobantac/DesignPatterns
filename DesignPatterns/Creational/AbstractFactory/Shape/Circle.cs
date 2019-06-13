using System;

namespace Creational.AbstractFactory
{
    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a Circle..");
        }
    }
}
