using System.Collections.Generic;
namespace Parcial3_Aeropuerto.Models
{
    public class Paginacion<T>
    {
        public List<T> Items { get; set; }
        public int PaginaActual { get; set; }
        public int TotalPaginas { get; set; }
    }
}
