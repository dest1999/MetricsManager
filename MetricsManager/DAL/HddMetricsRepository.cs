namespace MetricsManager.DAL
{
    public class HddMetricsRepository : DBCommonMetricsRepository
    {
        public HddMetricsRepository()
        {
            _collectionName = "hddMetrics";
        }
    }
}
