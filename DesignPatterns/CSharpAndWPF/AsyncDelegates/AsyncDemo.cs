using System;
using System.Threading;

namespace CSharpAndWPF.AsyncDelegates
{
    public class AsyncDemo
    {
        public delegate string AsyncMethodCaller(int callDuration, out int threadId);

        public string TestMethod(int callDuration, out int threadId)
        {
            Console.WriteLine("Test Method Begins.");
            Thread.Sleep(callDuration);
            threadId = Thread.CurrentThread.ManagedThreadId;

            return string.Format("The call time was {0}", callDuration.ToString());
        }
    }
}
