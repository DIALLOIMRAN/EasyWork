using EasyWork.Business;
using EasyWork.Entities;

namespace EasyWork.Services.Implementations
{
    public class RecruteurServices : GenericService<Recruteur>, IRecruteurServices
    {
        public RecruteurServices(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }

    public interface IRecruteurServices : IGenericService<Recruteur>
    {
        
    }
}
