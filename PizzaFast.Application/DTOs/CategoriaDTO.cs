using System.ComponentModel.DataAnnotations;

namespace PizzaFast.Application.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o nome da Categoria")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome deve ter de 3 a 100 caracteres")]
        public string Nome { get; set; }
    }
}
