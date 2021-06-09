using CaixaTroco.Dominio.Entidades;
using System.Collections.Generic;

namespace CaixaTroco.Dominio.Core.Interfaces.Servicos
{
    public interface IServicoTransacao
    {
        Transacao Add(Transacao transacao);
        IEnumerable<Transacao> ObterTransacoes();
    }
}
