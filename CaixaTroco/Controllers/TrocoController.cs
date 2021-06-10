using CaixaTroco.Aplicacao.Dto.Dto;
using CaixaTroco.Aplicacao.Interfaces;
using CaixaTroco.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public ActionResult<TrocoResponse> CalcularTroco([FromBody] TrocoRequest request)
        {
            try
            {
                return Ok(_servicoAplicacaoTroco.CalcularTroco(request));
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
