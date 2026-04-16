
using MySqlConnector;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data; //libreria para conectar con mysql


namespace Parcial3_Aeropuerto.Models

{
    public class Usuarios
    {
        public int Id_usuario { get; set; }

        [Required(ErrorMessage = "El campo Nombre de Usuario es obligatorio")]
        public string Nombre_usuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo Contraseña de Usuario es obligatorio")]
        public string Contraseña { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo id_Rol es obligatorio")]
        public int Id_rol { get; set; }

        public string Nombre_rol { get; set; }= string.Empty;


    }
}
