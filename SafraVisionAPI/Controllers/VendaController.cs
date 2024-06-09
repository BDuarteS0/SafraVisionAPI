using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafraVisionAPI.Models;
using SafraVisionAPI.Repositorios.Interfaces;

namespace SafraVisionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {

        private readonly IVendaRepositorio _vendaRepositorio;
        public VendaController(IVendaRepositorio vendaRepositorio)
        {
            _vendaRepositorio = vendaRepositorio;
        }

        [HttpGet("BuscarTodasVendas")]
        public async Task<ActionResult<List<VendaModel>>> BuscarTodasVendas()
        {
            List<VendaModel> vendaes = await _vendaRepositorio.BuscarTodasVendas();
            return Ok(vendaes);
        }

        [HttpGet("BuscarVendaPorId")]
        public async Task<ActionResult<VendaModel>> BuscarVendaPorId(int idVenda)
        {
            VendaModel venda = await _vendaRepositorio.BuscarVendaPorId(idVenda);
            return Ok(venda);
        }

        [HttpPost("InserirVenda")]
        public async Task<ActionResult<VendaModel>> InserirVenda([FromBody] VendaModel vendaModel)
        {
            VendaModel venda = await _vendaRepositorio.InserirVenda(vendaModel);
            return Ok(venda);

        }

        [HttpPut("AtualizarVenda")]
        public async Task<ActionResult<VendaModel>> AtualizarVenda([FromBody] VendaModel vendaModel, int idVenda)
        {
            VendaModel venda = await _vendaRepositorio.AtualizarVenda(vendaModel, idVenda);
            return Ok(venda);
        }


        [HttpDelete("DeletarVenda")]
        public async Task<ActionResult<VendaModel>> Deletarvenda(int idVenda)
        {
            bool Deletado = await _vendaRepositorio.DeletarVenda(idVenda);
            return Ok(Deletado);
        }
    }
}
