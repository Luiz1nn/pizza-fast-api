using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaFast.Domain.Models
{
    public class Produto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Preco { get; set; }
        [Required]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
