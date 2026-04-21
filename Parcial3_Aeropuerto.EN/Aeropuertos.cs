using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Parcial3_Aeropuerto.EN
{
    public class Aeropuertos
    {
        public int Id_aeropuerto { get; set; }



        [Required(ErrorMessage = "El nombre de la aeropuerto es obligatorio")]

        public string Nombre_aeropuerto { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo pais es obligatorio")]
         public string Pais { get; set; } = string.Empty;

        public Aeropuertos () { }

        public Aeropuertos(int id_aeropuerto, string nombre_aeropuerto, string pais)
        {
            Id_aeropuerto = id_aeropuerto;
            Nombre_aeropuerto = nombre_aeropuerto;
            Pais = pais;
        }

    }
}
