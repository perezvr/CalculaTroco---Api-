using System.Collections.Generic;

namespace CaixaTroco.Aplicacao.Dto.RepositorioTransacao
{
    public class TransacaoDto
    {
        public int Id { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorPago { get; set; }
        public List<TransacaoCedulaDto> Cedulas { get; set; }
    }
}
