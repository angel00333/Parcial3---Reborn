using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
namespace Parcial3_Aeropuerto.EN
{
    public class Destinos
    {
        public int Id_destino { get; set; }

        [Required(ErrorMessage = "El campo Id_aeropuerto es obligatorio.")]
        public int? Id_aeropuerto { get; set; }

        [Required(ErrorMessage = "El campo Destino es obligatorio.")]
        public string Nombre_destino { get; set; }
        public string Nombre_aeropuerto { get; set; } = string.Empty;


        public Destinos() { }

        public Destinos(int id_destino, int id_aeropuerto, string nombre_destino, string nombre_aeropuerto)
        {
            Id_destino = id_destino;
            Id_aeropuerto = id_aeropuerto;
            Nombre_destino = nombre_destino;
            Nombre_aeropuerto = nombre_aeropuerto;
        }

    }
}
