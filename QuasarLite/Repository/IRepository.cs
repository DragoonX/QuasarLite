using System.Collections.Generic;
using System.Linq;

namespace QuasarLite.Repository
{
    public interface IRepository<T> where T : class
    {
        List<T> List();
        IQueryable<T> Query();
        T Insert(T entity);
        T Update(T entity);
        T Find(int id);
        bool Delete(int id);
    }
}
