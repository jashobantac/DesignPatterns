using Structural.BridgeDesignPattern;

namespace Driver.Structural
{
    public class BridgeDemo : IDemo
    {
        public void Run()
        {
            IBridgeFormatter normalFormatter = new NormalDisplayFormatter();
            IBridgeFormatter reverseDisplayFormatter = new ReverseDisplayFormatter();

            DisplayApp windows10DisplayApp = new Windows10Display(normalFormatter, "Hello World");
            windows10DisplayApp.Display();

            DisplayApp windows10ReverseDisplayApp = new Windows10Display(reverseDisplayFormatter, "Hello World");
            windows10ReverseDisplayApp.Display();

            DisplayApp windows8DisplayApp = new Windows8Display(normalFormatter, "Hello World");
            windows8DisplayApp.Display();

            DisplayApp windows8ReverseDisplayApp = new Windows8Display(reverseDisplayFormatter, "Hello World");
            windows8ReverseDisplayApp.Display();
        }
    }
}
