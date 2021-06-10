using System.Collections.Generic;

namespace CaixaTroco.Aplicacao.Dto.Dto
{
    public class TrocoResponse
    {
        public decimal ValorTroco { get; set; }
        public List<CedulaDto> Cedulas { get; set; }

        public TrocoResponse()
        {
            Cedulas = new List<CedulaDto>();
        }
    }
}
