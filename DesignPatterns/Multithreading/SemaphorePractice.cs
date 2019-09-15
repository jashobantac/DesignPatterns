using System;
using System.Threading;

using Multithreading.Extensions;

namespace Multithreading
{
    public class SemaphorePractice
    {
        private static readonly Semaphore _semaphore = new Semaphore(1, 3);
        private static readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(3);

        public static void PrintSemaphoreSlim()
        {
            Console.WriteLine("Attempt to enter Print Semaphore. ThreadID : " + Thread.CurrentThread.ManagedThreadId);
            _semaphoreSlim.Wait();
            Console.WriteLine("Inside Print Semaphore. ThreadID : " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            Console.WriteLine("Done. ThreadID : " + Thread.CurrentThread.ManagedThreadId);
            _semaphoreSlim.Release();
        }

        public static void TestSemaphoreSlim()
        {
            ColorConsole.WriteInfo("", "SEMAPHORE SLIM PRACTICE");

            Thread t1 = new Thread(PrintSemaphoreSlim);
            t1.Start();
            Thread t2 = new Thread(PrintSemaphoreSlim);
            t2.Start();
            Thread t3 = new Thread(PrintSemaphoreSlim);
            t3.Start();
            Thread t4 = new Thread(PrintSemaphoreSlim);
            t4.Start();
        }

        private static void PrintSemaphore()
        {
            Console.WriteLine("Attempt to enter Print Semaphore. ThreadID : " + Thread.CurrentThread.ManagedThreadId);
            _semaphore.WaitOne();
            Console.WriteLine("Inside Print Semaphore. ThreadID : " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            Console.WriteLine("Done. ThreadID : " + Thread.CurrentThread.ManagedThreadId);
            _semaphore.Release();
        }

        public static void TestSemaphore()
        {
            ColorConsole.WriteInfo("", "SEMAPHORE PRACTICE");

            Thread t1 = new Thread(PrintSemaphore);
            t1.Start();
            Thread t2 = new Thread(PrintSemaphore);
            t2.Start();
            Thread t3 = new Thread(PrintSemaphore);
            t3.Start();
            Thread t4 = new Thread(PrintSemaphore);
            t4.Start();
        }
    }
}
