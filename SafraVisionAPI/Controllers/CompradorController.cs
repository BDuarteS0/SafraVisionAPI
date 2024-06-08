using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafraVisionAPI.Models;

namespace SafraVisionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompradorController : ControllerBase
    {
        [HttpGet("BuscarTodosCommpradores")]
        public ActionResult<List<CompradorModel>> BuscarTodosCompradores()
        {
            return Ok();
        }
    } 
}
 