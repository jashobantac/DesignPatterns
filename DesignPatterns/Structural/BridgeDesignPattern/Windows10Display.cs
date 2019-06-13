namespace Structural.BridgeDesignPattern
{
    public class Windows10Display : DisplayApp
    {
        public Windows10Display(IBridgeFormatter bridgeFormatter, string text) : base(bridgeFormatter)
        {
            Text = text;
        }

        public override void Display()
        {
            _bridgeFormatter.Display(" Windows10 Display: " + Text);
        }
    }
}
