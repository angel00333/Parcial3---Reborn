using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data; //libreria para conectar con mysql


namespace Parcial3_Aeropuerto.EN

{
    public class Usuarios
    {
        public int Id_usuario { get; set; }


        [Required(ErrorMessage = "El campo Nombre de Usuario es obligatorio")]
        public string Nombre_usuario { get; set; } 


        [Required(ErrorMessage = "El campo Contraseña de Usuario es obligatorio")]
        public string Contraseña { get; set; }


        [Required(ErrorMessage = "El debe seleccionar Rol es obligatorio")]
        public int? Id_rol { get; set; } 
     
        public string Nombre_rol { get; set; } = string.Empty;

        public Usuarios() { }

        public Usuarios(int id_usuario, string nombre_usuario, string contraseña, int id_rol, string nombre_rol)
        {
            Id_usuario = id_usuario;
            Nombre_usuario = nombre_usuario;
            Contraseña = contraseña;
            Id_rol = id_rol;
            Nombre_rol = nombre_rol;
        }


    }
}
