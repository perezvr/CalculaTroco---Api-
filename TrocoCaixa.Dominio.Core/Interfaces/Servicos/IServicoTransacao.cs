using CaixaTroco.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaixaTroco.Dominio.Core.Interfaces.Servicos
{
    public interface IServicoTransacao
    {
        Task<Transacao> AddAsync(Transacao transacao);
        IEnumerable<Transacao> ObterTransacoes();
    }
}
