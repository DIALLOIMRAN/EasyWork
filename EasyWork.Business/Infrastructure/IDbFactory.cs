using EasyWork.Data;
using System;

namespace EasyWork.Business.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        EasyWorkContext Init();
    }
}
