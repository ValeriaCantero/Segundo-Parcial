using Microsoft.AspNetCore.Mvc;
using Servicios.ContactosService;

namespace API_Parcial.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CiudadController : ControllerBase
    {
        private const string connectionString = ("Server=localhost;Port=5432;UserId=postgres;Password=03postgres;Database=PrimerParcial;");
        private CiudaddService servicio;

        public CiudadController()
        {
            servicio = new CiudaddService (connectionString);
        }

       /* [HttpGet("por ruta/{id}")]
        public IActionResult ObtenerCiudadAccion([FromRoute] int id)
        {
            var ciudad = servicio.obtenerCiudad(id);
            return Ok(ciudad);
        } */

        [HttpGet("PorParámetro")]
        public IActionResult ObtenerCiudadAccion2([FromQuery] int id)
        {
            var ciudad = servicio.obtenerCiudad(id);
            return Ok(ciudad);
        }

        [HttpPost("RegistrarCiudad")]
        public IActionResult InsertarCiudadAccion([FromBody] Infraestructura.Modelos.CiudaddModel ciudadd)
        {
            servicio.insertarCiudad(ciudadd);
            return Ok("Se creó con éxito el registro");
        }

        [HttpPut("ModificarCiudad")]
        public IActionResult ModificarCiudadAccion([FromBody] Infraestructura.Modelos.CiudaddModel ciudadd)
        {
            servicio.modificarCiudad(ciudadd);
            return Ok("El registro se modificó con éxito");
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarCiudad(int id)
        {
            return Ok("El registro se borró correctamente");
        }
    }
}
