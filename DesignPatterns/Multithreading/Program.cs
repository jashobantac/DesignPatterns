using System.Collections.Generic;

namespace Multithreading
{
    internal class Program
    {
        private static void Main(string[] args)
        {
        }

        private static void RemoveFromList()
        {
            List<int> _list = new List<int>()
            {
                1,
                2,
                3,
                4,
                5
            };
            int count = _list.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                _list.RemoveAt(i);
            }
            List<int> test = _list;
        }
    }
}