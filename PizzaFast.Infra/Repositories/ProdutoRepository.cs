using Microsoft.EntityFrameworkCore;
using PizzaFast.Domain.Interfaces;
using PizzaFast.Domain.Models;
using PizzaFast.Infra.Context;
using System.Collections.Generic;
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
