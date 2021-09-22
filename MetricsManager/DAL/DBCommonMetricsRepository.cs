using LiteDB;
using MetricsManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace MetricsManager.DAL
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

    public abstract class DBCommonMetricsRepository : ICpuMetricsRepository, IDotNetMetricsRepository, IHddMetricsRepository, INetworkMetricsRepository, IRamMetricsRepository
    {
        private const string _dbname = "litedb.db";
        protected string _collectionName;//задаётся в конкретном репозитории
        public void Create(BaseMetricValue item)
        {
            using var db = new LiteDatabase(_dbname);
            var collection = db.GetCollection<BaseMetricValue>(_collectionName);
            collection.Insert(item);
            collection.EnsureIndex(indexId => indexId.AgentId);
            collection.EnsureIndex(indexId => indexId.Time);
            db.Commit();
        }

        public void Delete(int id)
        {
            using var db = new LiteDatabase(_dbname);
            var collection = db.GetCollection<BaseMetricValue>(_collectionName);
            collection.DeleteMany(agent => agent.AgentId == id);
            db.Commit();
        }

        public IList<BaseMetricValue> GetAll()
        {
            using var db = new LiteDatabase(_dbname);
            return db.GetCollection<BaseMetricValue>(_collectionName)
                .FindAll()
                .ToList();
        }

        public IList<BaseMetricValue> GetById(int AgentId)
        {
            using var db = new LiteDatabase(_dbname);
            return db.GetCollection<BaseMetricValue>(_collectionName)
                .Find(agent => agent.AgentId == AgentId)
                .ToList();
        }

        public void Update(BaseMetricValue item)
        {
            throw new System.NotImplementedException();
        }


    }
}
