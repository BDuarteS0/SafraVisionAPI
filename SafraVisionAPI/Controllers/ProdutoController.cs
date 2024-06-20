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
            List<ProdutoModel> clientees = await _produtoRepositorio.BuscarTodosProdutos();
            return Ok(clientees);
        }

        [HttpGet("BuscarProdutoPorId")]
        public async Task<ActionResult<ProdutoModel>> BuscarProdutoPorId(int idProduto)
        {
            ProdutoModel cliente = await _produtoRepositorio.BuscarProdutoPorId(idProduto);
            return Ok(cliente);
        }

        [HttpPost("InserirProduto")]
        public async Task<ActionResult<ProdutoModel>> InserirProduto([FromBody] ProdutoModel produtoModel)
        {
            ProdutoModel cliente = await _produtoRepositorio.InserirProduto(produtoModel);
            return Ok(cliente);

        }

        [HttpPut("AtualizarProduto")]
        public async Task<ActionResult<ProdutoModel>> AtualizarProduto([FromBody] ProdutoModel produtoModel, int idProduto)
        {
            ProdutoModel cliente = await _produtoRepositorio.AtualizarProduto(produtoModel, idProduto);
            return Ok(cliente);
        }


        [HttpDelete("DeletarProduto")]
        public async Task<ActionResult<ProdutoModel>> DeletarProduto(int idProduto)
        {
            bool Deletado = await _produtoRepositorio.DeletarProduto(idProduto);
            return Ok(Deletado);
        }
    }
}