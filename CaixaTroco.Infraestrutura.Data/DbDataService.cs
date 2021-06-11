using CaixaTroco.Infraestrutura.Data.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CaixaTroco.Infraestrutura.Data
{
    public class DbDataService : IDbDataService
    {
        private readonly IConfiguration _configuration;

        public DbDataService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection ObterConexao()
            => new SqlConnection(_configuration.GetConnectionString("Default"));
    }
}
