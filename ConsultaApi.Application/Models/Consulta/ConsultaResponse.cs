using ConsultaApi.Application.Models.Medico;
using ConsultaApi.Application.Models.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaApi.Application.Models.Consulta
{
    public class ConsultaResponse
    {
        public Guid ConsultaId { get; set; }
        public DateTime DataConsulta { get; set; }
        public MedicoResponse Medico { get; set; }
        public PacienteResponse Paciente { get; set; }

    }
}
