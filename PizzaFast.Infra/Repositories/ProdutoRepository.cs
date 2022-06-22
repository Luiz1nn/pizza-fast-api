using Microsoft.EntityFrameworkCore;
using PizzaFast.Domain.Interfaces;
using PizzaFast.Domain.Models;
using PizzaFast.Infra.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaFast.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Produto>> GetProdutosAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> GetByIdAsync(int? id)
        {
            return await _context.Produtos.Include(c => c.Categoria)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> GetProdutosByCategoriaIdAsync(int categoriaId)
        {
            List<Produto> produtos = await _context.Produtos.AsNoTracking().Where(p => p.CategoriaId == categoriaId).ToListAsync();
            if (produtos == null) return null;
            return produtos;
        }

        public async Task<Produto> CreateAsync(Produto produto)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> UpdateAsync(Produto produto)
        {
            _context.Update(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> RemoveAsync(Produto produto)
        {
            _context.Remove(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

    }
}
