using CaixaTroco.Dominio.Entidades;
using System.Collections.Generic;

namespace CaixaTroco.Dominio.Core.Interfaces.Servicos
{
    public interface IServicoCedula
    {
        IEnumerable<Cedula> ObterCedulasDisponiveis();
    }
}
