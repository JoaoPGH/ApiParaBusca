using Api.Cep.Integracao;
using Api.Cep.Integracao.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace Api.Cep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private IViaEstadosIntegracao _integracao;

        public EstadosController(IViaEstadosIntegracao integracao)
        {
            _integracao = integracao;
        }

        [HttpGet]
        public async Task<ActionResult<ViaEstadosIntegracao>> ListarEstados(string estados)
        {
            var responseData = await _integracao.ObterEstados(estados);

            if(responseData == null)
            {
                return BadRequest("Estado não encontrado");
            }

            return Ok(responseData);
        }
    }
}
