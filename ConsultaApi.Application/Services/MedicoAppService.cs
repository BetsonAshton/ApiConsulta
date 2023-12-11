using AutoMapper;
using ConsultaApi.Application.Interfaces;
using ConsultaApi.Application.Models.Medico;
using ConsultaApi.Domain.Entities;
using ConsultaApi.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaApi.Application.Services
{
    public class MedicoAppService:IMedicoAppService
    {
        private readonly IMedicoDomainService _medicoDomainService;
        private readonly IMapper _mapper;

        public MedicoAppService(IMedicoDomainService medicoDomainService, IMapper mapper)
        {
            _medicoDomainService = medicoDomainService;
            _mapper = mapper;
        }

        public MedicoResponse Create(MedicoCreateRequest request)
        {
            var medico = _mapper.Map<Medico>(request);
            _medicoDomainService.Create(medico);
            return _mapper.Map<MedicoResponse>(medico);

        }

        public MedicoResponse Update(MedicoUpdateRequest request)
        {
            var medico = _mapper.Map<Medico>(request);
            _medicoDomainService.Update(medico);
            return _mapper.Map<MedicoResponse>(medico);
        }

        public MedicoResponse Delete(Guid id)
        {
            var medico = _medicoDomainService.GetById(id);
            _medicoDomainService.Delete(id);
            return _mapper.Map<MedicoResponse>(medico);
        }

        public List<MedicoResponse> GetAll()
        {
            var medico = _medicoDomainService.GetAll();
            return _mapper.Map<List<MedicoResponse>>(medico);
        }

        public MedicoResponse GetById(Guid id)
        {
            var medico = _medicoDomainService.GetById(id);
            return _mapper.Map<MedicoResponse>(medico);
        }
    }
}
