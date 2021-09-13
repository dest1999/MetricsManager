using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Models
{
    public class BaseMetricValue
    {
        public int? Id { get; set; }
        public int Value { get; set; }
        public DateTime Time { get; set; }
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
