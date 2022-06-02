using System.Collections.Generic;

namespace PizzaFast.Domain.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Produto> Produtos { get; set; }

        public Categoria(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
