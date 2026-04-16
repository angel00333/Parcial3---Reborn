using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
namespace Parcial3_Aeropuerto.EN
{
    public class Paginacion<T>
    {
        public List<T> Items { get; set; }
        public int PaginaActual { get; set; }
        public int TotalPaginas { get; set; }

        public Paginacion () {}

        public Paginacion(List<T> items, int paginaActual, int totalPaginas)
        {
            Items = items;
            PaginaActual = paginaActual;
            TotalPaginas = totalPaginas;
        }
    }
}