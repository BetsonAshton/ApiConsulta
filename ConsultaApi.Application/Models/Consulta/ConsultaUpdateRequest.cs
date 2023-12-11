using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaApi.Application.Models.Consulta
{
    public class ConsultaUpdateRequest
    {
        [Required(ErrorMessage = "Por favor, informe o id da consulta .")]
        public Guid ConsultaId { get; set; }

        [Required(ErrorMessage = "O campo 'Data da Consulta' é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "O campo 'Data da Consulta' deve ser uma data válida.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataConsulta { get; set; }

        [Required(ErrorMessage = "Por favor, informe o id do paciente.")]
        public Guid? PacienteId { get; set; }

        [Required(ErrorMessage = "Por favor, informe o id do medico.")]
        public Guid? MedicoId { get; set; }
    }
}
