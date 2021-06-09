using CaixaTroco.Dominio.Core.Interfaces.Repositorios;
using CaixaTroco.Dominio.Entidades;
using CaixaTroco.Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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

        public void Add(Transacao transacao)
        {
            DbSet.Add(transacao);
            _context.SaveChanges();
        }

        public IEnumerable<Transacao> ObterTransacoes()
            => DbSet.ToList();
    }
}
