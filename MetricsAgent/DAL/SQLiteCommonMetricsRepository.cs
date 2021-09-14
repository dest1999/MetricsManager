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
        protected string _dbTableName; //cpumetrics
        public SQLiteCommonMetricsRepository()
        {
            //_dbTableName = dbTableName;
        }
        public void Create(BaseMetricValue item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);

            cmd.CommandText = $"INSERT INTO {_dbTableName}(value, time) VALUES(@value, @time)";
            cmd.Parameters.AddWithValue("@value", item.Value);
            cmd.Parameters.AddWithValue("@time", item.Time.ToString("s") );//перед записью привели время в вид YYYY-MM-DDTHH:MM:SS
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = $"DELETE FROM {_dbTableName} WHERE id=@id";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public IList<BaseMetricValue> GetAll()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);

            cmd.CommandText = $"SELECT * FROM {_dbTableName}";

            var returnList = new List<BaseMetricValue>();

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                // пока есть что читать -- читаем
                while (reader.Read())
                {
                    returnList.Add(new BaseMetricValue
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(1),
                        Time = reader.GetDateTime(2)
                    });
                }
            }

            return returnList;
        }

        public BaseMetricValue GetById(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = $"SELECT * FROM {_dbTableName} WHERE id=@id";
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                // если удалось что то прочитать
                if (reader.Read())
                {
                    return new BaseMetricValue
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(1),
                        Time = reader.GetDateTime(2)
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        public void Update(BaseMetricValue item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            using var cmd = new SQLiteCommand(connection);
            // прописываем в команду SQL запрос на обновление данных
            cmd.CommandText = $"UPDATE {_dbTableName} SET value = @value, time = @time WHERE id=@id;";
            cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.Parameters.AddWithValue("@value", item.Value);
            cmd.Parameters.AddWithValue("@time", item.Time );
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}
