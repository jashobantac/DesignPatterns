using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsUnitTest
{
    [TestClass]
    public class GenericTest
    {
        [TestMethod]
        public void TestConnectionToRemoteMachine()
        {
            Thread t = new Thread(() =>
            {
                Thread.Sleep(5000);
            });
            t.Start();
        }
    }
}
