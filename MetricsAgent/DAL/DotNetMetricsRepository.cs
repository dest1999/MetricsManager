using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL
{
    public class DotNetMetricsRepository : SQLiteCommonMetricsRepository
    {
        public DotNetMetricsRepository()
        {
            _dbTableName = "dotnetmetrics";
        }
    }
}
