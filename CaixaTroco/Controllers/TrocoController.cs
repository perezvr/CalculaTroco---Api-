using CaixaTroco.Aplicacao.Dto.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CaixaTroco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrocoController : ControllerBase
    {
        // GET api/<TrocoController>/5
        [HttpPost()]
        public ActionResult<TrocoResponse> Get([FromBody] TrocoRequest request)
        {
            return new TrocoResponse()
            {
                Cedulas = new System.Collections.Generic.List<CedulaDto>()
                {
                    new CedulaDto()
                    {
                        Valor = 20m,
                        Quantidade = 2
                    }
                }
            };
        }

        //// POST api/<TrocoController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<TrocoController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<TrocoController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
