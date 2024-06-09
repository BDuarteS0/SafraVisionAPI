using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafraVisionAPI.Models;
using SafraVisionAPI.Repositorios;
using SafraVisionAPI.Repositorios.Interfaces;

namespace SafraVisionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet("BuscarTodosUsuarios")]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarO()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("BuscarUsuarioPorId")]
        public async Task<ActionResult<UsuarioModel>> BuscarusuarioPorId(int idUsuario)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarUsuarioPorId(idUsuario);
            return Ok(usuario);
        }

        [HttpPost("InserirUsuario")]
        public async Task<ActionResult<UsuarioModel>> InserirUsuario([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepositorio.InserirUsuario(usuarioModel);
            return Ok(usuario);

        }

        [HttpPut("AtualizarUsuario")]
        public async Task<ActionResult<UsuarioModel>> AtualizarUsuario([FromBody] UsuarioModel usuarioModel, int idUsuario)
        {
            UsuarioModel usuario = await _usuarioRepositorio.AtualizarUsuario(usuarioModel, idUsuario);
            return Ok(usuario);
        }


        [HttpDelete("DeletarUsuario")]
        public async Task<ActionResult<UsuarioModel>> DeletarUsuario(int idUsuario)
        {
            bool Deletado = await _usuarioRepositorio.DeletarUsuario(idUsuario);
            return Ok(Deletado);
        }

    }
}
