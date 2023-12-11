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
    public class ConsultaDomainService: IConsultaDomainService
    {
        private readonly IConsultaRepository _consultaRepository;

        public ConsultaDomainService(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        public void Create(Consulta entity)
        {
           
            entity.ConsultaId = Guid.NewGuid();
            entity.DataConsulta = entity.DataConsulta;
            entity.Paciente = entity.Paciente;
            entity.Medico = entity.Medico;

            _consultaRepository.Create(entity);
        }

        public void Update(Consulta entity)
        {
           
            var consulta = _consultaRepository.GetById(entity.ConsultaId);

            consulta.DataConsulta = entity.DataConsulta;
            consulta.Paciente = entity.Paciente;
            consulta.Medico = entity.Medico;



            _consultaRepository.Update(consulta);
        }

        public void Delete(Guid id)
        {
            var consulta = _consultaRepository.GetById(id);
            _consultaRepository.Delete(consulta);
        }

        public List<Consulta> GetAll()
        {
            return _consultaRepository.GetAll();
        }

        public Consulta GetById(Guid id)
        {
            var consulta = _consultaRepository.GetById(id);

            return _consultaRepository.GetById(id);
        }
    }
}
