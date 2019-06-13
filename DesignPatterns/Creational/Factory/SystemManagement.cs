using System.Collections.Generic;

namespace Creational.Factory
{
    public interface ISystemManagement
    {
        void ConfigurePrinters();
    }

    public class SystemManagement : ISystemManagement
    {
        private readonly IPrinterFactory _printerFactory;
        private readonly List<IPrinter> _printers;

        #region Constructor

        public SystemManagement(IPrinterFactory printerFactory)
        {
            _printers = new List<IPrinter>();
            _printerFactory = printerFactory;
            ConfigurePrinters();
        }

        #endregion

        #region ISystemManagement Interface Implementation.

        public void ConfigurePrinters()
        {
            IPrinter laserPrinter = _printerFactory.CreatePrinter(PrinterType.Laser);
            laserPrinter.Configure();
            if (laserPrinter != null)
            {
                _printers.Add(laserPrinter);
            }
        }

        #endregion
    }
}
