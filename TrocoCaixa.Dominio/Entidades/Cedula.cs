using System.Collections.Generic;
using System.Linq;

namespace CaixaTroco.Dominio.Entidades
{
    public class Cedula
    {
        //todo Passar isso para o servico da aplicacao
        public decimal Valor { get; set; }

        public static List<Cedula> ObterCedulasDisponiveis()
            => new List<Cedula>()
            {
                new Cedula()
                {
                    Valor = 100m
                },
                new Cedula()
                {
                    Valor = 50m
                },
                new Cedula()
                {
                    Valor = 20m
                },
                new Cedula()
                {
                    Valor = 10m
                },
                new Cedula()
                {
                    Valor = .5m
                },
                new Cedula()
                {
                    Valor = .1m
                },
                new Cedula()
                {
                    Valor = .05m
                },
                new Cedula()
                {
                    Valor = .01m
                },
            }
                .OrderByDescending(c => c.Valor)
                .ToList();
    }
}
