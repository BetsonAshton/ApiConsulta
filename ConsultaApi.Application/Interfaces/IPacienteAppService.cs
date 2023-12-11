using ConsultaApi.Application.Models.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaApi.Application.Interfaces
{
    public interface IPacienteAppService
    {
        PacienteResponse Create(PacienteCreateRequest request);
        PacienteResponse Update(PacienteUpdateRequest request);

        PacienteResponse Delete(Guid id);

        List<PacienteResponse> GetAll();

       PacienteResponse GetById(Guid id);
    }
}
