using System;

namespace CSharpAndWPF.OOPS
{
    public interface IGate
    {
        void OpenGate();
    }

    public class Gate : IGate
    {
        void IGate.OpenGate()
        {
            Console.WriteLine("Opening Gate.");
        }
    }

    public class Test
    {
        public void TestMethod()
        {
            Gate gate = new Gate();
            IGate gateNew = new Gate();
            gateNew.OpenGate();
        }
    }
}
