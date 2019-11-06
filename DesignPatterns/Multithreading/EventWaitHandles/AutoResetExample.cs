using System.Threading;

using Multithreading.Extensions;

namespace Multithreading.EventWaitHandles
{
    public partial class SignallingConstructs
    {
        private static EventWaitHandle _autoResetEvent = new AutoResetEvent(false);
        private static EventWaitHandle _autoResetEvent2 = new EventWaitHandle(false, EventResetMode.AutoReset);
        private static void WaiterMethod()
        {
            ColorConsole.WriteWarning("Waiting for auto-reset event signal. Thread ID :" + Thread.CurrentThread.ManagedThreadId);
            _autoResetEvent.WaitOne();
            ColorConsole.WriteInfo("Done.");
            _autoResetEvent.Close();
        }

        public static void CallSetBeforeWaitOne()
        {
            System.Console.WriteLine("============CALL SET BEFORE WAIT ONE============\n");

            ColorConsole.WriteInfo("An AutoResetEvent is like a ticket turnstile: inserting a ticket lets exactly one person through.");
            ColorConsole.WriteInfo("If set is called before Wait, the handle stays open for as long as it takes until some thread calls WaitOne.");
            System.Console.WriteLine("\n");

            _autoResetEvent.Set();
            ColorConsole.WriteInfo("Signal Received.");
            new Thread(WaiterMethod).Start();
            Thread.Sleep(2000);
            System.Console.WriteLine("Method Completed.");
            _autoResetEvent.Close();
        }

        public static void PrintUsingAutoResetEvent()
        {
            ColorConsole.WriteInfo("An AutoResetEvent is like a ticket turnstile: inserting a ticket lets exactly one person through.");

            new Thread(WaiterMethod).Start();
            Thread.Sleep(2000);
            _autoResetEvent.Set();
            ColorConsole.WriteInfo("Signal Received.");
        }
    }
}
