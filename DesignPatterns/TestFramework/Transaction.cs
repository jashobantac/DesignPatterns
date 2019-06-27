using System;
using System.Collections.Generic;

namespace TestFramework
{
    public class Transaction
    {
        public string Name { get; set; }
        public string TransactionLine { get; set; }
        public int TransactionId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public List<Event> Events { get; set; }
        public double LineNumber { get; set; }

        public double GetElapsedTime()
        {
            if (StartTime != null && EndTime != null)
            {
                return (EndTime.Value - StartTime.Value).Seconds;
            }
            return -1;
        }

        public override string ToString()
        {
            if (StartTime != null || EndTime != null)
            {
                return string.Format("{0} {1} Start : {2} End :{3} Elapsed : {4} secs.",
                    TransactionId,
                    Name,
                    StartTime.Value.ToString("yyyy-MM-dd HH:mm:ss,fff"),
                    EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss,fff"),
                    GetElapsedTime());
            }
            return base.ToString();
        }
    }

    public class Event
    {
        public string Name { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public double GetElapsedTime()
        {
            if (StartTime != null && EndTime != null)
            {
                return (EndTime.Value - StartTime.Value).TotalMilliseconds;
            }
            return -1;
        }
    }
}
