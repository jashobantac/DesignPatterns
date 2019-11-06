using System.Threading;

namespace Multithreading.EventWaitHandles
{
    public partial class SignallingConstructs
    {
        private static CountdownEvent _countdownEvent = new CountdownEvent(3);

        private static void CountDown()
        {
            System.Console.WriteLine("Inside Count Down. Thread ID : " + Thread.CurrentThread.ManagedThreadId);
            _countdownEvent.Signal();
            System.Console.WriteLine("Done. Thread ID : " + Thread.CurrentThread.ManagedThreadId);
        }

        public static void CountDownEventDemo()
        {
            Thread t1 = new Thread(CountDown);
            Thread t2 = new Thread(CountDown);
            Thread t3 = new Thread(CountDown);
            Thread t4 = new Thread(CountDown);
            Thread t5 = new Thread(CountDown);

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();

            _countdownEvent.Wait();
        }
    }
}
