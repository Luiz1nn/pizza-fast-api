using Microsoft.EntityFrameworkCore;
using PizzaFast.Domain.Interfaces;
using PizzaFast.Domain.Models;
using PizzaFast.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFast.Infra.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria> GetByIdAsync(int? id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task<Categoria> CreateAsync(Categoria categoria)
        {
            _context.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> UpdateAsync(Categoria categoria)
        {
            _context.Update(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> RemoveAsync(Categoria categoria)
        {
            _context.Remove(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

    }
}
