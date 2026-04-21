using System;
using System.Collections.Generic;
using System.Text;


using System.ComponentModel.DataAnnotations;
namespace Parcial3_Aeropuerto.EN
{
    public class Login
    {
        public int Id_usuario { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string Nombre_usuario { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Contraseña { get; set; }
        public int Id_rol { get; set; }
        public string Nombre_rol { get; set; } 
    }
}
