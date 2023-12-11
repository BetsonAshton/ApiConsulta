using AutoMapper;
using ConsultaApi.Application.Interfaces;
using ConsultaApi.Application.Models.Consulta;
using ConsultaApi.Domain.Entities;
using ConsultaApi.Domain.Interfaces.Services;
using ConsultaApi.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaApi.Application.Services
{
    public class ConsultaAppService: IConsultaAppService
    {
        private readonly IConsultaDomainService _consultaDomainService;
        private readonly IPacienteDomainService _PacienteDomainService;
        private readonly IMedicoDomainService _MedicoDomainService;
        private readonly IMapper _mapper;

        public ConsultaAppService(IConsultaDomainService consultaDomainService, IPacienteDomainService pacienteDomainService, IMedicoDomainService medicoDomainService, IMapper mapper)
        {
            _consultaDomainService = consultaDomainService;
            _PacienteDomainService = pacienteDomainService;
            _MedicoDomainService = medicoDomainService;
            _mapper = mapper;
        }

        public ConsultaResponse Create(ConsultaCreateRequest request)
        {
            // Verifica se a data da consulta é válida
            if (request.DataConsulta < DateTime.Now)
            {
                // A data da consulta não é válida.
                throw new InvalidOperationException("A data da consulta deve ser futura.");
            }

            var consulta = _mapper.Map<Consulta>(request);
            _consultaDomainService.Create(consulta);

            consulta.Paciente = _PacienteDomainService.GetById(consulta.PacienteId);
            consulta.Medico = _MedicoDomainService.GetById(consulta.MedicoId);
            return _mapper.Map<ConsultaResponse>(consulta);
        }

        public ConsultaResponse Update(ConsultaUpdateRequest request)
        {
            // Verificar se a data da consulta é válida
            if (request.DataConsulta < DateTime.Now)
            {
                // A data da consulta não é válida.
                throw new InvalidOperationException("A data da consulta deve ser futura.");
            }

            var consulta = _mapper.Map<Consulta>(request);
            _consultaDomainService.Update(consulta);

            consulta.Paciente = _PacienteDomainService.GetById(consulta.PacienteId);
            consulta.Medico = _MedicoDomainService.GetById(consulta.MedicoId);

            return _mapper.Map<ConsultaResponse>(consulta);
        }

        public ConsultaResponse Delete(Guid id)
        {
            var consulta = _consultaDomainService.GetById(id);
            if (consulta == null)
            {
                // Consulta não encontrada
                throw new KeyNotFoundException("Consulta não encontrada.");
            }

            _consultaDomainService.Delete(id);

            return _mapper.Map<ConsultaResponse>(consulta);
        }

        public List<ConsultaResponse> GetAll()
        {
            var consultas = _consultaDomainService.GetAll();
            var consultaResponses = _mapper.Map<List<ConsultaResponse>>(consultas);

            // Mapear dados adicionais, se necessário, antes de retornar

            return consultaResponses;
        }

        public ConsultaResponse GetById(Guid id)
        {
            var consulta = _consultaDomainService.GetById(id);
            if (consulta == null)
            {
                // Consulta não encontrada
                throw new KeyNotFoundException("Consulta não encontrada.");
            }

            var pacientes = _PacienteDomainService.GetAll();
            var medicos = _MedicoDomainService.GetAll();

            return _mapper.Map<ConsultaResponse>(consulta);
        }

        
    }
  }

