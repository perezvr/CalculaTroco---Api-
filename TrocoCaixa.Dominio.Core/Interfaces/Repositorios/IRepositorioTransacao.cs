using CaixaTroco.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaixaTroco.Dominio.Core.Interfaces.Repositorios
{
    public interface IRepositorioTransacao
    {
        Task AddAsync(Transacao transacao);
        IEnumerable<Transacao> ObterTransacoes();
    }
}
