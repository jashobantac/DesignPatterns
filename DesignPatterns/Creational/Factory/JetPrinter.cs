namespace Creational.Factory
{
    public class JetPrinter : IPrinter
    {
        public string Name { get; private set; }

        public JetPrinter(string name = "Jet Printer")
        {
            Name = name;
        }

        public void Configure()
        {
            System.Console.WriteLine(string.Format("Configuring {0}.", Name));
        }

        public void Print()
        {
            System.Console.WriteLine(string.Format("Printing from {0}.", Name));
        }
    }
}
