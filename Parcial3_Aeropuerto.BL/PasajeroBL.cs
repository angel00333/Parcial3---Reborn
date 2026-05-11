using System;
using System.Collections.Generic;
using System.Text;

using Parcial3_Aeropuerto.EN;
using Parcial3_Aeropuerto.DAL;

namespace Parcial3_Aeropuerto.BL
{
    public class PasajeroBL
    {
        public int AgregarPasajero(Pasajero pasajero)
        {
            return PasajeroDAL.AgregarPasajero(pasajero);
        }

        public int ModificarPasajero(Pasajero pasajero)
        {
            return PasajeroDAL.ModificarPasajero(pasajero);
        }

        public int EliminarPasajero(int id)
        {
            return PasajeroDAL.EliminarPasajero(id);
        }

        public List<Pasajero> BuscarPasajeros(string criterio)
        {
            return PasajeroDAL.BuscarPasajeros(criterio);
        }

        public List<Pasajero> MostrarPasajeros()
        {
            return PasajeroDAL.MostrarPasajeros();
        }

        public Pasajero ObtenerPasajeroPorId(int id)
        {
            return PasajeroDAL.ObtenerPasajeroPorId(id);
        }

        public bool PasajeroTieneReservas(int id)
        {
            return PasajeroDAL.PasajeroTieneReserva(id);
        }
    }
}
