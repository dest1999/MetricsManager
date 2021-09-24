using MetricsManager.Models;
using System.Collections.Generic;

namespace MetricsManager.Client
{
    public interface IMetricsAgentClient<T> where T : BaseMetricValue
    {
        IList<T> GetCpuMetrics(AgentInfo agent);
        IList<T> GetDotNetMetrics(AgentInfo agent);
        IList<T> GetHddMetrics(AgentInfo agent);
        IList<T> GetNetworkMetrics(AgentInfo agent);
        IList<T> GetRamMetrics(AgentInfo agent);
    }
}
