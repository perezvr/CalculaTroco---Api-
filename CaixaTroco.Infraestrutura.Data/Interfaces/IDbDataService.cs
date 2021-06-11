using System.Data;

namespace CaixaTroco.Infraestrutura.Data.Interfaces
{
    public interface IDbDataService
    {
        IDbConnection ObterConexao();
    }
}
