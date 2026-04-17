using System.ComponentModel.DataAnnotations;

namespace Parcial3_Aeropuerto.EN
{
    public class Rol
    {
        public int Id_rol { get; set; }

        [Required(ErrorMessage = "El Rol es requerido")]
        public string Nombre_rol { get; set; } = string.Empty;

        public Rol() { }

        public Rol(int id_rol, string nombre_rol)
        {
            Id_rol = id_rol;
            Nombre_rol = nombre_rol;
        }

    }
}
