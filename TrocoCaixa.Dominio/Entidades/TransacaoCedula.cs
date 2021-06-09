using System.ComponentModel.DataAnnotations.Schema;

namespace CaixaTroco.Dominio.Entidades
{
    public class TransacaoCedula : BaseModel
    {
        public int Quantidade { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal Valor { get; set; }
    }
}
