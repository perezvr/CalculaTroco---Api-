using CaixaTroco.Aplicacao.Dto.Dto;

namespace CaixaTroco.Aplicacao.Interfaces
{
    public interface IServicoAplicacaoTroco
    {
        TrocoResponse CalcularTroco(TrocoRequest request);
    }
}
