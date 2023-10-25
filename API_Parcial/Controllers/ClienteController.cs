using Microsoft.AspNetCore.Mvc;
using Servicios.ContactosService;

namespace API_Parcial.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ClienteController : ControllerBase
    {
        private const string connectionString = ("Server=localhost;Port=5432;UserId=postgres;Password=03postgres;Database=PrimerParcial;");
        private ClienteService servicio;

        public ClienteController()
        {
            servicio = new ClienteService(connectionString);
        }

        [HttpGet("PorParámetro")]
        public IActionResult ObtenerClienteAccion([FromQuery] int id)
        {
            var cliente = servicio.obtenerCliente(id);
            return Ok(cliente);
        }

       

        [HttpPost("RegistrarCliente")]
        public IActionResult RegistrarClienteBasico([FromBody] Modelos.ClienteModelo modelo)
        {
            servicio.insertarCliente(
                new Infraestructura.Modelos.ClienteModel
                {
                    idCliente = modelo.idCliente,
                    fechaIngreso = modelo.fechaIngreso,
                    calificacion = modelo.calificacion,
                    estado = modelo.estado,
                    persona = new Infraestructura.Modelos.PersonaModel
                    {
                        idpersona = modelo.idPersona
                    }
                });
            return Ok("Los datos de persona fueron insertados correctamente");
        }

        [HttpPut("ModificarCliente")]
        public IActionResult ModificarClienteAccion([FromBody] Infraestructura.Modelos.ClienteModel cliente)
        {
            servicio.modificarCliente(cliente);
            return Ok("El registro se modificó con éxito");
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarCliente(int id)
        {
            return Ok("El registro se borró correctamente");
        }
    }
}
