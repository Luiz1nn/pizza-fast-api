using PizzaFast.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaFast.Application.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome deve ter de 3 a 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [MaxLength(200)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o preço")]
        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
    }
}
