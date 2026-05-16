using System;
using System.Collections.Generic;
using System.Text;

using Parcial3_Aeropuerto.EN;
using Parcial3_Aeropuerto.DAL;
namespace Parcial3_Aeropuerto.BL
{
    public class AeropuertosBL
    {
        public int AgregarAeropuertos(Aeropuertos aeropuertos)
        {
            return AeropuertosDAL.AgregarAeropuertos(aeropuertos);
        }
        public int ModificarAeropuertos(Aeropuertos aeropuertos)
        {
            return AeropuertosDAL.ModificarAropuertos(aeropuertos);
        }
        public int EliminarAeropuertos(int id)
        {
            return AeropuertosDAL.EliminarAeropuertos(id);
        }
        public List<Aeropuertos> BuscarAeropuertos(string criterio)
        {
            return AeropuertosDAL.BuscarAeropuertos(criterio);
        }
        public List<Aeropuertos> MostrarAeropuertos()
        {
            return AeropuertosDAL.MostrarAeropuertos();
        }
        public Aeropuertos ObtenerAeropuertoPorId(int id)
        {
            return AeropuertosDAL.ObtenerAeropuertosPorId(id);
        }

        public bool AeropuertoTieneDestino(int id)
        {
            return AeropuertosDAL.AeropuertoTieneDestino(id);
        }
    }
}
