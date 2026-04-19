using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
namespace Parcial3_Aeropuerto.EN
{
    public class Facturacion
    {
        public int Id_Facturacion { get; set; }

        public DateOnly Fecha { get; set; }

        public double Monto { get; set; }

        public Facturacion () { }

        public Facturacion(int id_Facturacion, DateOnly fecha, double monto)
        {
            Id_Facturacion = id_Facturacion;
            Fecha = fecha;
            Monto = monto;
        }
    }
}
