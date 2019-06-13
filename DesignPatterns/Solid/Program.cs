using Solid.OpenClosed;

namespace Solid
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IFactory<AlertType, Severity> factory = new DialogFactory();
            IDialog dialog = factory.CreateDialog(AlertType.Warning, Severity.High);
            System.Console.WriteLine(dialog.Title);
            System.Console.WriteLine(dialog.Content);

            System.Console.ReadLine();
        }
    }
}
