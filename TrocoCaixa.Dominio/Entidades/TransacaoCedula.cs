using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaixaTroco.Dominio.Entidades
{
    public class TransacaoCedula : BaseModel
    {
        [Required(ErrorMessage = "Quantidade é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantidade deve ser maior que 0.")]
        public int Quantidade { get; private set; }

        [Required(ErrorMessage = "Valor é obrigatório.")]
        [Range(0.01, 9999.99, ErrorMessage = "Quantidade deve estar entre 0.01 e 9999.99.")]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Valor { get; private set; }

        public int TransacaoId { get; set; }

        private TransacaoCedula(int quantidade, decimal valor)
        {
            Quantidade = quantidade;
            Valor = valor;

            Validar();
        }

        private TransacaoCedula(int id, int quantidade, decimal valor, int transacaoId)
        {
            Id = id;
            Quantidade = quantidade;
            Valor = valor;
            TransacaoId = transacaoId;

            Validar();
        }

        public static TransacaoCedula Criar(int quantidade, decimal valor)
            => new TransacaoCedula(quantidade, valor);

        public static TransacaoCedula Criar(int id, int quantidade, decimal valor, int transacaoId)
            => new TransacaoCedula(id, quantidade, valor, transacaoId);

        public bool Validar()
        {
            var vContext = new ValidationContext(this);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(this, vContext, results, true))
                throw new ArgumentException(results[0].ErrorMessage);

            return true;
        }
    }
}
