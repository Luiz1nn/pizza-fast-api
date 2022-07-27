using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaFast.Domain.Models
{
    public sealed class Produto : Entity
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome deve ter de 3 a 100 caracteres")]
        public string Nome { get; set; }
        [Required]
        [MaxLength(200)]
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }
        [Required]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
