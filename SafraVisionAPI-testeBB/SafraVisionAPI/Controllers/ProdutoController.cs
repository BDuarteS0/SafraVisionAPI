using Microsoft.AspNetCore.Mvc;
using SafraVisionAPI.Models;
using SafraVisionAPI.Repositorios.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafraVisionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> BuscarTodosProdutos()
        {
            var produtos = await _produtoRepositorio.BuscarTodosProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> BuscarProdutoPorId(int id)
        {
            var produto = await _produtoRepositorio.BuscarProdutoPorId(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> InserirProduto(ProdutoModel produto)
        {
            var novoProduto = await _produtoRepositorio.InserirProduto(produto);
            return CreatedAtAction(nameof(BuscarProdutoPorId), new { id = novoProduto.Id }, novoProduto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoModel>> AtualizarProduto(ProdutoModel produto, int id)
        {
            try
            {
                var produtoAtualizado = await _produtoRepositorio.AtualizarProduto(produto, id);
                return Ok(produtoAtualizado);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarProduto(int id)
        {
            try
            {
                var deletado = await _produtoRepositorio.DeletarProduto(id);
                return Ok(deletado);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }