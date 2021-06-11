using CaixaTroco.Aplicacao.Dto.RepositorioTransacao;
using CaixaTroco.Dominio.Core.Interfaces.Repositorios;
using CaixaTroco.Dominio.Entidades;
using CaixaTroco.Infraestrutura.Data;
using CaixaTroco.Infraestrutura.Data.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaTroco.Infraestrutura.Repositorio
{
    public class RepositorioTransacao : IRepositorioTransacao
    {
        private readonly ApplicationContext _context;
        private readonly IDbDataService _dbConnection;

        protected DbSet<Transacao> DbSet { get; set; }

        public RepositorioTransacao(ApplicationContext context,
            IDbDataService connection)
        {
            _context = context;
            DbSet = _context.Set<Transacao>();

            this._dbConnection = connection;
        }

        public async Task AddAsync(Transacao transacao)
        {
            await DbSet.AddAsync(transacao);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Transacao>> ObterTransacoesAsync()
        {
            string sql = @"SELECT 
                               Id,
                               ValorTotal,          
                               ValorPago
                           FROM 
                               Transacao";

            string sqlCedulas = @"SELECT 
                                      Id,
                                      Quantidade,
                                      Valor,
                                      TransacaoId
                                  FROM 
                                      TransacaoCedula";

            var transacoes = new List<Transacao>();
            var cedulas = new List<TransacaoCedula>();

            using (var conexao = _dbConnection.ObterConexao())
            {
                try
                {
                    conexao.Open();

                    var transacoesDto = await conexao.QueryAsync<TransacaoDto>(Queries.ObterTodasTransacoes);
                    var cedulasDto = await conexao.QueryAsync<TransacaoCedulaDto>(Queries.ObterTodasTransacoesCedulas);

                    foreach (var item in cedulasDto.ToList())
                        cedulas.Add(TransacaoCedula.Criar(item.Id, item.Quantidade, item.Valor, item.TransacaoId));

                    foreach (var item in transacoesDto.ToList())
                    {
                        var transacao = Transacao.Criar(item.Id, item.ValorTotal, item.ValorPago);
                        transacao.Cedulas.AddRange(cedulas.Where(c => c.TransacaoId.Equals(transacao.Id)));

                        transacoes.Add(transacao);
                    }

                    return transacoes;
                }
                catch (Exception) { throw; }
                finally
                {
                    conexao.Close();
                }
            }
        }
    }
}
