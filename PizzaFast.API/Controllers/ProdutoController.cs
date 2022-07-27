using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaFast.Application.DTOs;
using PizzaFast.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PizzaFast.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/produtos")]
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

        [HttpGet("categoria/{categoriaId}")]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetProdutoByIdCategoria(int categoriaId)
        {
            var produto = await _produtoService.GetProdutosByCategoriaId(categoriaId);
            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutoDTO produtoDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var imageName = Guid.NewGuid() + "-" + produtoDto.Imagem;
            if (!UploadArquivo(produtoDto.ImagemUpload, imageName)) return BadRequest(ModelState);

            await _produtoService.Add(produtoDto);

            return new CreatedAtRouteResult("GetProduto", new { id = produtoDto.Id }, produtoDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] ProdutoDTO produtoDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != produtoDto.Id) return BadRequest();

            var produtoAtualizacao = await _produtoService.GetById(id);

            if (produtoDto.ImagemUpload != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + produtoDto.Imagem;
                if (!UploadArquivo(produtoDto.ImagemUpload, imagemNome))
                {
                    return BadRequest(ModelState);
                }

                produtoAtualizacao.Imagem = imagemNome;
            }
            else
            {
                return BadRequest();
            }

            await _produtoService.Update(produtoAtualizacao);

            return Ok(produtoDto);
        }

        private bool UploadArquivo(string arquivo, string imgNome)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                return false;
            }

            var imageDataByteArray = Convert.FromBase64String(arquivo);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imgNome);

            if (System.IO.File.Exists(filePath))
            {
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

            return true;
        }
    }
}
