using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace Parcial3_Aeropuerto.EN
{
    public class Vuelos
    {
        public int Id_vuelo { get; set; }

        public int Id_avion { get; set; }

        public int Id_destino { get; set; }

        
        [Range(0, int.MaxValue, ErrorMessage = "Error inesperado")]
        public int Cantidad_pasajeros { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "La fecha debe ser una fecha válida.")]
        public DateOnly Fecha { get; set; }

        [Required(ErrorMessage = "El tiempo estimado es obligatorio.")]
        [DataType(DataType.Time, ErrorMessage = "El tiempo estimado debe ser una hora válida.")]
        public TimeOnly Tiempo_estimado { get; set; }

        public string Estado { get; set; } = string.Empty;

        public TimeOnly Hora_inicio { get; set; } = TimeOnly.FromDateTime(DateTime.Now);

        public Vuelos () { }

        public Vuelos(int id_vuelo, int id_avion, int id_destino, int cantidad_pasajeros, DateOnly fecha, TimeOnly tiempo_estimado, string estado, TimeOnly hora_inicio)
        {
            Id_vuelo = id_vuelo;
            Id_avion = id_avion;
            Id_destino = id_destino;
            Cantidad_pasajeros = cantidad_pasajeros;
            Fecha = fecha;
            Tiempo_estimado = tiempo_estimado;
            Estado = estado;
            Hora_inicio = hora_inicio;
        }

    }
}
