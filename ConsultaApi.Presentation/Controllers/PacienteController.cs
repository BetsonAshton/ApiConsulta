using ConsultaApi.Application.Interfaces;
using ConsultaApi.Application.Models.Paciente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ConsultaApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Paciente")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteAppService _pacienteAppService;

        public PacienteController(IPacienteAppService pacienteAppService)
        {
            _pacienteAppService = pacienteAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PacienteResponse), 201)]
        public IActionResult Post(PacienteCreateRequest request)
        {
            return StatusCode(201, new
            {
                mensagem = "Paciente cadastrado com sucesso.",
                paciente = _pacienteAppService.Create(request)
            });
        }

        [HttpPut]
        [ProducesResponseType(typeof(PacienteResponse), 200)]
        public IActionResult Put(PacienteUpdateRequest request)
        {
            return StatusCode(200, new
            {
                mensagem = "Paciente atualizdado com sucesso.",
                paciente = _pacienteAppService.Update(request)
            });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PacienteResponse), 200)]
        public IActionResult Delete(Guid id)
        {
            return StatusCode(200, new
            {
                mensagem = "Os seguintes dados do paciente foram excluídos como sucesso.",
                paciente = _pacienteAppService.Delete(id)
            });
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PacienteResponse>), 200)]
        public IActionResult GetAll()
        {
            return StatusCode(200, _pacienteAppService.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PacienteResponse), 200)]
        public IActionResult GetById(Guid id)
        {
            return StatusCode(200, _pacienteAppService.GetById(id));
        }
    }
}
