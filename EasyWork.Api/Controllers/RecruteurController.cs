using EasyWork.Business.Repositories;
using EasyWork.Entities;
using EasyWork.Business;

namespace EasyWork.Controllers
{
    public class RecruteurController : ApiControllerBase
    {
        private readonly IGenericRepository<Recruteur> _recruteursRepository;

        public RecruteurController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _recruteursRepository = _unitOfWork.GetRepository<Recruteur>() ;
        }
    }
}
