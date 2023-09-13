using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP02___SWII6.Models
{
    public class DocumentoBL
    {
        [Key] 
        public int ID { get; set; }

        [Required] 
        [Column(TypeName = "VARCHAR(25)")] 
        public string NumeroDocumento { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "VARCHAR(25)")]
        public string Consignee { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "VARCHAR(25)")]
        public string Navio { get; set; } = string.Empty;

        public ICollection<Conteiner?> Conteineres { get; set; } = new List<Conteiner>();

    }
}
