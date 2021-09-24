using MetricsManager.Models;
using NLog;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace MetricsManager.Client
{
    public class MetricsAgentClient : IMetricsAgentClient<BaseMetricValue>
    {
        private HttpClient _httpClient;
        private ILogger _logger;

        public MetricsAgentClient(HttpClient httpClient, ILogger logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }


        public IList<BaseMetricValue> GetCpuMetrics(AgentInfo agent)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{agent.AgentUri}:5000/api/metrics/cpu/all");       //http://localhost:5000/api/metrics/cpu/all

            try
            {
                HttpResponseMessage httpResponse = _httpClient.SendAsync(httpRequest).Result;
                using var responseStream = httpResponse.Content.ReadAsStreamAsync().Result;
                
                var tmp1 = JsonSerializer.DeserializeAsync<BaseMetricValue>(responseStream).Result;

                var tmp2 = (IList<BaseMetricValue>)tmp1;

                return tmp2;

                //return (IList<BaseMetricValue>)JsonSerializer.DeserializeAsync<BaseMetricValue>(responseStream).Result;



            }
            catch (System.Exception)
            {

                throw;
            }




        }

        public IList<BaseMetricValue> GetDotNetMetrics(AgentInfo agent)
        {
            throw new System.NotImplementedException();
        }

        public IList<BaseMetricValue> GetHddMetrics(AgentInfo agent)
        {
            throw new System.NotImplementedException();
        }

        public IList<BaseMetricValue> GetNetworkMetrics(AgentInfo agent)
        {
            throw new System.NotImplementedException();
        }

        public IList<BaseMetricValue> GetRamMetrics(AgentInfo agent)
        {
            throw new System.NotImplementedException();
        }
    }
}
