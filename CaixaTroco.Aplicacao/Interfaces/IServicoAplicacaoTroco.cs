using CaixaTroco.Aplicacao.Dto.Dto;
using System.Threading.Tasks;

namespace CaixaTroco.Aplicacao.Interfaces
{
    public interface IServicoAplicacaoTroco
    {
        Task<TrocoResponse> CalcularTrocoAsync(TrocoRequest request);
    }
}
