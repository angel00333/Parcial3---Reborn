using System.ComponentModel.DataAnnotations;

namespace Parcial3_Aeropuerto.Models
{
    public class Rol
    {
        public int Id_rol { get; set; }

        [Required(ErrorMessage = "El Rol es requerido")]
        public string Nombre_rol { get; set; } = string.Empty;

    }
}
