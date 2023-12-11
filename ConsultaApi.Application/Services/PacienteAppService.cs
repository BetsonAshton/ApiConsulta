using AutoMapper;
using ConsultaApi.Application.Interfaces;
using ConsultaApi.Application.Models.Paciente;
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
    public class PacienteAppService : IPacienteAppService
    {
        private readonly IPacienteDomainService _pacienteDomainService;
        private readonly IMapper _mapper;

        public PacienteAppService(IPacienteDomainService pacienteDomainService, IMapper mapper)
        {
            _pacienteDomainService = pacienteDomainService;
            _mapper = mapper;
        }

        public PacienteResponse Create(PacienteCreateRequest request)
        {
            if (request.DataNascimento > DateTime.Now)
            {
                throw new InvalidOperationException("A data de nascimento não pode ser no futuro.");
            }

            var paciente = _mapper.Map<Paciente>(request);
            _pacienteDomainService.Create(paciente);
            return _mapper.Map<PacienteResponse>(paciente);
        }

        public PacienteResponse Update(PacienteUpdateRequest request)
        {
            if (request.DataNascimento > DateTime.Now)
            {
                throw new InvalidOperationException("A data de nascimento não pode ser no futuro.");
            }

            var paciente = _mapper.Map<Paciente>(request);
            _pacienteDomainService.Update(paciente);
            return _mapper.Map<PacienteResponse>(paciente);

        }

        public PacienteResponse Delete(Guid id)
        {
            var paciente = _pacienteDomainService.GetById(id);
            _pacienteDomainService.Delete(id);
            return _mapper.Map<PacienteResponse>(paciente);
        }

        public List<PacienteResponse> GetAll()
        {
            var paciente = _pacienteDomainService.GetAll();
            return _mapper.Map<List<PacienteResponse>>(paciente);
        }

        public PacienteResponse GetById(Guid id)
        {
            var paciente = _pacienteDomainService.GetById(id);
            return _mapper.Map<PacienteResponse>(paciente);

        }
    }
}
