using System;

namespace Structural.BridgeDesignPattern
{
    public interface IBridgeFormatter
    {
        void Display(string text);
    }

    public class NormalDisplayFormatter : IBridgeFormatter
    {
        public void Display(string text)
        {
            Console.WriteLine("This is a normal display of text : " + text);
        }
    }

    public class ReverseDisplayFormatter : IBridgeFormatter
    {
        public void Display(string text)
        {
            Console.WriteLine("This is a reverse display of text : " + text);
        }
    }
}
