using ConsultaApi.Domain.Entities;
using ConsultaApi.Domain.Interfaces.Repositories;
using ConsultaApi.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaApi.Domain.Services
{
    public class MedicoDomainService:IMedicoDomainService
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoDomainService(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public void Create(Medico entity)
        {
            _medicoRepository.Create(entity);
        }

        public void Update(Medico entity)
        {
            var medico = _medicoRepository.GetById((Guid)entity.MedicoId);

            medico.Nome = entity.Nome;
            medico.Especialidade = entity.Especialidade;

            _medicoRepository.Update(medico);


        }

        public void Delete(Guid id)
        {
            var  medico = _medicoRepository.GetById(id);
            _medicoRepository.Delete(medico);
        }

        public List<Medico> GetAll()
        {
            return _medicoRepository.GetAll();
        }

        public Medico GetById(Guid id)
        {
            var medico = _medicoRepository.GetById(id);
            return medico;
        }
    }
}
