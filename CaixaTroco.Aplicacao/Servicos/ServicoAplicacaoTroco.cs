using CaixaTroco.Aplicacao.Dto.Dto;
using CaixaTroco.Aplicacao.Interfaces;
using CaixaTroco.Dominio.Core.Interfaces.Servicos;

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
            var cedulasDisponiveis = _serviceoCedula.ObterCedulasDisponiveis();

            _servicoTransacao.Add(new Dominio.Entidades.Transacao()
            {
                ValorPago = 100,
                ValorTotal = 60,
                Cedulas = new System.Collections.Generic.List<Dominio.Entidades.TransacaoCedula>()
                {
                    new Dominio.Entidades.TransacaoCedula()
                    {
                        Valor = 20m,
                        Quantidade = 2
                    }
                }
            });

            return new TrocoResponse()
            {
                Cedulas = new System.Collections.Generic.List<CedulaDto>()
                {
                    new CedulaDto()
                    {
                        Valor = 20m,
                        Quantidade = 2
                    }
                }
            };

            return null;

        }
    }
}
