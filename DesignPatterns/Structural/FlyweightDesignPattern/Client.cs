using System;

namespace Structural.FlyweightDesignPattern
{
    public class SoldierClient
    {
        private int _currentLocX = 10;
        private int _currentLocY = 10;

        private readonly Soldier _soldier;
        public SoldierClient()
        {
            _soldier = SoldierFactory.GetSoldier();
        }

        public void MoveSoldier(int newLocationX, int newLocationY)
        {
            _soldier.MoveSoldier(_currentLocX, _currentLocY, newLocationX, newLocationY);
            _currentLocX = newLocationX;
            _currentLocY = newLocationY;

            Console.WriteLine(string.Format("Solider New Location({0},{1})", _currentLocX, _currentLocY));
        }
    }
}
