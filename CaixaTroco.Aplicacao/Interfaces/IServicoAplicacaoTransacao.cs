using CaixaTroco.Aplicacao.Dto.Dto;
using System.Threading.Tasks;

namespace CaixaTroco.Aplicacao.Interfaces
{
    public interface IServicoAplicacaoTransacao
    {
        Task<TransacaoResponse> ObterTransacoesAsync();
    }
}
