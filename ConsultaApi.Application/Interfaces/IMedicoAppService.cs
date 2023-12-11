using ConsultaApi.Application.Models.Medico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaApi.Application.Interfaces
{
    public interface IMedicoAppService
    {
        MedicoResponse Create(MedicoCreateRequest request);
        MedicoResponse Update(MedicoUpdateRequest request);

        MedicoResponse Delete(Guid id);

        List<MedicoResponse> GetAll();

        MedicoResponse GetById(Guid id);
    }
}
