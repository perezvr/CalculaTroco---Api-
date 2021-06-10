using CaixaTroco.Dominio.Entidades;
using NUnit.Framework;

namespace CaixaTroco.Dominio.Teste.Entidades
{
    public class TransacaoCedulaTestes
    {
        [Test]
        public void DeveCriarUmaTransacaoCedula()
        {
            TransacaoCedula cedula = TransacaoCedula.Criar(1, 0.01m);
            Assert.IsNotNull(cedula);
        }

        [Test]
        public void NaoDeveCriarUmaTransacaoCedulaSemQuantidade()
        {
            try
            {
                TransacaoCedula cedula = TransacaoCedula.Criar(0, 0.01m);
                Assert.Fail();
            }
            catch (System.Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void NaoDeveCriarUmaTransacaoCedulaSemValor()
        {
            try
            {
                TransacaoCedula cedula = TransacaoCedula.Criar(1, 0);
                Assert.Fail();
            }
            catch (System.Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void NaoDeveCriarUmaTransacaoCedulaComValorInvalido()
        {
            try
            {
                TransacaoCedula cedula = TransacaoCedula.Criar(1, 10000);
                Assert.Fail();
            }
            catch (System.Exception)
            {
                Assert.Pass();
            }
        }
    }
}
