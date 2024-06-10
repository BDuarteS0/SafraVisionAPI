using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafraVisionAPI.Models;
using SafraVisionAPI.Repositorios.Interfaces;

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

        [HttpGet("BuscarTodosProdutos")]
        public async Task<ActionResult<List<ProdutoModel>>> BuscarTodosProdutos()
        {
            List<ProdutoModel> compradores = await _produtoRepositorio.BuscarTodosProdutos();
            return Ok(compradores);
        }

        [HttpGet("BuscarProdutoPorId")]
        public async Task<ActionResult<ProdutoModel>> BuscarProdutoPorId(int idProduto)
        {
            ProdutoModel comprador = await _produtoRepositorio.BuscarProdutoPorId(idProduto);
            return Ok(comprador);
        }

        [HttpPost("InserirProduto")]
        public async Task<ActionResult<ProdutoModel>> InserirProduto([FromBody] ProdutoModel produtoModel)
        {
            ProdutoModel comprador = await _produtoRepositorio.InserirProduto(produtoModel);
            return Ok(comprador);

        }

        [HttpPut("AtualizarProduto")]
        public async Task<ActionResult<ProdutoModel>> AtualizarProduto([FromBody] ProdutoModel produtoModel, int idProduto)
        {
            ProdutoModel comprador = await _produtoRepositorio.AtualizarProduto(produtoModel, idProduto);
            return Ok(comprador);
        }


        [HttpDelete("DeletarProduto")]
        public async Task<ActionResult<ProdutoModel>> DeletarProduto(int idProduto)
        {
            bool Deletado = await _produtoRepositorio.DeletarProduto(idProduto);
            return Ok(Deletado);
        }
    }
}