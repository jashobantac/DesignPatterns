using System;

using Creational.Prototype;

namespace Driver
{
    public class PrototypeDemo : IDemo
    {
        public void Run()
        {
            Prototype prototype = new ConcretePrototype(1);
            Console.WriteLine(string.Format("Prototype ID: {0}", prototype.Id));
            Prototype clone = prototype.Clone();
            Console.WriteLine(string.Format("Clone ID: {0}", clone.Id));
        }
    }
}
