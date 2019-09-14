using System.Threading;

namespace Multithreading
{
    public class ThreadStatePractice
    {
        public static void PrintThreadStates()
        {
            Thread th = new Thread(() =>
              {
                  System.Console.WriteLine("Thread has started");
                  Thread.Sleep(5000);
                  System.Console.WriteLine("Thread has completed");
              });
            System.Console.WriteLine("Thread State : " + th.ThreadState.ToString());
            th.Start();
            System.Console.WriteLine("Thread State : " + th.ThreadState.ToString());
            Thread.Sleep(1000);
            System.Console.WriteLine("Thread State : " + th.ThreadState.ToString());
            th.Abort();
            System.Console.WriteLine("Thread State : " + th.ThreadState.ToString());
            Thread.Sleep(2000);
            System.Console.WriteLine("Thread State : " + th.ThreadState.ToString());
        }
    }
}
