using AutoMapper;
using EasyWork.Entities;
using EasyWork.Models;

namespace EasyWork
{
    public class AutoMapperConfig
    {
        public static void ReguisterMappings()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Candidat, CandidatViewModel>()
                   .ForMember(dest => dest.Ville, opts => opts.MapFrom(src => src.Ville.Nom));
            });
        }
    }
}