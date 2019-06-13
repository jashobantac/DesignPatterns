using System.Collections.Generic;

namespace Structural.AdapterDesignPattern
{
    public class Client
    {
        public void ProcessNames()
        {
            ITarget target = new Adapter();
            List<string> names = target.GetNames();
            foreach (string name in names)
            {
                System.Console.WriteLine(name);
            }
        }
    }
}
