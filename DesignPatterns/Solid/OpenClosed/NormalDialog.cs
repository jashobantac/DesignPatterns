namespace Solid.OpenClosed
{
    public interface IDialog
    {
        string Title { get; set; }
        string Content { get; set; }
    }

    public class NormalDialog : IDialog
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public NormalDialog()
        {
            Title = "This is a normal dialog.";
            Content = "This is a normal content.";
        }
    }

    public class MessageBox : IDialog
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public MessageBox()
        {
            Title = "This is a Message Box.";
            Content = "This is a Message Box content.";
        }
    }

    public class BlinkingDialog : IDialog
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public BlinkingDialog()
        {
            Title = "This is a Blinking Dialog.";
            Content = "This is a Blinking Dialog content.";
        }
    }
}
