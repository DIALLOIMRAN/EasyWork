using EasyWork.Business;
using EasyWork.Entities;

namespace EasyWork.Services.Implementations
{
    public class CandidatServices : GenericService<Candidat>, ICandidatServices
    {
        public CandidatServices(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }

    public interface ICandidatServices : IGenericService<Candidat>
    {
        
    }
}
