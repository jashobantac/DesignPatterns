using System;

namespace Creational.Factory
{
    public class LaserPrinter : IPrinter
    {
        public string Name { get; private set; }

        public LaserPrinter(string name = "Laser Printer")
        {
            Name = name;
        }

        public void Configure()
        {
            Console.WriteLine(string.Format("Configuring {0}.", Name));
        }

        public void Print()
        {
            Console.WriteLine(string.Format("Printing from {0}.", Name));
        }
    }
}
