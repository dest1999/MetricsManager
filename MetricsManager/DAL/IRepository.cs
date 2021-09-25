using System.Collections.Generic;

namespace MetricsManager.DAL
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetAll();
        void Create(T item);
        void CreateSequence(IList<T> item);
        void Update(T item);
        void Delete(int id);
    }
}
