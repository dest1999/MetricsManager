using LiteDB;
using MetricsManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace MetricsManager.DAL
{
    public interface IDBAgentsRepository : IRepository<AgentInfo> { }
    public class DBAgentsRepository : IDBAgentsRepository
    {
        private const string _dbname = "litedb.db";
        private const string _collectionName = "Agents";
        public void Create(AgentInfo agent)
        {
            using var db = new LiteDatabase(_dbname);
            var collection = db.GetCollection<AgentInfo>(_collectionName);
            collection.Insert(agent);
            collection.EnsureIndex(indexId => indexId.AgentId, true);
            db.Commit();
        }

        public void CreateSequence(IList<AgentInfo> item)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            using var db = new LiteDatabase(_dbname);
            var collection = db.GetCollection<AgentInfo>(_collectionName);
            collection.DeleteMany(agent => agent.AgentId == id);
            db.Commit();
        }

        public IList<AgentInfo> GetAll()
        {
            using var db = new LiteDatabase(_dbname);
            return db.GetCollection<AgentInfo>(_collectionName)
                .FindAll()
                .ToList();
        }

        public AgentInfo GetById(int id)
        {
            using var db = new LiteDatabase(_dbname);
            return db.GetCollection<AgentInfo>(_collectionName)
                .FindOne(agent => agent.AgentId == id);
        }

        public void Update(AgentInfo item)
        {
            throw new System.NotImplementedException();
        }
    }
}
