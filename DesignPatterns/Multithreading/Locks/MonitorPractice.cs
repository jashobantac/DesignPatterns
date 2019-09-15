using System.Diagnostics;
using System.Threading;

namespace Multithreading
{
    public class MonitorPractice
    {
        private static readonly object _locker = new object();
        private static readonly int _intLocker = 10;

        public static void WrongMonitorExample()
        {
            System.Console.WriteLine("***** Wrong Monitor Example *****");
            Thread th1 = new Thread(WrongLockingUsingMonitor);
            th1.Start();
            System.Console.WriteLine("Thread 1 has started. Thread ID : " + th1.ManagedThreadId);
            Thread th2 = new Thread(WrongLockingUsingMonitor);
            th2.Start();
            System.Console.WriteLine("Thread 2 has started. Thread ID : " + th2.ManagedThreadId);
        }

        public static void LockingExample()
        {
            System.Console.WriteLine("***** Monitor Example *****");
            Thread th1 = new Thread(LockingUsingMonitor);
            th1.Start();
            System.Console.WriteLine("Thread 1 has started. Thread ID : " + th1.ManagedThreadId);
            Thread th2 = new Thread(LockingUsingMonitor);
            th2.Start();
            System.Console.WriteLine("Thread 2 has started. Thread ID : " + th2.ManagedThreadId);
        }

        private static void LockingUsingMonitor()
        {
            Stopwatch stopwatch = new Stopwatch();
            System.Console.WriteLine("Thread Attempt to Enter : " + Thread.CurrentThread.ManagedThreadId);
            stopwatch.Start();

            Monitor.Enter(_locker);
            System.Console.WriteLine("Total time required to acquire MONITOR LOCK by ThreadID : {1}: {0}", stopwatch.ElapsedTicks, Thread.CurrentThread.ManagedThreadId);

            System.Console.WriteLine("Inside the critical section. Thread Id : " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            Monitor.Exit(_locker);
            System.Console.WriteLine("Execution Completed. Thread Id : " + Thread.CurrentThread.ManagedThreadId);
        }

        private static void WrongLockingUsingMonitor()
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                System.Console.WriteLine("Thread Attempt to Enter : " + Thread.CurrentThread.ManagedThreadId);
                stopwatch.Start();

                Monitor.Enter(_intLocker);
                Monitor.Enter(_intLocker);
                Monitor.Enter(_intLocker);
                System.Console.WriteLine("Total time required to acquire MONITOR LOCK by ThreadID : {1}: {0}", stopwatch.ElapsedTicks, Thread.CurrentThread.ManagedThreadId);

                System.Console.WriteLine("Inside the critical section. Thread Id : " + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(2000);
                System.Console.WriteLine("Execution Completed. Thread Id : " + Thread.CurrentThread.ManagedThreadId);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Exception Thrown : " + ex.GetType().FullName);
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
