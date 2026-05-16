using System;
using System.Collections.Generic;
using System.Text;

using Parcial3_Aeropuerto.EN;
using Parcial3_Aeropuerto.DAL;
namespace Parcial3_Aeropuerto.BL
{
    public class FacturacionBL
    {
        public int ModificarFacturacion(Facturacion facturacion)
        {
            return FacturacionDAL.ModificarFacturacion(facturacion);
        }

        public int EliminarFacturacion(int id)
        {
            return FacturacionDAL.EliminarFacturacion(id);

        }

        public Facturacion ObtenerFacturacionPorId(int id)
        {
            return FacturacionDAL.ObtenerFacturacionPorId(id);
        }

        public List<Facturacion> MostrarFacturaciones()
        {
            return FacturacionDAL.MostrarFacturaciones();
        }  
        
        public List<Facturacion> BuscarFacturacion(string criterio)
        {
            return FacturacionDAL.BuscarFacturacion(criterio);
        }
    }
}