﻿using PizzaFast.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFast.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetCategoriasAsync();
        Task<Categoria> GetByIdAsync(int? id);
        Task<Categoria> CreateAsync(Categoria categoria);
        Task<Categoria> UpdateAsync(Categoria categoria);
        Task<Categoria> RemoveAsync(Categoria categoria);
    }
}
