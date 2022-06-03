using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaFast.Domain.Models
{
    public class Categoria
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
