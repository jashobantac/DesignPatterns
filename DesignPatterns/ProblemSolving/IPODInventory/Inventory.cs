using System.Collections.Generic;
using System.Linq;

namespace ProblemSolving.IPODInventory
{
    public class Inventory
    {
        #region Public Properties.

        public List<Product> Products { get; private set; }

        #endregion

        #region Constructors.

        public Inventory()
        {
            Products = new List<Product>();
        }

        #endregion

        #region Public Properties.

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void AddProducts(List<Product> products)
        {
            Products.AddRange(products);
        }

        public void RemoveProduct(Product product)
        {
            if (Products.Count > 0 && Products.Contains(product))
            {
                Products.Remove(product);
            }
        }

        public List<Product> GetProducts(string productName, int quantity)
        {
            List<Product> products = Products.Where(x => x.Name == productName).Take(quantity).ToList();
            foreach (Product product in products)
            {
                RemoveProduct(product);
            }
            return products;
        }

        #endregion
    }
}
