using System;

namespace Structural.FlyweightDesignPattern
{
    public class Soldier : IFlyWeight
    {
        public void MoveSoldier(int prevLocX, int prevLocY, int newLocX, int newLocY)
        {
            Console.WriteLine(string.Format("Moving Solider from Old Location({0},{1}) to New Location({2}{3})", prevLocX, prevLocY, newLocX, newLocY));
        }
    }
}
