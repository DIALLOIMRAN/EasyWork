using System.Web.Http;
using System.Net.Http;
using System.Net;
using System;
using EasyWork.Entities;
using EasyWork.Business;
using EasyWork.Business.Repositories;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using EasyWork.Models;

namespace EasyWork.Controllers
{
    public class CandidatController : ApiControllerBase
    {
        private readonly IGenericRepository<Candidat> _candidatsRepository;
        
        public CandidatController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _candidatsRepository = _unitOfWork.GetRepository<Candidat>();
        }

        // GET: api/Candidat
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var candidats = Mapper.Map<IEnumerable<CandidatViewModel>>(_candidatsRepository.GetAll());
                return request.CreateResponse(HttpStatusCode.OK, candidats);
            });
        }

        // GET: api/Candidat/1
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var candidat = _candidatsRepository.GetById(id);
                if (candidat != null)
                {
                    return request.CreateResponse(HttpStatusCode.OK, Mapper.Map<CandidatViewModel>(candidat));
                }
                return request.CreateErrorResponse(HttpStatusCode.NoContent, "Pas de candidat pour cette requete !");
            });
        }

        // POST: api/Candidat
        [HttpPost]
        public HttpResponseMessage Post(HttpRequestMessage request, CandidatViewModel model)
        {
            return CreateHttpResponse(request, () =>
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                var candidat = MakeModel(model);
                _candidatsRepository.Add(candidat);
                _unitOfWork.Commit();


                return request.CreateResponse(HttpStatusCode.Created, Mapper.Map<CandidatViewModel>(candidat));
            });
        }

        // PUT: api/Candidat/1
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage request, int id, CandidatViewModel model)
        {
            return CreateHttpResponse(request, () =>
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                
                var candidat = _candidatsRepository.GetById(id);
                if(candidat != null)
                {
                    model.Id = id;
                    candidat = MakeModel(model);

                    _candidatsRepository.Update(candidat);
                    _unitOfWork.Commit();

                    return request.CreateResponse(HttpStatusCode.OK, Mapper.Map<CandidatViewModel>(candidat));
                }
                return request.CreateErrorResponse(HttpStatusCode.NoContent, "Pas de candidat pour cette requete !");
            });
        }

        // DELETE: api/Candidat/1
        [HttpPut]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                var candidat = _candidatsRepository.GetById(id);
                if (candidat != null)
                {
                    _candidatsRepository.Delete(candidat);
                    _unitOfWork.Commit();

                    return request.CreateResponse(HttpStatusCode.OK, Mapper.Map<CandidatViewModel>(candidat));
                }

                return request.CreateErrorResponse(HttpStatusCode.NoContent, "Pas de candidat pour cette requete !");
            });
        }

        // Helpers methods
        private Candidat MakeModel(CandidatViewModel vm)
        {
            return new Candidat
            {
                Adresse = vm.Adresse,
                Avatar = vm.Avatar,
                Civilite = vm.Civilite,
                Cv = vm.Cv,
                Email = vm.Email,
                Id = vm.Id,
                Naissance = vm.Naissance,
                Nom = vm.Nom,
                Password = vm.Password,
                Prenom = vm.Prenom,
                RefVille = vm.RefVille,
                Telephone = vm.Telephone
            };
        }
    }
}
