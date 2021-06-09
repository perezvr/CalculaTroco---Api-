using CaixaTroco.Dominio.Entidades;
using System.Collections.Generic;

namespace CaixaTroco.Dominio.Core.Interfaces.Repositorios
{
    public interface IRepositorioTransacao
    {
        void Add(Transacao transacao);
        IEnumerable<Transacao> ObterTransacoes();
    }
}
