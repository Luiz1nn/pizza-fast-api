using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaFast.Application.Interfaces;
using PizzaFast.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaFast.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {
            var categorias = await _categoriaService.GetCategorias();
            return Ok(categorias);
        }

        [HttpGet("{id}", Name = "GetCategoria")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            var categoria = await _categoriaService.GetById(id);
            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _categoriaService.Add(categoria);

            return new CreatedAtRouteResult("GetCategoria", new { id = categoria.Id }, categoria);
        }
    }
}
