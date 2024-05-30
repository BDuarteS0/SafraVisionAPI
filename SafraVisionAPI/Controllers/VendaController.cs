using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafraVisionAPI.Models;

namespace SafraVisionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<VendaModel>> BuscarTodasVendas()
        {
            return Ok();
        }
    }
}
