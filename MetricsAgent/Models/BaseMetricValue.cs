using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Models
{
    public class BaseMetricValue
    {
        public int Value { get; }
        public DateTime Time { get; }
        public BaseMetricValue()
        {
        }
        public BaseMetricValue(int value, DateTime dateTime)
        {
            Value = value;
            Time = dateTime;
        }
    }
}
