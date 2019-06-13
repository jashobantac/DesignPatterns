using System;

namespace Creational.AbstractFactory
{
    public class Rect : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a Rectangle..");
        }
    }
}
