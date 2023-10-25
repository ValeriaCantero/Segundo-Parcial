using Infraestructura.Modelos;

namespace API_Parcial.Modelos
{
    public class ClienteModelo
    {
        public int idCliente { get; set; }
        public DateTime fechaIngreso { get; set; }
        public string calificacion { get; set; }
        public string estado { get; set; }
        public int idPersona { get; set; }
    }
}
