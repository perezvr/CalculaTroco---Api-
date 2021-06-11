using CaixaTroco.Aplicacao.Dto.Dto;
using CaixaTroco.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaTroco.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly IServicoAplicacaoTransacao _servicoAplicacaoTransacao;

        public TransacaoController(IServicoAplicacaoTransacao servicoAplicacaoTransacao)
        {
            _servicoAplicacaoTransacao = servicoAplicacaoTransacao;
        }

        [HttpGet()]
        public async Task<ActionResult<TransacaoResponse>> ObterTransacoesAsync()
        {
            try
            {
                var response = await _servicoAplicacaoTransacao.ObterTransacoesAsync();

                if (!response.Transacoes.Any())
                    return StatusCode(StatusCodes.Status404NotFound, new { message = "Não foram encontradas transações." });

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
