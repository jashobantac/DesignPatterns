using System.Collections.Generic;
using System.Linq;

namespace ProblemSolving.IPODInventory
{
    public class BrazilStore : Store
    {
        private readonly StoreFactory _storeFactory;

        #region Constructors.

        public BrazilStore(Inventory inventory, StoreFactory storeFactory) : base(inventory, Constants.BRAZIL)
        {
            _storeFactory = storeFactory;
            Replenish(100);
        }

        #endregion

        #region Public Overrides.

        public override void Replenish(int count)
        {
            Product iPod = new Product(Constants.IPOD_PRICE_BRAZIL) { Name = Constants.IPOD_PRODUCT_NAME };
            FillInventory(iPod, 100);
        }

        public override Store GetTargetStore()
        {
            return _storeFactory.GetStore(Constants.ARGENTINA);
        }

        #endregion

        #region Private Method Declarations.

        private void FillInventory(Product product, int count)
        {
            ProductFactory factory = new BrazilIpodFactory();
            for (int i = 0; i < count; i++)
            {
                Product iPod = factory.CreateProduct(product.Name, Constants.IPOD_PRICE_ARGENTINA);
                _inventory.AddProduct(iPod);
            }
        }

        #endregion
    }
}