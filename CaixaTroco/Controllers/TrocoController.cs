using CaixaTroco.Aplicacao.Dto.Dto;
using CaixaTroco.Aplicacao.Interfaces;
using CaixaTroco.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CaixaTroco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrocoController : ControllerBase
    {
        private readonly IServicoAplicacaoTroco _servicoAplicacaoTroco;

        public TrocoController(IServicoAplicacaoTroco servicoAplicacaoTroco)
        {
            _servicoAplicacaoTroco = servicoAplicacaoTroco;
        }

        [HttpPost()]
        public async Task<ActionResult<TrocoResponse>> CalcularTrocoAsync([FromBody] TrocoRequest request)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _servicoAplicacaoTroco.CalcularTrocoAsync(request));
            }
            catch (NegocioException ex)
            {
                return UnprocessableEntity(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
