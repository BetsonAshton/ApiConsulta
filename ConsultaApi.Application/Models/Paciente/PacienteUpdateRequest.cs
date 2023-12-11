using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaApi.Application.Models.Paciente
{
    public class PacienteUpdateRequest
    {
        [Required(ErrorMessage = "Por favor, informe o id do Paciente desejado.")]
        public Guid PacienteId { get; set; }

        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do paciente.")]

        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo 'Data de Nascimento' é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "O campo 'Data de Nascimento' deve ser uma data válida.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }
    }
}
