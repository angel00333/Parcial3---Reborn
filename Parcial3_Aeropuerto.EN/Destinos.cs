using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
namespace Parcial3_Aeropuerto.EN
{
    public class Destinos
    {
        public int Id_destino { get; set; }

        public Aeropuertos Aeropuertos { get; set; }

        public string Nombre_destino { get; set; }
        public Aeropuertos Id_aeropuerto { get; set; }

        public Destinos() { }

        public Destinos(int id_destino, Aeropuertos pAeropuertos, string nombre_destino)
        {
            Id_destino = id_destino;
            Aeropuertos = pAeropuertos;
            Nombre_destino = nombre_destino;
        }

    }
}
