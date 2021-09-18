using MetricsAgent.DAL;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class CpuMetricsJob : IJob
    {
        private ICpuMetricsRepository _repository;
        private PerformanceCounter _metricCounter;
        public CpuMetricsJob(ICpuMetricsRepository repository)
        {
            _repository = repository;
            _metricCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
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
