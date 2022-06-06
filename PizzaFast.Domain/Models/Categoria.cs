using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaFast.Domain.Models
{
    public sealed class Categoria : Entity
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome deve ter de 3 a 100 caracteres")]
        public string Nome { get; set; }
        public ICollection<Produto> Produtos { get; set; }

    }
}
