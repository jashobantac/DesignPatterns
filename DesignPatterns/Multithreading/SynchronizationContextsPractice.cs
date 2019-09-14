using System;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using Multithreading.Extensions;

namespace Multithreading
{
    public class Deadlock
    {
        public Deadlock Other { get; set; }

        public void Demo()
        {
            ColorConsole.WriteInfo("Inside method DEMO. Thread ID : " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            Console.WriteLine("Thread execution completed.");
        }

        public void Print()
        {
            Console.WriteLine("Inside Print Method.");
        }
    }

    /// <summary>
    /// Creates a Thread Safe SafeInstance Object of <see langword="thread safe " cref="AutoLock"/>
    /// </summary>
    [Synchronization]
    public class AutoLock : ContextBoundObject
    {
        public void ThreadSafeMethod()
        {
            Console.WriteLine("Synchronization Context : " + SynchronizationContext.Current.());
            Console.WriteLine("Started. Thread ID : " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            Console.WriteLine("Terminated : Thread ID : " + Thread.CurrentThread.ManagedThreadId);
        }
    }

    public class NoAutoLock : ContextBoundObject
    {
        public static void ThreadUnSafeMethod()
        {
            Console.WriteLine("Started. Thread ID : " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            Console.WriteLine("Terminated : Thread ID : " + Thread.CurrentThread.ManagedThreadId);
        }
    }

    public class SynchronizationContextsPractice
    {
        static SynchronizationContextsPractice()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string info = "A ContextBoundObject can be thought of as a “remote” object, meaning all method calls are intercepted. " +
                "\nTo make this interception possible, when we instantiate AutoLock, the CLR actually returns a proxy — an object with the same methods and properties of an AutoLock object, which acts as an intermediary. It's via this intermediary that the automatic locking takes place. Overall, the interception adds around a microsecond to each method call.";
            ColorConsole.WriteInfo(info);
        }
        public static void RunThreadSafeMethod()
        {
            Console.WriteLine();
            AutoLock autoLock = new AutoLock();
            Console.WriteLine("Running Thread Safe Method.");
            Thread th1 = new Thread(autoLock.ThreadSafeMethod);
            Thread th2 = new Thread(autoLock.ThreadSafeMethod);
            Thread th3 = new Thread(autoLock.ThreadSafeMethod);
            th1.Start();
            th2.Start();
            th3.Start();
        }

        public static void RunThreadUnsafeMethod()
        {
            Console.WriteLine();
            ColorConsole.WriteException("Running Thread UnSafe Method.");
            Thread th1 = new Thread(NoAutoLock.ThreadUnSafeMethod);
            Thread th2 = new Thread(NoAutoLock.ThreadUnSafeMethod);
            Thread th3 = new Thread(NoAutoLock.ThreadUnSafeMethod);
            th1.Start();
            th2.Start();
            th3.Start();
        }
    }
}
