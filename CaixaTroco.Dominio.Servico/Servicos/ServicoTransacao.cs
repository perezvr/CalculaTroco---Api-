using CaixaTroco.Dominio.Core.Interfaces.Repositorios;
using CaixaTroco.Dominio.Core.Interfaces.Servicos;
using CaixaTroco.Dominio.Entidades;
using System.Collections.Generic;

namespace CaixaTroco.Dominio.Servico.Servicos
{
    public class ServicoTransacao : IServicoTransacao
    {
        private readonly IRepositorioTransacao _repositorioTransacao;

        public ServicoTransacao(IRepositorioTransacao repositorioTransacao)
        {
            _repositorioTransacao = repositorioTransacao;
        }

        public Transacao Add(Transacao transacao)
        {
            _repositorioTransacao.Add(transacao);
            return transacao;
        }

        public IEnumerable<Transacao> ObterTransacoes()
         => _repositorioTransacao.ObterTransacoes();
    }
}
