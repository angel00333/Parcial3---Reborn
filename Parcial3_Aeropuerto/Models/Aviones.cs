using System.ComponentModel.DataAnnotations;//alertas XD
namespace Parcial3_Aeropuerto.Models
{
    public class Aviones
    {
        public int Id_avion { get; set; }

        [Required(ErrorMessage = "El campo I_aerolineas es obligatorio")]
        public int Id_aerolinea { get; set; }

        [Required(ErrorMessage = "El campo Capacidad es obligatorio")]
        public int Capacidad { get; set; }

        public string Nombre_aerolinea { get; set; } = string.Empty;
        //SE hace el mmado del nombre de la aerolinea
    }
}
