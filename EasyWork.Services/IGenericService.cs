using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EasyWork.Services
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void SaveChanges();
        IList<TEntity> getAll();
        TEntity GetById(int id);
        IList<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate);
    }
}
