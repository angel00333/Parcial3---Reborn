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

        
    }
}
