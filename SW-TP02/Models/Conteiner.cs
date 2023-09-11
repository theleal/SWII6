using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TP02___SWII6.Enums.EnumsConteiner;

namespace TP02___SWII6.Models
{
    public class Conteiner
    {
        [Key] 
        public int ID { get; set; }

        [Required]
        [MaxLength(11)]
        [Column(TypeName = "VARCHAR(11)")]
        public string NumeroConteiner { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "SMALLINT")]
        public Tipo Tipo { get; set; }

        [Required]
        [Column(TypeName = "SMALLINT")]
        public Tamanho Tamanho { get; set; }
    }
}
