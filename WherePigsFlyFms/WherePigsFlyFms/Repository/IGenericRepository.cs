using System;
using System.Collections.Generic;

namespace WherePigsFlyFms.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Dispose();
        IEnumerable<TEntity> FindMany(Func<TEntity, bool> predicate);
        TEntity FindSingle(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> GetAll();
        TEntity Update(int id, TEntity entity);
    }
}