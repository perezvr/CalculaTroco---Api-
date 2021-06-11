using CaixaTroco.Aplicacao.Dto.Dto;
using CaixaTroco.Aplicacao.Dto.RepositorioTransacao;
using CaixaTroco.Aplicacao.Interfaces;
using CaixaTroco.Dominio.Core.Interfaces.Servicos;
using CaixaTroco.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaTroco.Aplicacao.Servicos
{
    public class ServicoAplicacaoTransacao : IServicoAplicacaoTransacao
    {
        private readonly IServicoTransacao _servicoTransacao;

        public ServicoAplicacaoTransacao(IServicoTransacao servicoTransacao)
        {
            _servicoTransacao = servicoTransacao;
        }

        public async Task<TransacaoResponse> ObterTransacoesAsync()
            => CriarResposta(await _servicoTransacao.ObterTransacoesAsync());

        private TransacaoResponse CriarResposta(IEnumerable<Transacao> transacoes)
        {
            IList<TransacaoDto> respostas = new List<TransacaoDto>();

            foreach (var item in transacoes)
            {
                TransacaoDto resposta = new TransacaoDto()
                {
                    Id = item.Id,
                    ValorPago = item.ValorPago,
                    ValorTotal = item.ValorTotal,
                };

                foreach (var itemCedula in item.Cedulas)
                {
                    resposta.Cedulas.Add(new TransacaoCedulaDto()
                    {
                        Id = itemCedula.Id,
                        Quantidade = itemCedula.Quantidade,
                        Valor = itemCedula.Valor,
                        TransacaoId = itemCedula.TransacaoId
                    });
                }

                respostas.Add(resposta);
            }

            return new TransacaoResponse() { Transacoes = respostas.ToList() };
        }
    }
}
