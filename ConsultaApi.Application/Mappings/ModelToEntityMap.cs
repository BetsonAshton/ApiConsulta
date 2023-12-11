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
    public class ModelToEntityMap : Profile
    {

        public ModelToEntityMap()
        {
            CreateMap<PacienteCreateRequest, Paciente>()
            .AfterMap((src, dest) =>
            {
                dest.PacienteId = Guid.NewGuid();
                dest.DataNascimento = src.DataNascimento;
            });

            CreateMap<PacienteUpdateRequest, Paciente>();

            CreateMap<MedicoCreateRequest, Medico>()
                .AfterMap((src, dest) =>
                {
                    dest.MedicoId = Guid.NewGuid();
                });

            CreateMap<MedicoUpdateRequest, Medico>();

            CreateMap<ConsultaCreateRequest, Consulta>()
                .AfterMap((src, dest) =>
                {
                    dest.ConsultaId = Guid.NewGuid();
                    dest.DataConsulta = src.DataConsulta;

                    // Declare a variável paciente antes de usar
                    Paciente paciente = null;

                    // Obtenha o paciente do repositório pelo src.PacienteId
                    // e atribua à variável paciente
                    paciente = // Obtenha o paciente do repositório pelo src.PacienteId

                    dest.Paciente = paciente;
                });

            CreateMap<ConsultaUpdateRequest, Consulta>()
                .ForMember(dest => dest.DataConsulta, opt => opt.MapFrom(src => src.DataConsulta));
        }
    }

 }




