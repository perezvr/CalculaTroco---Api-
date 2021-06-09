using CaixaTroco.Aplicacao.Dto.Dto;
using CaixaTroco.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            return _servicoAplicacaoTroco.CalcularTroco(request);
        }
    }
}
