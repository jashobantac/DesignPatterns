using Structural.AdapterDesignPattern;

namespace Driver
{
    public class AdapterDemo : IDemo
    {
        public void Run()
        {
            Client adapterClient = new Client();
            adapterClient.ProcessNames();
        }
    }
}