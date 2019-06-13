using System.Collections.Generic;
using System.Linq;

namespace ProblemSolving.IPODInventory
{
    public class StoreFactory
    {
        private readonly List<Store> _stores;
        public StoreFactory()
        {
            _stores = new List<Store>();
        }

        public Store GetStore(string factoryLocation)
        {
            Store store = _stores.FirstOrDefault(x => x.Location == factoryLocation);
            if (store == null)
            {
                if (string.Equals(factoryLocation, Constants.ARGENTINA))
                {
                    store = new ArgentinaStore(new Inventory(), this);
                    _stores.Add(store);
                }
                else if (string.Equals(factoryLocation, Constants.BRAZIL))
                {
                    store = new BrazilStore(new Inventory(), this);
                    _stores.Add(store);
                }
            }
            return store;
        }
    }
}
