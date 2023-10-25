using Microsoft.AspNetCore.Mvc;
using Servicios.ContactosService;

namespace API_Parcial.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PersonaController : ControllerBase
    {
        private const string connectionString = ("Server=localhost;Port=5432;UserId=postgres;Password=03postgres;Database=PrimerParcial;");
        private PersonaService servicio;

        public PersonaController()
        {
            servicio = new PersonaService (connectionString);
        }


        [HttpGet("PorParámetro")]
        public IActionResult ObtenerPersonaAccion2([FromQuery] int id)
        {
            var persona = servicio.obtenerPersona(id);
            return Ok(persona);
        }

        
        [HttpPost("RegistrarPersona")]
        public IActionResult RegistrarPersonaBasico([FromBody] Modelos.PersonaModelo modelo)
        {
            servicio.insertarPersona(
                new Infraestructura.Modelos.PersonaModel
                {
                    idpersona= modelo.idpersona,
                    nombre = modelo.nombre,
                    apellido = modelo.apellido,
                    tipoDocumento= modelo.tipoDocumento,
                    nroDocumento = modelo.nroDocumento,
                    direccion = modelo.direccion,
                    email = modelo.email,
                    celular = modelo.celular,
                    estado = modelo.estado,
                    ciudadd  = new Infraestructura.Modelos.CiudaddModel
                    {
                        idCiudad = modelo.idciudad
                    }
                });
            return Ok("Los datos de persona fueron insertados correctamente");
        } 
        

        [HttpPut("ModificarPersona")]
        public IActionResult ModificarPersonaAccion([FromBody] Infraestructura.Modelos.PersonaModel persona)
        {
            servicio.modificarPersona(persona);
            return Ok("El registro se modificó con éxito");
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarPersona(int id)
        {
            return Ok("El registro se borró correctamente");
        }


    }
}
