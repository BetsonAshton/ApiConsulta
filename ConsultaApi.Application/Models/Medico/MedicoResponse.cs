using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaApi.Application.Models.Medico
{
    public class MedicoResponse
    {
        public Guid MedicoId { get; set; }
        public string? Nome { get; set; }
        public string? Especialidade { get; set; }
    }
}
