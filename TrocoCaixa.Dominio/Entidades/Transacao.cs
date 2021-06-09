using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaixaTroco.Dominio.Entidades
{
    public class Transacao : BaseModel
    {
        [Column(TypeName = "decimal(6,2)")]
        public decimal ValorTotal { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal ValorPago { get; set; }
        public List<TransacaoCedula> Cedulas { get; set; }
    }
}
