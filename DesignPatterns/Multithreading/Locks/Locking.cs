using System.Diagnostics;
using System.Threading;

namespace Multithreading
{
    public class LockingPractice
    {
        private static readonly object _locker1 = new object();
        private static readonly object _locker2 = new object();
        private static bool _isInitialized = false;
        private static readonly object _initLocker = new object();

        public static void Deadlock()
        {
            Thread th1 = new Thread(DeadlockMethod1);
            Thread th2 = new Thread(DeadlockMethod2);
            th1.Start();
            System.Console.WriteLine("Thread 1 Started. Thread Id : " + th1.ManagedThreadId);
            th2.Start();
            System.Console.WriteLine("Thread 2 Started. Thread Id : " + th2.ManagedThreadId);
        }

        private static void DeadlockMethod2()
        {
            System.Console.WriteLine("Attempting to lock locker 2. Thread Id : " + Thread.CurrentThread.ManagedThreadId);
            lock (_locker2)
            {
                System.Console.WriteLine("Locker 2 Locked by ThreadId : " + Thread.CurrentThread.ManagedThreadId);

                Thread.Sleep(2000);
                System.Console.WriteLine("Waiting for Locker 1 to be released. Thread Id : " + Thread.CurrentThread.ManagedThreadId);
                lock (_locker1)
                {
                    System.Console.WriteLine("Locker 1 Locked.");
                }
            }
        }

        private static void DeadlockMethod1()
        {
            System.Console.WriteLine("Attempting to lock locker 1. Thread Id : " + Thread.CurrentThread.ManagedThreadId);
            lock (_locker1)
            {
                System.Console.WriteLine("Locker 1 Locked by ThreadId : " + Thread.CurrentThread.ManagedThreadId);

                Thread.Sleep(2000);
                System.Console.WriteLine("Waiting for Locker 2 to be released. Thread Id : " + Thread.CurrentThread.ManagedThreadId);
                lock (_locker2)
                {
                    System.Console.WriteLine("Locker 2 Locked.");
                }
            }
        }

        public static void LockingBestPractice()
        {
            System.Console.WriteLine("***** Locking Best Practice Example *****");

            Thread th1 = new Thread(LockingInitialize);
            th1.Start();
            System.Console.WriteLine("Thread 1 has started. Thread ID : " + th1.ManagedThreadId);
            Thread th2 = new Thread(LockingInitialize);
            th2.Start();
            System.Console.WriteLine("Thread 2 has started. Thread ID : " + th2.ManagedThreadId);
            Thread th3 = new Thread(LockingInitialize);
            th3.Start();
            System.Console.WriteLine("Thread 3 has started. Thread ID : " + th3.ManagedThreadId);
        }

        private static void LockingInitialize()
        {
            if (!_isInitialized)
            {
                lock (_initLocker)
                {
                    //InitializeTest();
                    //_isInitialized = true;

                    // Without the extra lock statement, initialization will happen multiple times.
                    if (!_isInitialized)
                    {
                        InitializeTest();
                        _isInitialized = true;
                    }
                }
            }
            System.Console.WriteLine("Execution completed : " + Thread.CurrentThread.ManagedThreadId);
        }

        private static void InitializeTest()
        {
            System.Console.WriteLine("Initializing.");
            Thread.Sleep(3000);
            System.Console.WriteLine("Initialized.");
        }

        public static void LockingExample()
        {
            System.Console.WriteLine("***** Lock Example *****");

            Thread th1 = new Thread(Locking);
            th1.Start();
            System.Console.WriteLine("Thread 1 has started. Thread ID : " + th1.ManagedThreadId);
            Thread th2 = new Thread(Locking);
            th2.Start();
            System.Console.WriteLine("Thread 2 has started. Thread ID : " + th2.ManagedThreadId);
        }

        private static void Locking()
        {
            Stopwatch stopwatch = new Stopwatch();
            System.Console.WriteLine("Thread Attempt to Enter : " + Thread.CurrentThread.ManagedThreadId);
            stopwatch.Start();
            lock (_locker1)
            {
                System.Console.WriteLine("Total time required to acquire LOCK by ThreadID : {1}: {0}", stopwatch.ElapsedTicks, Thread.CurrentThread.ManagedThreadId);
                stopwatch.Stop();
                System.Console.WriteLine("Inside the critical section. Thread Id : " + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(2000);
            }
            System.Console.WriteLine("Execution Completed. Thread Id : " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}