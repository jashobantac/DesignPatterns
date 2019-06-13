namespace ProblemSolving.IPODInventory
{
    public class IPod : Product
    {
        public IPod(int unitPrice) : base(unitPrice)
        {
            Name = Constants.IPOD_PRODUCT_NAME;
        }
    }
}
