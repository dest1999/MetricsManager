namespace MetricsManager.DAL
{
    public class DotNetMetricsRepository : DBCommonMetricsRepository
    {
        public DotNetMetricsRepository()
        {
            _collectionName = "dotnetMetrics";
        }
    }
}
