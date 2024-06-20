using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafraVisionAPI.Models;
using SafraVisionAPI.Repositorios.Interfaces;

namespace SafraVisionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        [HttpGet("BuscarTodosClientes")]
        public async Task<ActionResult<List<ClienteModel>>> BuscarTodosClientes()
        {
            List<ClienteModel> clientes = await _clienteRepositorio.BuscarTodosClientes();
            return Ok(clientes);
        }

        [HttpGet("BuscarClientePorId")]
        public async Task<ActionResult<ClienteModel>> BuscarClientePorId(int idCliente)
        {
            ClienteModel cliente = await _clienteRepositorio.BuscarClientePorId(idCliente);
            return Ok(cliente);
        }

        [HttpPost("InserirCliente")]
        public async Task<ActionResult<ClienteModel>> InserirCliente([FromBody]ClienteModel clienteModel)
        {
            ClienteModel cliente = await _clienteRepositorio.InserirCliente(clienteModel);
            return Ok(cliente);
        
        }

        [HttpPut("AtualizarCliente")]
        public async Task<ActionResult<ClienteModel>> AtualizarCliente([FromBody]ClienteModel clienteModel, int idCliente)
        {
            ClienteModel cliente = await _clienteRepositorio.AtualizarCliente(clienteModel, idCliente);
            return Ok(cliente);
        }


        [HttpDelete("DeletarCliente")]
        public async Task<ActionResult<ClienteModel>> DeletarCliente(int idCliente)
        {
            bool Deletado = await _clienteRepositorio.DeletarCliente(idCliente);
            return Ok(Deletado);
        }
    } 
}
 