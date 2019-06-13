namespace Structural.BridgeDesignPattern
{
    public abstract class DisplayApp
    {
        public readonly IBridgeFormatter _bridgeFormatter;
        public DisplayApp(IBridgeFormatter bridgeFormatter)
        {
            _bridgeFormatter = bridgeFormatter;
        }

        public string Text { get; set; } = string.Empty;
        public abstract void Display();
    }
}
