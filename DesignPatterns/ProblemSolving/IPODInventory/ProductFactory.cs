namespace ProblemSolving.IPODInventory
{
    public abstract class ProductFactory
    {
        public abstract Product CreateProduct(string name, int unitPrice);
    }
}
