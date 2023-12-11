using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaApi.Domain.Entities
{
    public class Medico
    {
        public Guid MedicoId { get; set; }
        public string? Nome { get; set; }
        public string? Especialidade { get; set; }
    }
}
