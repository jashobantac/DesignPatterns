namespace ProblemSolving.IPODInventory
{
    public class ArgentinaIpodFactory : ProductFactory
    {
        public override Product CreateProduct(string name, int unitPrice)
        {
            if (name == Constants.IPOD_PRODUCT_NAME)
            {
                return new IPod(Constants.IPOD_PRICE_ARGENTINA);
            }
            return new Product(unitPrice) { Name = name };
        }
    }
}
