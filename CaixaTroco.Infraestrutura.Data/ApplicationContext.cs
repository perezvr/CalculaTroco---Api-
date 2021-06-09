using CaixaTroco.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CaixaTroco.Infraestrutura.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
           : base(options) { }

        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<TransacaoCedula> TransacaoCedulas { get; set; }
    }
}
