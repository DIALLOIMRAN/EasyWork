using EasyWork.Business.Infrastructure;
using EasyWork.Business.Repositories;
using EasyWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyWork.Business
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private EasyWorkContext dataContext = null;
        private readonly IDbFactory dbFactory;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public EasyWorkContext DataContext
        {
            get { return dataContext ?? (dataContext = dbFactory.Init()); }
        }

        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (GetKeys().Contains(typeof(TEntity)) == true)
            {
                return repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
            }
            IGenericRepository<TEntity> repository = new GenericRepository<TEntity>(dbFactory);
            repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        private Dictionary<Type, object>.KeyCollection GetKeys()
        {
            return repositories.Keys;
        }

        public void Commit()
        {
            dataContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dataContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
