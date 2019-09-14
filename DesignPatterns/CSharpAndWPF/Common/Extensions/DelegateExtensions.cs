using System;
using System.Linq;
using System.Collections.Generic;

namespace CSharpAndWPF.Common.Extensions
{
    public static class DelegateExtensions
    {
        public static void SafeInvoke(this Delegate del, params object[] args)
        {
            List<Exception> exceptions = new List<Exception>();
            foreach (Delegate handler in del.GetInvocationList())
            {
                try
                {
                    handler.Method.Invoke(handler.Target, args);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
