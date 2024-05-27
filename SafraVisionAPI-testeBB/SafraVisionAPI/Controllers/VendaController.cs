using Microsoft.AspNetCore.Mvc;
using SafraVisionAPI.Models;
using SafraVisionAPI.Repositorios.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<ActionResult<List<VendaModel>>> BuscarTodasVendas()
        {
            var vendas = await _vendaRepositorio.BuscarTodasVendas();
            return Ok(vendas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VendaModel>> BuscarVendaPorId(int id)
        {
            var venda = await _vendaRepositorio.BuscarVendaPorId(id);
            if (venda == null)
            {
                return NotFound();
            }
            return Ok(venda);
        }

        [HttpPost]
        public async Task<ActionResult<VendaModel>> InserirVenda(VendaModel venda)
        {
            var novaVenda = await _vendaRepositorio.InserirVenda(venda);
            return CreatedAtAction(nameof(BuscarVendaPorId), new { id = novaVenda.Id }, novaVenda);
        }
    }
}