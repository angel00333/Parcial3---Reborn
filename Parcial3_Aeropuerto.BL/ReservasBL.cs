using System;
using System.Collections.Generic;
using System.Text;

using Parcial3_Aeropuerto.EN;
using Parcial3_Aeropuerto.DAL;
namespace Parcial3_Aeropuerto.BL
{
    public class ReservasBL
    {
        public int AgregarReservas(Reservas reservas)
        {
            return ReservasDAL.AgregarReserva(reservas);
        }
        public int ModificarReservas(Reservas reservas)
        {
            return ReservasDAL.ModificarReserva(reservas);
        }
        public int EliminarReservas(int id)
        {
            return ReservasDAL.EliminarReserva(id);
        }
        public List<Reservas> BuscarReservas(string criterio)
        {
            return ReservasDAL.BuscarReserva(criterio);
        }
        public List<Reservas> MostrarReservas()
        {
            return ReservasDAL.MostrarReservas();
        }
        public Reservas ObtenerReservasPorId(int id)
        {
            return ReservasDAL.ObtenerReservaPorId(id);
        }
    }
}
