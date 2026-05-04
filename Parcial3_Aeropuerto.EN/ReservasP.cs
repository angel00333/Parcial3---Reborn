using System;
using System.Collections.Generic;
using System.Text;

namespace Parcial3_Aeropuerto.EN
{
    public class ReservasP
    {
        public List<Reservas> Reservas { get; set; }
        public List<Pasajero> Pasajero { get; set; }

        public List<Aerolineas> Aerolineas { get; set; }

        public List<Vuelos> Vuelos { get; set; }

        public List<Aviones> Aviones { get; set; } 

        public List<Destinos> Destinos { get; set; }
    }
}
