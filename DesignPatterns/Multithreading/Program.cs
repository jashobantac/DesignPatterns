using System;
using System.Collections.Generic;
using Multithreading.EventWaitHandles;

namespace Multithreading
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //TestThreadState();

            //LockingPractice.LockingExample();
            //MonitorPractice.LockingExample();

            //LockingPractice.LockingBestPractice();

            //LockingPractice.Deadlock();

            /// Below LOC will through a SynchronizationLockException.
            //MonitorPractice.WrongMonitorExample();

            //SynchronizationContextsPractice.RunThreadSafeMethod();
            //Thread.Sleep(4000);
            //SynchronizationContextsPractice.RunThreadUnsafeMethod();

            //SemaphorePractice.TestSemaphore();
            //SemaphorePractice.TestSemaphoreSlim();

            //SignallingConstructs.PrintUsingAutoResetEvent();
            //SignallingConstructs.CallSetBeforeWaitOne();
            //SignallingConstructs.TwoWaySignal();
            SignallingConstructs.CountDownEventDemo();

            WaitForTermination();
        }

        private static void WaitForTermination()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\nProgram Execution Completed. Please press any key to terminate.");
            Console.Read();
        }

        private static void TestThreadState()
        {
            ThreadStatePractice.PrintThreadStates();
        }

        private static void RemoveFromList()
        {
            List<int> _list = new List<int>()
            {
                1,
                2,
                3,
                4,
                5
            };
            int count = _list.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                _list.RemoveAt(i);
            }
            List<int> test = _list;
        }
    }
}