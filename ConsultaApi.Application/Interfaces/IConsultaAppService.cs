using ConsultaApi.Application.Models.Consulta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaApi.Application.Interfaces
{
    public interface IConsultaAppService
    {
        ConsultaResponse Create(ConsultaCreateRequest request);
        ConsultaResponse Update(ConsultaUpdateRequest request);

        ConsultaResponse Delete(Guid id);

        List<ConsultaResponse>GetAll();

        ConsultaResponse GetById(Guid id);
    }
}
