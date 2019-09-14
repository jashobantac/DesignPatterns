using System;
using System.Diagnostics;

using CSharpAndWPF.Common.Extensions;

using log4net;

namespace CSharpAndWPF.AsyncDelegates
{
    public delegate void TimeLogActivityHandler(string info, TimeSpan elapsed);
    public class TimeLogger : IDisposable
    {
        private static readonly ILog _log4Netlogger = LogManager.GetLogger(typeof(TimeLogger));
        private readonly string _info;
        private readonly TimeLogActivityHandler _logger;
        private readonly Stopwatch _watch;

        public TimeLogger(string info, TimeLogActivityHandler logger = null)
        {
            _info = info;
            _logger = logger ?? DefaultLogger;
            _watch = Stopwatch.StartNew();
        }

        private void DefaultLogger(string info, TimeSpan elapsed)
        {
            string infoMessage = string.Format("Method {0} completed in {1}:{2}:{3}:{4}", info, elapsed.Hours, elapsed.Minutes.ToString("D" + 2), elapsed.Seconds.ToString("D" + 2), elapsed.Milliseconds.ToString("D" + 3));
            _log4Netlogger.Info(infoMessage);
            Console.WriteLine(infoMessage);
        }

        public void Dispose()
        {
            _watch.Stop();
            _logger?.SafeInvoke(_info, _watch.Elapsed);
        }
    }
}
