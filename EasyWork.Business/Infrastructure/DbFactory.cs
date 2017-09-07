using EasyWork.Data;

namespace EasyWork.Business.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        EasyWorkContext dbContext;

        public EasyWorkContext Init()
        {
            return dbContext ?? (dbContext = new EasyWorkContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
