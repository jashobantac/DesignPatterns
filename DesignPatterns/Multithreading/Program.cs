using System;
using System.Collections.Generic;
using System.Threading;

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

            SynchronizationContextsPractice.RunThreadSafeMethod();
            Thread.Sleep(4000);
            SynchronizationContextsPractice.RunThreadUnsafeMethod();

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