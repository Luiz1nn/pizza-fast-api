using PizzaFast.Application.DTOs;
using PizzaFast.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaFast.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> GetCategorias();
        Task<CategoriaDTO> GetById(int? id);
        Task Add(CategoriaDTO categoriaDto);
        Task Update(Categoria categoria);
        Task Remove(int id);
    }
}
