using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TP03SW.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [Display(Name = "Nome do Produto")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        [Column(TypeName = "VARCHAR(50)")]
        [Display(Name = "Descrição do Produto")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Preço é obrigatório.")]
        [Column(TypeName = "VARCHAR(50)")]
        [Display(Name = "Preço do Produto")]
        public string Preco { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo QuantidadeEstoque é obrigatório.")]
        [Column(TypeName = "VARCHAR(50)")]
        [Display(Name = "Quantidade em Estoque do Produto")]
        public string QuantidadeEstoque { get; set; } = string.Empty;
    }
}
