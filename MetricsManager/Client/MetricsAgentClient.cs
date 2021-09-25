using CommonClassesLibrary;
using MetricsManager.Models;
using Microsoft.Extensions.Logging;
using NLog;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace MetricsManager.Client
{
    public class MetricsAgentClient : IMetricsAgentClient<BaseMetricValue>
    {
        private HttpClient _httpClient;
        private ILogger<MetricsAgentClient> _logger;

        public MetricsAgentClient(HttpClient httpClient, ILogger<MetricsAgentClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }


        private IList<BaseMetricValue> CommonMetricsGetter(AgentInfo agent, HttpRequestMessage httpRequest)
        {
            HttpResponseMessage httpResponse = _httpClient.SendAsync(httpRequest).Result;

            try
            {
                using var responseStream = httpResponse.Content.ReadAsStreamAsync().Result;

                var metricsCollection = JsonSerializer.DeserializeAsync<List<BaseMetricValue>>(responseStream, new JsonSerializerOptions(JsonSerializerDefaults.Web)).Result;

                foreach (var item in metricsCollection)
                {
                    item.AgentId = agent.AgentId;
                }

                return metricsCollection;

            }
            catch (System.Exception)
            {

                throw;
            }
        }


        public IList<BaseMetricValue> GetCpuMetrics(AgentInfo agent)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{agent.AgentUri}api/metrics/cpu/all");       //http://localhost:5000/api/metrics/cpu/all

            return CommonMetricsGetter(agent, httpRequest);

        }

        public IList<BaseMetricValue> GetDotNetMetrics(AgentInfo agent)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{agent.AgentUri}api/metrics/dotnet/errors-count/all");

            return CommonMetricsGetter(agent, httpRequest);
        }

        public IList<BaseMetricValue> GetHddMetrics(AgentInfo agent)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{agent.AgentUri}api/metrics/hdd/left/all");

            return CommonMetricsGetter(agent, httpRequest);
        }

        public IList<BaseMetricValue> GetNetworkMetrics(AgentInfo agent)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{agent.AgentUri}api/metrics/network/all");

            return CommonMetricsGetter(agent, httpRequest);
        }

        public IList<BaseMetricValue> GetRamMetrics(AgentInfo agent)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{agent.AgentUri}api/metrics/ram/available/all");

            return CommonMetricsGetter(agent, httpRequest);
        }
    }
}
