using Microsoft.AspNetCore.Mvc;

namespace ClienteAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiposDocumentosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new[] { "DNI", "RUC", "PASAPORTE" });
        }
    }
}
