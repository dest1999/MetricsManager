using CommonClassesLibrary;
using System;

namespace MetricsManager.Models
{
    public class BaseMetricValue : BaseMetricDTO
    {
        public int? AgentId { get; set; }
        public int Value { get; set; }
        public DateTime Time { get; set; }
        public BaseMetricValue()
        {
        }
        public BaseMetricValue(int clientId, int value, DateTime dateTime)
        {
            AgentId = clientId;
            Value = value;
            Time = dateTime;
        }
    }
}
