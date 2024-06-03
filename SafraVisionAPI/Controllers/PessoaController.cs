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

        [HttpGet("{BuscarTodasPessoas}")]
        public async Task<ActionResult<List<PessoaModel>>> BuscarTodasPessoas()
        {
            List<PessoaModel>pessoas = await _pessoaRepositorio.BuscarTodasPessoas();
            return Ok(pessoas);
        }

        [HttpGet("{idPessoa}")]
        public async Task<ActionResult<PessoaModel>> BuscarPessoaPorId(int idPessoa)
        {
            PessoaModel pessoa = await _pessoaRepositorio.BuscarPessoaPorId(idPessoa);
            return Ok(pessoa);
        }
        [HttpPost]
        public async Task<ActionResult<PessoaModel>> InserirPessoa([FromBody] PessoaModel pessoaModel)
        {
            PessoaModel pessoa = await _pessoaRepositorio.InserirPessoa(pessoaModel);
            return Ok(pessoa);
        }

    }
}
