using EasyWork.Business.Repositories;
using EasyWork.Entities;
using EasyWork.Business;
using System.Net.Http;
using System.Net;
using EasyWork.Models;
using AutoMapper;
using System.Web.Http;
using System.Collections.Generic;

namespace EasyWork.Controllers
{
    public class RecruteurController : ApiControllerBase
    {
        private readonly IGenericRepository<Recruteur> _recruteursRepository;

        public RecruteurController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _recruteursRepository = _unitOfWork.GetRepository<Recruteur>() ;
        }

        // GET: api/Recruteur
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var candidats = Mapper.Map<IEnumerable<RecruteurViewModel>>(_recruteursRepository.GetAll());
                return request.CreateResponse(HttpStatusCode.OK, candidats);
            });
        }

        // GET: api/Recruteur/1
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var Recruteur = _recruteursRepository.GetById(id);
                if (Recruteur != null)
                {
                    return request.CreateResponse(HttpStatusCode.OK, Mapper.Map<RecruteurViewModel>(Recruteur));
                }
                return request.CreateErrorResponse(HttpStatusCode.NoContent, "Pas de Recruteur pour cette requete !");
            });
        }

        // POST: api/Recruteur
        [HttpPost]
        public HttpResponseMessage Post(HttpRequestMessage request, RecruteurViewModel model)
        {
            return CreateHttpResponse(request, () =>
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                var Recruteur = MakeModel(model);
                _recruteursRepository.Add(Recruteur);
                _unitOfWork.Commit();


                return request.CreateResponse(HttpStatusCode.Created, Mapper.Map<RecruteurViewModel>(Recruteur));
            });
        }

        // PUT: api/Recruteur/1
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage request, int id, RecruteurViewModel model)
        {
            return CreateHttpResponse(request, () =>
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                var Recruteur = _recruteursRepository.GetById(id);
                if (Recruteur != null)
                {
                    model.Id = id;
                    Recruteur = MakeModel(model);

                    _recruteursRepository.Update(Recruteur);
                    _unitOfWork.Commit();

                    return request.CreateResponse(HttpStatusCode.OK, Mapper.Map<RecruteurViewModel>(Recruteur));
                }
                return request.CreateErrorResponse(HttpStatusCode.NoContent, "Pas de Recruteur pour cette requete !");
            });
        }

        // DELETE: api/Recruteur/1
        [HttpPut]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                var Recruteur = _recruteursRepository.GetById(id);
                if (Recruteur != null)
                {
                    _recruteursRepository.Delete(Recruteur);
                    _unitOfWork.Commit();

                    return request.CreateResponse(HttpStatusCode.OK, Mapper.Map<RecruteurViewModel>(Recruteur));
                }

                return request.CreateErrorResponse(HttpStatusCode.NoContent, "Pas de Recruteur pour cette requete !");
            });
        }

        // Helpers methods
        private Recruteur MakeModel(RecruteurViewModel vm)
        {
            return new Recruteur
            {
                Adresse = vm.Adresse,
                Civilite = vm.Civilite,
                Email = vm.Email,
                Id = vm.Id,
                Poste = vm.Poste,
                Nom = vm.Nom,
                Password = vm.Password,
                Prenom = vm.Prenom,
                RefVille = vm.RefVille,
                Telephone = vm.Telephone
            };
        }
    }
}
