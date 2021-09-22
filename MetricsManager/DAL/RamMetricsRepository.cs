namespace MetricsManager.DAL
{
    public class RamMetricsRepository : DBCommonMetricsRepository
    {
        public RamMetricsRepository()
        {
            _collectionName = "ramMetrics";
        }
    }
}
