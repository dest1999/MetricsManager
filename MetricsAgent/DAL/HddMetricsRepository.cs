using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL
{
    public class HddMetricsRepository : SQLiteCommonMetricsRepository
    {
        public HddMetricsRepository()
        {
            _dbTableName = "hddmetrics";
        }
    }
}
