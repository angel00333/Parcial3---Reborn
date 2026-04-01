using System.ComponentModel.DataAnnotations;

namespace Parcial3_Aeropuerto.Models
{
    public class Aerolineas
    {
        public int Id_aerolinea { get; set; }

        [Required(ErrorMessage = "El nombre de la aero linea es requerido")]
        public string Nombre_aerolinea { get; set; }=string.Empty; //Permite que el valor entre vacio sin restriccion.

    }
}
