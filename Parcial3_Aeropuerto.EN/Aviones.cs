using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;//alertas XD

namespace Parcial3_Aeropuerto.EN
{
    public class Aviones
    {
        public int Id_avion { get; set; }

        [Required(ErrorMessage = "El campo I_aerolineas es obligatorio")]
        public Aerolineas Aerolineas { get; set; }

        [Required(ErrorMessage = "El campo Capacidad es obligatorio")]
        public int Capacidad { get; set; }

        public string Nombre_aerolinea { get; set; } = string.Empty;
        //SE hace el mmado del nombre de la aerolinea

        public Aviones () { }

        public Aviones(int id_avion, Aerolineas pAerolineas , int capacidad, string nombre_aerolinea)
        {
            Id_avion = id_avion;
            Aerolineas = pAerolineas;
            Capacidad = capacidad;
            Nombre_aerolinea = nombre_aerolinea;
        }
    }
}
