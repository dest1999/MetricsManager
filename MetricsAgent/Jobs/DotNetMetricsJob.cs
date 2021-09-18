using MetricsAgent.DAL;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class DotNetMetricsJob : IJob
    {
        private IDotNetMetricsRepository _repository;
        private PerformanceCounter _metricCounter;
        public DotNetMetricsJob(IDotNetMetricsRepository repository)
        {
            _repository = repository;
            _metricCounter = new PerformanceCounter("ASP.NET", "Error Events Raised");
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
