using ProblemSolving.IPODInventory;

namespace ProblemSolving
{
    public class IPodInventoryDemo : IDemo
    {
        public void Run()
        {
            StoreFactory storeFactory = new StoreFactory();
            Store argentinaStore = storeFactory.GetStore(Constants.ARGENTINA);
            Store brazilStore = storeFactory.GetStore(Constants.BRAZIL);

            Store targetStore = argentinaStore;
            int quantity = 250;
            try
            {
                int amount = targetStore.PurchaseProduct(Constants.IPOD_PRODUCT_NAME, quantity);
                System.Console.WriteLine("Location : " + targetStore.Location);
                System.Console.WriteLine("Quantity :" + quantity);
                System.Console.WriteLine("{0}:{1}:{2}", amount, brazilStore.GetInventoryItemsCount(), argentinaStore.GetInventoryItemsCount());
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
