using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL
{
    public class CpuMetricsRepository : SQLiteCommonMetricsRepository
    {
        public CpuMetricsRepository()
        {
            _dbTableName = "cpumetrics";
        }
    }
}
