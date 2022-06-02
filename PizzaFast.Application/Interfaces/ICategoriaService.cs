using PizzaFast.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaFast.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> GetCategorias();
        Task<Categoria> GetById(int id);
        Task Add(Categoria categoria);
        Task Update(Categoria categoria);
        Task Remove(int id);
    }
}
