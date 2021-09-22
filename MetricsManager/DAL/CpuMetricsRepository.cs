namespace MetricsManager.DAL
{
    public class CpuMetricsRepository : DBCommonMetricsRepository
    {
        public CpuMetricsRepository()
        {
            _collectionName = "cpuMetrics";
        }
    }
}
