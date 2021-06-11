using CaixaTroco.Dominio.Core.Interfaces.Repositorios;
using CaixaTroco.Dominio.Core.Interfaces.Servicos;
using CaixaTroco.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaixaTroco.Dominio.Servico.Servicos
{
    public class ServicoTransacao : IServicoTransacao
    {
        private readonly IRepositorioTransacao _repositorioTransacao;

        public ServicoTransacao(IRepositorioTransacao repositorioTransacao)
        {
            _repositorioTransacao = repositorioTransacao;
        }

        public async Task<Transacao> AddAsync(Transacao transacao)
        {
            await _repositorioTransacao.AddAsync(transacao);
            return transacao;
        }

        public async Task<IEnumerable<Transacao>> ObterTransacoesAsync()
            => await _repositorioTransacao.ObterTransacoesAsync();
    }
}
