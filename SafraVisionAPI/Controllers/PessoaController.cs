using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SafraVisionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Models.PessoaModel>> BuscarTodasPessoas()
        {
            return Ok();
        }

    }
}
