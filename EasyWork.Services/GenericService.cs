using EasyWork.Business;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyWork.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        public GenericService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(TEntity entity)
        {
            _unitOfWork.GetRepository<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            _unitOfWork.GetRepository<TEntity>().Update(entity);
        }
        public void Remove(TEntity entity)
        {
            _unitOfWork.GetRepository<TEntity>().Delete(entity);
        }
        public IList<TEntity> getAll()
        {
            return _unitOfWork.GetRepository<TEntity>().GetAll().ToList();
        }
        public TEntity GetById(int id)
        {
            return _unitOfWork.GetRepository<TEntity>().GetById(id);
        }
        public IList<TEntity> GetBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _unitOfWork.GetRepository<TEntity>().FindBy(predicate).ToList();
        }
        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
        
    }
}
