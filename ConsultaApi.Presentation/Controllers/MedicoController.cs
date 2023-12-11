using ConsultaApi.Application.Interfaces;
using ConsultaApi.Application.Models.Medico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ConsultaApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Medico")]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoAppService _medicoAppService;

        public MedicoController(IMedicoAppService medicoAppService)
        {
            _medicoAppService = medicoAppService;
        }


        [HttpPost]
        [ProducesResponseType(typeof(MedicoResponse), 201)]
        public IActionResult Post(MedicoCreateRequest request)
        {
            return StatusCode(201, new
            {
                mensagem = "Médico cadastrado com sucesso.",
                medico = _medicoAppService.Create(request)
            });
        }

        [HttpPut]
        [ProducesResponseType(typeof(MedicoResponse), 200)]
        public IActionResult Put(MedicoUpdateRequest request)
        {
            return StatusCode(200, new
            {
                mensagem = "Médico atualizado com sucesso.",
                medico = _medicoAppService.Update(request)
            });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(MedicoResponse), 200)]
        public IActionResult Delete(Guid id)
        {
            return StatusCode(200, new
            {
                mensagem = "Os seguintes dados do médico foram excluídos como sucesso.",
                medico = _medicoAppService.Delete(id)
            });
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<MedicoResponse>), 200)]
        public IActionResult GetAll()
        {
            return StatusCode(200, _medicoAppService.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MedicoResponse), 200)]
        public IActionResult GetById(Guid id)
        {
            return StatusCode(200, _medicoAppService.GetById(id));
        }
    }
}
