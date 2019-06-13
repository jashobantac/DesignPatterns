using System.Collections.Generic;
using System.Linq;

namespace ProblemSolving.IPODInventory
{
    public abstract class Store
    {
        protected Inventory _inventory;
        public string Location { get; set; }

        public Store(Inventory inventory, string location)
        {
            _inventory = inventory;
            Location = location;
        }

        public abstract void Replenish(int count);

        public int GetInventoryItemsCount()
        {
            return _inventory.Products.Count();
        }

        public int PurchaseProduct(string productName, int requiredQuantity)
        {
            List<Product> products = _inventory.GetProducts(productName, requiredQuantity);
            // Infsufficient amount.
            if (products.Count < requiredQuantity)
            {
                // Calculate the minimum quantity to be imported.
                int difference = requiredQuantity - products.Count;
                int importQuantity = (int)System.Math.Ceiling(((double)difference / 10)) * 10;

                // Import from Other Store.
                Store store = GetTargetStore();
                List<Product> importedItems = ImportFromStore(store, productName, importQuantity);
                List<Product> items = _inventory.GetProducts(productName, difference);
                products.AddRange(items);
            }
            return products.Sum(x => x.GetUnitPrice());
        }

        public abstract Store GetTargetStore();

        public virtual List<Product> ExportProducts(string productName, int quantity)
        {
            List<Product> products = _inventory.GetProducts(productName, quantity);
            if (products.Count() < quantity)
            {
                throw new System.Exception("Out of Stock");
            }
            return products;
        }

        public virtual List<Product> ImportFromStore(Store targetStore, string productName, int minQuantity)
        {
            List<Product> importedItems = new List<Product>();
            List<Product> items = targetStore.ExportProducts(productName, minQuantity);
            foreach (Product item in items)
            {
                Product product = new ImportedIpod(item.GetUnitPrice());
                importedItems.Add(product);
            }
            _inventory.AddProducts(importedItems);
            return importedItems;
        }
    }
}
