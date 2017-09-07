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
        //public HttpResponseMessage Get()
        //{
        //    try
        //    {
        //        var products = _candidatsRepository.All();

        //        var code = (products != null) ? HttpStatusCode.OK : HttpStatusCode.NoContent;
        //        return Request.CreateResponse(code, products);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
        //    }
        //}

        // GET: api/Candidat
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            //filter = filter.ToLower().Trim();

            return CreateHttpResponse(request, () =>
            {
                // HttpResponseMessage response = null;

                //var candidats = _candidatsRepository.GetAll()
                //    .Where(c => c.Nom.ToLower().Contains(filter) ||
                //    c.Prenom.ToLower().Contains(filter) ||
                //    c.Email.ToLower().Contains(filter)).ToList();

                var candidats = Mapper.Map<IEnumerable<CandidatViewModel>>(_candidatsRepository.GetAll());
                return request.CreateResponse(HttpStatusCode.OK, candidats);
            });
        }

        // POST: api/Candidat
        //[HttpPost]
        //public HttpResponseMessage Post([FromBody] Candidat value)
        //{
        //    try
        //    {
        //        _candidatsRepository.Add(value);
        //        _candidatsRepository.Save();
        //        return Request.CreateResponse(HttpStatusCode.OK, value);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
        //    }
        //}

        // POST: api/Candidat
        [HttpPost]
        public HttpResponseMessage Post(HttpRequestMessage request, Candidat value)
        {
            return CreateHttpResponse(request, () =>
            {
                //HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                _candidatsRepository.Add(value);
                _unitOfWork.Commit();
                

                return request.CreateResponse(HttpStatusCode.Created, Mapper.Map<CandidatViewModel>(value)); ;
            });
        }

    }
}
