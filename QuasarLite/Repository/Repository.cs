using QuasarLite.DbContexts;
using System.Collections.Generic;
using System.Linq;

namespace QuasarLite.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly XContext _xContext;

        public Repository(XContext xContext)
        {
            _xContext = xContext;
        }

        public bool Delete(int id)
        {
            var result = false;
            var entity = Find(id);

            if (entity != null)
            {
                _xContext.Set<T>().Remove(entity);
                result = true;
            }
            return result;
        }

        public T Find(int id)
        {
            return _xContext.Set<T>().Find(id);
        }

        public T Insert(T entity)
        {
            _xContext.Set<T>().Add(entity);
            return entity;
        }

        public List<T> List()
        {
            return _xContext.Set<T>().ToList();
        }

        public IQueryable<T> Query()
        {
            return _xContext.Set<T>();
        }

        public T Update(T entity)
        {
            _xContext.Set<T>().Update(entity);
            return entity;
        }
    }
}
