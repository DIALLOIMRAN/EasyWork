namespace EasyWork.Business
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// 
        /// </summary>
        void Commit();

        /// <summary>
        /// 
        /// </summary>
        void Dispose();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Repositories.IGenericRepository<T> GetRepository<T>() where T : class;
        // AuthRepository getAuthRepository();
    }
}
