using System;
using System.Collections.Generic;
using System.Text;

using Parcial3_Aeropuerto.EN;
using Parcial3_Aeropuerto.DAL;

namespace Parcial3_Aeropuerto.BL
{
    public class AvionesBL
    {
        public int AgregarAviones(Aviones aviones)
        {
            return AvionesDAL.AgregarAviones(aviones);
        }

        public int ModificarAviones(Aviones aviones)
        {
            return AvionesDAL.ModificarAviones(aviones);
        }

        public int EliminarAviones(int id)
        {
            return AvionesDAL.EliminarAviones(id);
        }

        public List<Aviones> BuscarAviones(string criterio)
        {
            return AvionesDAL.BuscarAviones(criterio);
        }

        public List<Aviones> MostrarAviones()
        {
            return AvionesDAL.MostrarAviones();
        }

        public Aviones ObtenerAvionesPorId(int id)
        {
            return AvionesDAL.ObtenerAvionesPorId(id);
        }

        public AerolineasBL aerolineasBL = new AerolineasBL();
    }
}
