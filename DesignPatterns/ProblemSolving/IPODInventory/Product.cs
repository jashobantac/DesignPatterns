namespace ProblemSolving.IPODInventory
{
    public class Product
    {
        private int UnitPrice { get; set; }
        public string Name { get; set; }

        #region Constructors.

        public Product(int unitPrice)
        {
            UnitPrice = unitPrice;
        }

        #endregion

        public virtual int GetUnitPrice()
        {
            return UnitPrice;
        }
    }
}
