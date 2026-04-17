using System;
using System.Collections.Generic;
using System.Text;

using Parcial3_Aeropuerto.EN;
using Parcial3_Aeropuerto.DAL;

namespace Parcial3_Aeropuerto.BL
{
    public class VuelosBL
    {
        public int AgregarVuelos(Vuelos vuelos)
        {
            return VuelosDAL.AgregarVuelo(vuelos);
        }

        public int ModificarVuelos(Vuelos vuelos)
        {
            return VuelosDAL.ModificarVuelo(vuelos);
        }

        public int EliminarVuelos(int id)
        {
            return VuelosDAL.EliminarVuelo(id);
        }

        public List<Vuelos> BuscarVuelos(string criterio)
        {
            return VuelosDAL.BuscarVuelos(criterio);
        }

        public List<Vuelos> MostrarVuelos()
        {
            return VuelosDAL.MostrarVuelos();
        }

        public Vuelos ObtenerVuelosPorId(int id)
        {
            return VuelosDAL.ObtenerVueloPorId(id);
        }
    }
}
