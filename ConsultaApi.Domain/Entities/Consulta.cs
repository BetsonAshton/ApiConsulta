using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaApi.Domain.Entities
{
    public class Consulta
    {
        public Guid ConsultaId { get; set; }
        public DateTime DataConsulta { get; set; }
        public Guid PacienteId { get; set; }
        public Guid MedicoId { get; set; }
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
    }
}
