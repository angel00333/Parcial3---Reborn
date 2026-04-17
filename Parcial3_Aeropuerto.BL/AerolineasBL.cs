using System;
using System.Collections.Generic;
using System.Text;

using Parcial3_Aeropuerto.EN;
using Parcial3_Aeropuerto.DAL;

namespace Parcial3_Aeropuerto.BL
{
    public class AerolineasBL
    {
        public int AgregarAerolineas(Aerolineas aerolineas)
        {
            return AerolineasDAL.AgregarAerolineas(aerolineas);
        }

        public int ModificarAerolineas(Aerolineas aerolineas)
        {
            return AerolineasDAL.ModificarAerolineas(aerolineas);
        }

        public int EliminarAerolineas(int id)
        {
            return AerolineasDAL.EliminarAerolineas(id);
        }

        public List<Aerolineas> BuscarAerolineas(string criterio)
        {
            return AerolineasDAL.BuscarAerolineas(criterio);
        }

        public List<Aerolineas> MostrarAerolineas()
        {
            return AerolineasDAL.MostrarAerolineas();
        }

        public Aerolineas ObtenerAerolineasPorId(int id)
        {
            return AerolineasDAL.ObtenerAerolineasPorId(id);
        }
    }
}
