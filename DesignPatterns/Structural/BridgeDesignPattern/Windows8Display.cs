namespace Structural.BridgeDesignPattern
{
    public class Windows8Display : DisplayApp
    {
        public Windows8Display(IBridgeFormatter bridgeFormatter, string text) : base(bridgeFormatter)
        {
            Text = text;
        }

        public override void Display()
        {
            _bridgeFormatter.Display(" Windows8 Display: " + Text);
        }
    }
}
