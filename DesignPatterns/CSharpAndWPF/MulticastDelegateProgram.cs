using System;
using CSharpAndWPF.Common.Extensions;

namespace CSharpAndWPF
{
    public delegate void MulticastDelegateEventHandler(object sender);
    public class MulticastDelegateProgram
    {
        public event MulticastDelegateEventHandler OnMulticastEventOccurred;

        public MulticastDelegateProgram()
        {
            OnMulticastEventOccurred += OnMulticastDelegateExecuted1;
            OnMulticastEventOccurred += OnMulticastDelegateExecuted3;
            OnMulticastEventOccurred += OnMulticastDelegateExecuted2;

            Execute();
        }

        public void Execute()
        {
            OnMulticastEventOccurred?.SafeInvoke(this);
        }

        private void OnMulticastDelegateExecuted1(object sender)
        {
            Console.WriteLine(sender.ToString());
        }

        private void OnMulticastDelegateExecuted2(object sender)
        {
            Console.WriteLine(DateTime.Now);
        }

        private void OnMulticastDelegateExecuted3(object sender)
        {
            throw new ArgumentException("This method throws exception.");
        }
    }
}
