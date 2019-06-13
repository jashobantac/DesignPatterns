using System.Collections.Generic;
using Structural.FlyweightDesignPattern;

namespace Driver.Structural
{
    public class FlyWeightDemo : IDemo
    {
        public void Run()
        {
            List<SoldierClient> warSoldiers = new List<SoldierClient>
            {
                new SoldierClient(),
                new SoldierClient(),
                new SoldierClient(),
                new SoldierClient(),
                new SoldierClient()
            };

            warSoldiers[0].MoveSoldier(100, 150);
            warSoldiers[2].MoveSoldier(200, 150);
            warSoldiers[3].MoveSoldier(300, 150);
        }
    }
}
