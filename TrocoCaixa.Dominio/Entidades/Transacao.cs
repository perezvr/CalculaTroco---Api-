using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaixaTroco.Dominio.Entidades
{
    public class Transacao : BaseModel
    {
        [Required(ErrorMessage = "Valor total é obrigatóio.")]
        [Range(0.01, 9999.99, ErrorMessage = "Valor total deve estar entre 0.01 e 9999.99.")]
        [Column(TypeName = "decimal(6,2)")]
        public decimal ValorTotal { get; private set; }

        [Required(ErrorMessage = "Valor pago é obrigatóio.")]
        [Range(0.01, 9999.99, ErrorMessage = "Valor pago deve estar entre 0.01 e 9999.99.")]
        [Column(TypeName = "decimal(6,2)")]
        public decimal ValorPago { get; private set; }

        [Required(ErrorMessage = "Não foram adicionadas cédulas à transação.")]
        public List<TransacaoCedula> Cedulas { get; private set; }

        private Transacao(decimal valorTotal, decimal valorPago)
        {
            ValorTotal = valorTotal;
            ValorPago = valorPago;

            Cedulas = new List<TransacaoCedula>();

            Validar();
        }

        public static Transacao Criar(decimal valorTotal, decimal valorPago)
            => new Transacao(valorTotal, valorPago);

        public void AdicionarCedulas(TransacaoCedula transacaoCedula)
            => Cedulas.Add(transacaoCedula);

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
