using System.Threading;
using Multithreading.Extensions;

namespace Multithreading.EventWaitHandles
{
    public partial class SignallingConstructs
    {
        private static EventWaitHandle _ready = new AutoResetEvent(false);
        private static EventWaitHandle _go = new AutoResetEvent(false);
        private static readonly object _locker = new object();

        private static bool _isDone = false;

        public static void TwoWaySignal()
        {
            ColorConsole.WriteInfo("Two Way Signal DEMO.");
            Thread th = new Thread(DoWork);
            th.Start();

            System.Console.WriteLine("Ready Wait One.");
            _ready.WaitOne();
            System.Console.WriteLine("Ready Signal Received.");

            System.Console.WriteLine("Go Set.");
            _go.Set();

            lock (_locker)
            {
                _isDone = true;
            }
        }

        private static void DoWork()
        {
            while (true)
            {
                System.Console.WriteLine("Ready Set.");
                _ready.Set();

                System.Console.WriteLine("Go Wait One.");
                _go.WaitOne();
                System.Console.WriteLine("Go Signal Received.");

                lock (_locker)
                {
                    if (_isDone)
                    {
                        System.Console.WriteLine("Done.");
                        _go.Close();
                        _ready.Close();
                        break;
                    }
                }
            }
        }
    }
}
