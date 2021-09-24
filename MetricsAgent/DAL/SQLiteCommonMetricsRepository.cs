using Dapper;
using MetricsAgent.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL
{
    public interface ICpuMetricsRepository : IRepository<BaseMetricValue>
    {

    }
    public interface IDotNetMetricsRepository : IRepository<BaseMetricValue>
    {

    }
    public interface IHddMetricsRepository : IRepository<BaseMetricValue>
    {

    }
    public interface INetworkMetricsRepository : IRepository<BaseMetricValue>
    {

    }
    public interface IRamMetricsRepository : IRepository<BaseMetricValue>
    {

    }
    
    public abstract class SQLiteCommonMetricsRepository : ICpuMetricsRepository, IDotNetMetricsRepository, IHddMetricsRepository, INetworkMetricsRepository, IRamMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        //Microsoft.Extensions.Configuration.IConfiguration configuration = ConnectionStrings ;
        protected string _dbTableName; //cpumetrics
        public SQLiteCommonMetricsRepository()
        {
        }
        public void Create(BaseMetricValue item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                connection.Execute($"INSERT INTO {_dbTableName}(value, time) VALUES(@value, @time)", item);
            }
        }

        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Execute($"DELETE FROM {_dbTableName} WHERE id=@{id}");
        }

        public IList<BaseMetricValue> GetAllAndClearValues()
        {
            using var connection = new SQLiteConnection(ConnectionString);

            var returnList = connection.Query<BaseMetricValue>($"SELECT * FROM {_dbTableName}").ToList();
            connection.Execute($"DELETE FROM {_dbTableName} WHERE id>0");
            return returnList;
        }

        public BaseMetricValue GetById(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.QuerySingle<BaseMetricValue>($"SELECT * FROM {_dbTableName} WHERE id=@{id}");
        }

        public void Update(BaseMetricValue item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Execute($"UPDATE {_dbTableName} SET value = @value, time = @time WHERE id=@id;", item);
        }
    }
}
