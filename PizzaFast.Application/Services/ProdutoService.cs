using AutoMapper;
using PizzaFast.Application.DTOs;
using PizzaFast.Application.Interfaces;
using PizzaFast.Domain.Interfaces;
using PizzaFast.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFast.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository ??
                 throw new ArgumentNullException(nameof(produtoRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoDTO>> GetProdutos()
        {
            var produtos = await _produtoRepository.GetProdutosAsync();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
        }

        public async Task<ProdutoDTO> GetById(int? id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            return _mapper.Map<ProdutoDTO>(produto);
        }

        public async Task<IEnumerable<ProdutoDTO>> GetProdutosByCategoriaId(int categoriaId)
        {
            var produtos = await _produtoRepository.GetProdutosByCategoriaIdAsync(categoriaId);
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
        }

        public async Task Add(ProdutoDTO produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            await _produtoRepository.CreateAsync(produto);
        }

        public async Task Update(ProdutoDTO produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            await _produtoRepository.UpdateAsync(produto);
        }

        public async Task Remove(int id)
        {
            var produto = _produtoRepository.GetByIdAsync(id).Result;
            await _produtoRepository.RemoveAsync(produto);
        }
    }
}
