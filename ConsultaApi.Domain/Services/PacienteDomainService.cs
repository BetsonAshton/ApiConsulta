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
    public class PacienteDomainService: IPacienteDomainService
    {

        private readonly IPacienteRepository _pacienteRepository;
        

        public PacienteDomainService(IPacienteRepository pacienteRepository, IConsultaRepository consultaRepository)
        {
            _pacienteRepository = pacienteRepository;
            
        }

        public void Create(Paciente entity)
        {


            _pacienteRepository.Create(entity);
          

        }

        public void Update(Paciente entity)
        {
            var paciente = _pacienteRepository.GetById((Guid)entity.PacienteId);

            paciente.Nome = entity.Nome;
            paciente.DataNascimento = entity.DataNascimento;

            _pacienteRepository.Update(paciente);
        }
       
        public void Delete(Guid id)
        {
            var paciente = _pacienteRepository.GetById(id);
            _pacienteRepository.Delete(paciente);
        }

        public List<Paciente> GetAll()
        {
            return _pacienteRepository.GetAll();
        }

        public Paciente GetById(Guid id)
        {
            var paciente = _pacienteRepository.GetById(id);
            return paciente;
        }
    }
}
