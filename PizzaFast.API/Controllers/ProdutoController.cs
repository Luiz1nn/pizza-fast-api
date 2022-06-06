using Microsoft.AspNetCore.Mvc;
using PizzaFast.Application.DTOs;
using PizzaFast.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaFast.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get()
        {
            var produtos = await _produtoService.GetProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}", Name = "GetProduto")]
        public async Task<ActionResult<ProdutoDTO>> Get(int id)
        {
            var produto = await _produtoService.GetById(id);
            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutoDTO produtoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _produtoService.Add(produtoDto);

            return new CreatedAtRouteResult("GetProduto", new { id = produtoDto.Id }, produtoDto);
        }
    }
}
