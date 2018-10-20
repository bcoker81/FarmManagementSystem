using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WherePigsFlyFms.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Dispose();
        TEntity FindSingle(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> FindMany(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
        TEntity Update(int id, TEntity entity);
    }
}