using PizzaFast.Application.DTOs;
using PizzaFast.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaFast.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> GetProdutos();
        Task<ProdutoDTO> GetById(int? id);
        Task Add(ProdutoDTO produtoDto);
        Task Update(ProdutoDTO produto);
        Task Remove(int id);
    }
}
