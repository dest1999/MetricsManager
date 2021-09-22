namespace MetricsManager.DAL
{
    public class NetworkMetricsRepository : DBCommonMetricsRepository
    {
        public NetworkMetricsRepository()
        {
            _collectionName = "networkMetrics";
        }
    }
}
