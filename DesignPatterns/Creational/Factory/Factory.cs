namespace Creational.Factory
{
    public enum PrinterType
    {
        DotMatrix,
        Jet,
        Laser
    }

    public interface IPrinterFactory
    {
        IPrinter CreatePrinter(PrinterType printerType);
    }

    public class Factory : IPrinterFactory
    {
        public IPrinter CreatePrinter(PrinterType printerType)
        {
            switch (printerType)
            {
                case PrinterType.DotMatrix:
                    return new DotMatrixPrinter("Dot Matrix Printer");
                case PrinterType.Jet:
                    return new JetPrinter("Jet Printer");
                case PrinterType.Laser:
                    return new LaserPrinter("Dot Matrix Printer");
                default:
                    return null;
            }
        }
    }
}
