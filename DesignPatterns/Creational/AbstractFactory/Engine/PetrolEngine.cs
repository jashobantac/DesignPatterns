using System;

namespace Creational.AbstractFactory
{
    public class PetrolEngine : Engine
    {
        public override void Start()
        {
            Console.WriteLine("Starting a Diesel Engine..");
        }
    }
}
