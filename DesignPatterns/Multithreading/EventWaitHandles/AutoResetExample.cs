using System.Threading;
using Multithreading.Extensions;

namespace Multithreading.EventWaitHandles
{
    public partial class SignallingConstructs
    {
        private static EventWaitHandle _autoResetEvent = new AutoResetEvent(false);

        private static void WaiterMethod()
        {
            ColorConsole.WriteWarning("Waiting for auto-reset event signal. Thread ID :" + Thread.CurrentThread.ManagedThreadId);
            _autoResetEvent.WaitOne();
            ColorConsole.WriteInfo("Done.");
        }

        public static void PrintUsingAutoResetEvent()
        {
            new Thread(WaiterMethod).Start();
            Thread.Sleep(2000);
            _autoResetEvent.Set();
            ColorConsole.WriteInfo("Signal Received.");
        }
    }
}
