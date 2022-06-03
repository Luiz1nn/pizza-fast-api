using AutoMapper;
using PizzaFast.Application.DTOs;
using PizzaFast.Application.Interfaces;
using PizzaFast.Domain.Interfaces;
using PizzaFast.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaFast.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Categoria>> GetCategorias()
        {

            return await _categoriaRepository.GetCategoriasAsync();
        }

        public async Task<CategoriaDTO> GetById(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);
            return _mapper.Map<CategoriaDTO>(categoria);
        }

        public async Task Add(CategoriaDTO categoriaDto)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto);
            await _categoriaRepository.CreateAsync(categoria);
        }

        public async Task Update(Categoria categoria)
        {
            await _categoriaRepository.UpdateAsync(categoria);
        }

        public async Task Remove(int id)
        {
            var categoria = _categoriaRepository.GetByIdAsync(id).Result;
            await _categoriaRepository.RemoveAsync(categoria);
        }
    }
}
