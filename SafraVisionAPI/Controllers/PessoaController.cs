using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafraVisionAPI.Repositorios;
using SafraVisionAPI.Repositorios.Interfaces;
using SafraVisionAPI.Models;

namespace SafraVisionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;
        public PessoaController(IPessoaRepositorio pessoaRepositorio) 
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PessoaModel>>> BuscarTodasPessoas()
        {
            List<PessoaModel>pessoas = await _pessoaRepositorio.BuscarTodasPessoas();
            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaModel>> BuscarPessoaPorId(int idPessoa)
        {
            PessoaModel pessoa = await _pessoaRepositorio.BuscarPessoaPorId(idPessoa);
            return Ok(pessoa);
        }

    }
}
