using AutoMapper;
using ConsultaApi.Application.Models.Consulta;
using ConsultaApi.Application.Models.Medico;
using ConsultaApi.Application.Models.Paciente;
using ConsultaApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaApi.Application.Mappings
{
    public class EntityToModelMap : Profile
    {
        public EntityToModelMap()
        {
            CreateMap<Medico, MedicoResponse>();
            CreateMap<Paciente, PacienteResponse>();
              CreateMap<Consulta, ConsultaResponse>()
            .ForMember(dest => dest.Medico, opt => opt.MapFrom(src => src.Medico))
            .ForMember(dest => dest.Paciente, opt => opt.MapFrom(src => src.Paciente));
        }
    }
}