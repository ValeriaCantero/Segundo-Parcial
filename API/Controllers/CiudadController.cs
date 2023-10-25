
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("Controller[")]
    public class CiudadController: ControllerBase
    {
        public CiudadController() 
        {
        }
        [HttpGet]
        public IActionResult ObtenerCiudadAccion()
        {
            return Ok("Texto de prueba");
        }

    }
}
