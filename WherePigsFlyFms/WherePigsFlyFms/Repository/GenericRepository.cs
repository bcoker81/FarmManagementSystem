using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WherePigsFlyFms.Data;

namespace WherePigsFlyFms.Repository
{
    public class GenericRepository<TEntity> : IDisposable, IGenericRepository<TEntity> where TEntity : class
    {
        private FmsDbContext _context;

        public GenericRepository(FmsDbContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public TEntity FindSingle(Func<TEntity, bool> predicate)
        {
           return _context.Set<TEntity>().Where(predicate).SingleOrDefault();
        }

        public IEnumerable<TEntity> FindMany(Func<TEntity, bool> predicate)
        {
           return _context.Set<TEntity>().Where(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity Update(int id, TEntity entity)
        {
            var result = _context.Set<TEntity>().Find(id);
            _context.Entry(result).CurrentValues.SetValues(entity);
            return result;
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}