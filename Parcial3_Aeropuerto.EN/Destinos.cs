using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
namespace Parcial3_Aeropuerto.EN
{
    public class Destinos
    {
        public int Id_destino { get; set; }

        public int Id_aeropuerto { get; set; }

        public string Nombre_destino { get; set; }
        

        public Destinos() { }

        public Destinos(int id_destino, int id_aeropuerto, string nombre_destino)
        {
            Id_destino = id_destino;
            Id_aeropuerto = id_aeropuerto;
            Nombre_destino = nombre_destino;
        }

    }
}
