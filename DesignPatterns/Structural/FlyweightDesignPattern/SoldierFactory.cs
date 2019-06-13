namespace Structural.FlyweightDesignPattern
{
    public class SoldierFactory
    {
        public static Soldier _soldier;
        public static Soldier GetSoldier()
        {
            if (_soldier == null)
            {
                _soldier = new Soldier();
            }
            return _soldier;
        }
    }
}
