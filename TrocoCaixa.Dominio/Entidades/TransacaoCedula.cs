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

        private TransacaoCedula(int quantidade, decimal valor)
        {
            Quantidade = quantidade;
            Valor = valor;

            Validar();
        }

        public static TransacaoCedula Criar(int quantidade, decimal valor)
            => new TransacaoCedula(quantidade, valor);

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
