using CaixaTroco.Aplicacao.Dto.Dto;
using CaixaTroco.Aplicacao.Interfaces;
using CaixaTroco.Dominio;
using CaixaTroco.Dominio.Core.Interfaces.Servicos;
using CaixaTroco.Dominio.Entidades;

namespace CaixaTroco.Aplicacao.Servicos
{
    public class ServicoAplicacaoTroco : IServicoAplicacaoTroco
    {
        private readonly IServicoCedula _serviceoCedula;
        private readonly IServicoTransacao _servicoTransacao;

        public ServicoAplicacaoTroco(IServicoCedula serviceoCedula,
            IServicoTransacao servicoTransacao)
        {
            _serviceoCedula = serviceoCedula;
            _servicoTransacao = servicoTransacao;
        }

        public TrocoResponse CalcularTroco(TrocoRequest request)
        {
            ValidarRequest(request);

            var transacao = CriarTransacao(request);

            _servicoTransacao.Add(transacao);

            return CriarResposta(transacao);
        }

        private void ValidarRequest(TrocoRequest request)
        {
            if (request.ValorTotal <= 0)
                throw new NegocioException("Valor total deve ser informado.");

            if (request.ValorPago <= 0)
                throw new NegocioException("Valor total deve ser informado.");

            if (request.ValorPago == request.ValorTotal)
                throw new NegocioException("Não há troco a ser calculado.");

            if (request.ValorPago < request.ValorTotal)
                throw new NegocioException("Valor total a ser pago não foi atingido.");
        }

        private TrocoResponse CriarResposta(Transacao transacao)
        {
            var response = new TrocoResponse();

            foreach (var item in transacao.Cedulas)
                response.Cedulas.Add(new CedulaDto() { Quantidade = item.Quantidade, Valor = item.Valor });

            return response;
        }

        private Transacao CriarTransacao(TrocoRequest request)
        {
            var transacao = Transacao.Criar(request.ValorTotal, request.ValorPago);
            var cedulasDisponiveis = _serviceoCedula.ObterCedulasDisponiveis();
            decimal valorTroco = request.ValorPago - request.ValorTotal;

            foreach (var item in cedulasDisponiveis)
            {
                var numeroCedulas = (int)(valorTroco / item.Valor);

                if (valorTroco <= 0 || numeroCedulas <= 0)
                    continue;

                transacao.AdicionarCedulas(TransacaoCedula.Criar(numeroCedulas, item.Valor));
                valorTroco = valorTroco % item.Valor;
            }

            return transacao;
        }
    }
}
