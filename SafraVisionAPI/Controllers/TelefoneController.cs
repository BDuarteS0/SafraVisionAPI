using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafraVisionAPI.Models;

namespace SafraVisionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<TelefoneModel>> BuscarTodosTelefones()
        {
            return Ok();
        }
    }
}
