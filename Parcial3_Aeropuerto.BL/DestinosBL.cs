using System;
using System.Collections.Generic;
using System.Text;

using Parcial3_Aeropuerto.EN;
using Parcial3_Aeropuerto.DAL;


namespace Parcial3_Aeropuerto.BL
{
    public class DestinosBL
    {
        public int AgregarDestino(Destinos destinos)
        {
            return DestinosDAL.AgregarDestino(destinos);
        }

        public int ModificarDestino(Destinos destinos)
        {
            return DestinosDAL.ModificarDestino(destinos);
        }

        public int EliminarDestino(int id)
        {
            return DestinosDAL.EliminarDestino(id);
        }

        public List<Destinos> BuscarDestinos(string criterio)
        {
            return DestinosDAL.BuscarDestinos(criterio);
        }

        public List<Destinos> MostrarDestinos()
        {
            return DestinosDAL.MostrarDestinos();
        }

        public Destinos ObtenerDestinosPorId(int id)
        {
            return DestinosDAL.ObtenerDestinoPorId(id);
        }

    }
}
