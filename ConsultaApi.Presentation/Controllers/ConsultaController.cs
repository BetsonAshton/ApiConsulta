using ConsultaApi.Application.Interfaces;
using ConsultaApi.Application.Models.Consulta;
using ConsultaApi.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace ConsultaApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Paciente")]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaAppService _consultaAppService;

        public ConsultaController(IConsultaAppService consultaAppService)
        {
            _consultaAppService = consultaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ConsultaResponse), 201)]
        public IActionResult Post(ConsultaCreateRequest request)
        {
            return StatusCode(201, new
            {
                mensagem = "Consulta cadastrada com sucesso.",
                consulta = _consultaAppService.Create(request)
            });
        }

        [HttpPut]
        [ProducesResponseType(typeof(ConsultaResponse), 200)]
        public IActionResult Put(ConsultaUpdateRequest request)
        {
            return StatusCode(200, new
            {
                mensagem = "Consulta atualizado com sucesso.",
                consulta= _consultaAppService.Update(request)
            });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ConsultaResponse), 200)]
        public IActionResult Delete(Guid id)
        {
            return StatusCode(200, new
            {
                mensagem = "Os seguintes dados da consulta foram excluídos como sucesso.",
                consulta = _consultaAppService.Delete(id)
            });
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ConsultaResponse>), 200)]
        public IActionResult GetAll()
        {
           
            return Ok(_consultaAppService.GetAll());
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ConsultaResponse), 200)]
        public IActionResult GetById(Guid id)
        {
            return Ok(_consultaAppService.GetById(id));
        }
    }
}
