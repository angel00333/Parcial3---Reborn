using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Parcial3_Aeropuerto.EN
{
    public class Aerolineas
    {
        public int Id_aerolinea { get; set; }

        [Required(ErrorMessage = "El nombre de la aero linea es requerido")]
        public string Nombre_aerolinea { get; set; } = string.Empty; //Permite que el valor entre vacio sin restriccion.

        public Aerolineas() { }

        public Aerolineas(int id_aerolinea, string nombre_aerolinea)
        {
            Id_aerolinea = id_aerolinea;
            Nombre_aerolinea = nombre_aerolinea;

        }
    }
}
