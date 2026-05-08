using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//alertas XD
using System.Text;

namespace Parcial3_Aeropuerto.EN
{
    public class Aviones
    {
        public int Id_avion { get; set; }

        [Required(ErrorMessage = "El campo Capacidad es obligatorio")]

        [Range(5, 853, ErrorMessage = "La capacidad debe estar entre 5 y 853 pasajeros")]
        public int? Capacidad { get; set; }

        [Required(ErrorMessage = "Seleccione una aerolínea válida")]
        public int? Id_aerolinea { get; set; }

       
        public Aerolineas? Aerolineas { get; set; }
       
        public Aviones () { }

        public Aviones(int id_avion, Aerolineas pAerolineas , int capacidad, int id_aerolinea)
        {
            Id_avion = id_avion;
            Capacidad = capacidad;
            Id_aerolinea = id_aerolinea;
           
        }
    }
}
