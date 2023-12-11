using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaApi.Application.Models.Paciente
{
    public class PacienteResponse
    {
        public Guid PacienteId { get; set; }
        public string? Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
