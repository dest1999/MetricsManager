using MetricsManager.Client;
using MetricsManager.DAL;
using MetricsManager.Models;
using Quartz;
using System.Threading.Tasks;

namespace MetricsManager.Jobs
{
    public class GetMetricsJob : IJob
    {
        private IDBAgentsRepository _dBAgentsRepository;
        private ICpuMetricsRepository _cpuMetricsRepository;
        private IDotNetMetricsRepository _dotNetMetricsRepository;
        private IHddMetricsRepository _hddMetricsRepository;
        private INetworkMetricsRepository _networkMetricsRepository;
        private IRamMetricsRepository _ramMetricsRepository;
        private IMetricsAgentClient<BaseMetricValue> _httpAgentClient;

        public GetMetricsJob(
            IDBAgentsRepository dBAgentsRepository,
            ICpuMetricsRepository cpuMetricsRepository,
            IDotNetMetricsRepository dotNetMetricsRepository,
            IHddMetricsRepository hddMetricsRepository,
            INetworkMetricsRepository networkMetricsRepository,
            IRamMetricsRepository ramMetricsRepository,
            IMetricsAgentClient<BaseMetricValue> httpAgentClient)
        {
            _dBAgentsRepository = dBAgentsRepository;
            _cpuMetricsRepository = cpuMetricsRepository;
            _dotNetMetricsRepository = dotNetMetricsRepository;
            _hddMetricsRepository = hddMetricsRepository;
            _networkMetricsRepository = networkMetricsRepository;
            _ramMetricsRepository = ramMetricsRepository;
            _httpAgentClient = httpAgentClient;
        }

        public Task Execute(IJobExecutionContext context)
        {
            /*
              
            в цикле foreach пробегаем репозиторий с агентами
            извлекаем метрики клиентами, клиент кладёт извлеченную метрику в репозиторий
            
             void GetCpuMetrics()
             
             */

            var agentsCollection = _dBAgentsRepository.GetAll();

            foreach (var agent in agentsCollection)
            {
                _cpuMetricsRepository.CreateSequence(_httpAgentClient.GetCpuMetrics(agent));
                _dotNetMetricsRepository.CreateSequence(_httpAgentClient.GetDotNetMetrics(agent)); //
                _hddMetricsRepository.CreateSequence(_httpAgentClient.GetHddMetrics(agent));
                _networkMetricsRepository.CreateSequence(_httpAgentClient.GetNetworkMetrics(agent));
                _ramMetricsRepository.CreateSequence(_httpAgentClient.GetRamMetrics(agent));



            }


            return Task.CompletedTask;
        }
    }
}
