using EasyWork.Business.Infrastructure;
using EasyWork.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EasyWork.Business.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        #region Properties
        private EasyWorkContext _context;
        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected EasyWorkContext DataContext
        {
            get { return _context ?? (_context = DbFactory.Init()); }
        }

        #endregion

        #region Constuctor with parametre Context
        public GenericRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }
        #endregion

        #region Implementation methods of interface
        public virtual void Add(TEntity entity)
        {
            var entry = DataContext.Entry(entity);
                entry.State = EntityState.Added;
        }

        public virtual void Delete(TEntity entity)
        {
            var entry = DataContext.Entry(entity);
                entry.State = EntityState.Deleted;
        }

        public virtual void Update(TEntity entity)
        {
            var entry = DataContext.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public virtual TEntity GetById(int id)
        {
            return DataContext.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DataContext.Set<TEntity>().ToList(); 
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return DataContext.Set<TEntity>().Where(predicate);
        }

        public void Save()
        {
            DataContext.SaveChanges();
        }
        #endregion
    }
}
