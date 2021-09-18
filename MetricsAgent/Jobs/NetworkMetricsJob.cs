using MetricsAgent.DAL;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class NetworkMetricsJob : IJob
    {
        private INetworkMetricsRepository _repository;
        private PerformanceCounter _metricCounter;
        public NetworkMetricsJob(INetworkMetricsRepository repository)
        {
            _repository = repository;
            _metricCounter = new PerformanceCounter("Сетевой интерфейс", "Всего байт/с", "Realtek PCIe GbE Family Controller _2");

        }
        public Task Execute(IJobExecutionContext context)
        {
            _repository.Create(new Models.BaseMetricValue
            {
                Time = DateTime.Now,
                Value = Convert.ToInt32(_metricCounter.NextValue())
            });

            return Task.CompletedTask;
        }
    }
}
