using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;//alertas XD

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


        public string Nombre_aerolinea { get; set; } = string.Empty;
        //SE hace el mmado del nombre de la aerolinea

        public Aviones () { }

        public Aviones(int id_avion, Aerolineas pAerolineas , int capacidad, int id_aerolinea, string nombre_aerolinea)
        {
            Id_avion = id_avion;
            Capacidad = capacidad;
            Id_aerolinea = id_aerolinea;
            Nombre_aerolinea = nombre_aerolinea;
        }
    }
}
