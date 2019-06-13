namespace ProblemSolving.IPODInventory
{
    /// <summary>
    /// Decorator for Imported IPod.
    /// </summary>
    public class ImportedIpod : IPod
    {
        public ImportedIpod(int unitPrice) : base(unitPrice)
        {
        }

        public override int GetUnitPrice()
        {
            return base.GetUnitPrice() + Constants.SHIPPING_COST_PER_TEN_UNITS / 10;
        }
    }
}
