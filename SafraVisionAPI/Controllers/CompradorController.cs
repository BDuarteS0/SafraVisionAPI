using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafraVisionAPI.Models;
using SafraVisionAPI.Repositorios.Interfaces;

namespace SafraVisionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompradorController : ControllerBase
    {
        private readonly ICompradorRepositorio _compradorRepositorio;
        public CompradorController(ICompradorRepositorio compradorRepositorio)
        {
            _compradorRepositorio = compradorRepositorio;
        }

        [HttpGet("BuscarTodosCommpradores")]
        public async Task<ActionResult<List<CompradorModel>>> BuscarTodosCompradores()
        {
            List<CompradorModel> compradores = await _compradorRepositorio.BuscarTodosCompradores();
            return Ok(compradores);
        }

        [HttpGet("BuscarCompradorPorId")]
        public async Task<ActionResult<CompradorModel>> BuscarCompradorPorId(int idComprador)
        {
            CompradorModel comprador = await _compradorRepositorio.BuscarCompradorPorId(idComprador);
            return Ok(comprador);
        }

        [HttpPost("InserirComprador")]
        public async Task<ActionResult<CompradorModel>> InserirComprador([FromBody]CompradorModel compradorModel)
        {
            CompradorModel comprador = await _compradorRepositorio.InserirComprador(compradorModel);
            return Ok(comprador);
        
        }
        [HttpDelete("DeletarComprador")]
        public async Task<ActionResult<CompradorModel>> DeletarComprador(int idComprador)
        {
            bool Deletado = await _compradorRepositorio.DeletarComprador(idComprador);
            return Ok(Deletado);
        }
    } 
}
 