using CaixaTroco.Dominio.Entidades;
using NUnit.Framework;

namespace CaixaTroco.Dominio.Teste.Entidades
{
    public class TransacaoTestes
    {
        [Test]
        public void DeveCriarUmaTransacao()
        {
            Transacao transacao = Transacao.Criar(0.01m, 0.01m);
            Assert.IsNotNull(transacao);
        }

        [Test]
        public void NaoDeveCriarUmaTransacaoSemValorTotal()
        {
            try
            {
                Transacao transacao = Transacao.Criar(0, 0.01m);
                Assert.Fail();
            }
            catch (System.Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void NaoDeveCriarUmaTransacaoSemValorPago()
        {
            try
            {
                Transacao transacao = Transacao.Criar(0.01m, 0);
                Assert.Fail();
            }
            catch (System.Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void NaoDeveCriarUmaTransacaoComValorTotalInvalido()
        {
            try
            {
                Transacao transacao = Transacao.Criar(10000, 0.01m);
                Assert.Fail();
            }
            catch (System.Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void NaoDeveCriarUmaTransacaoValorPagoInvalido()
        {
            try
            {
                Transacao transacao = Transacao.Criar(0.01m, 10000);
                Assert.Fail();
            }
            catch (System.Exception)
            {
                Assert.Pass();
            }
        }
    }
}