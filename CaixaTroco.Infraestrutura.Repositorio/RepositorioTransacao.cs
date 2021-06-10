using CaixaTroco.Dominio.Core.Interfaces.Repositorios;
using CaixaTroco.Dominio.Entidades;
using CaixaTroco.Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaTroco.Infraestrutura.Repositorio
{
    public class RepositorioTransacao : IRepositorioTransacao
    {
        private readonly ApplicationContext _context;
        protected DbSet<Transacao> DbSet { get; set; }

        public RepositorioTransacao(ApplicationContext context)
        {
            _context = context;
            DbSet = _context.Set<Transacao>();
        }

        public async Task AddAsync(Transacao transacao)
        {
            await DbSet.AddAsync(transacao);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Transacao> ObterTransacoes()
            => DbSet.ToList();
    }
}
