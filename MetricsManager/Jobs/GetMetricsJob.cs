using Quartz;
using System.Threading.Tasks;

namespace MetricsManager.Jobs
{
    public class GetMetricsJob : IJob
    {



        public Task Execute(IJobExecutionContext context)
        {
            //do affairs

            return Task.CompletedTask;
        }
    }
}
