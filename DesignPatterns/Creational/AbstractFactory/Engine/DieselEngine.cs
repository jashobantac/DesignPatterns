using System;

namespace Creational.AbstractFactory
{
    public class DieselEngine : Engine
    {
        public override void Start()
        {
            Console.WriteLine("Starting a Diesel Engine..");
        }
    }
}
