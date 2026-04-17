using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
namespace Parcial3_Aeropuerto.EN
{
    public class Vuelos
    {
        public int Id_vuelo { get; set; }

        public Aviones Aviones { get; set; }

        public Destinos Destinos { get; set; }

        [Required(ErrorMessage = "La cantidad de pasajeros es obligatoria.")]
        public int Cantidad_pasajeros { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]

        public DateOnly Fecha { get; set; }

        [Required(ErrorMessage = "El tiempo estimado es obligatorio.")]

        public DateTime Tiempo_estimado { get; set; }

        public string Estado { get; set; } = string.Empty;

        public TimeOnly Hora_inicio { get; set; } = TimeOnly.FromDateTime(DateTime.Now);

        public Vuelos () { }

        public Vuelos(int id_vuelo, Aviones pAviones, Destinos pDestinos, int cantidad_pasajeros, DateOnly fecha, DateTime tiempo_estimado, string estado, TimeOnly hora_inicio)
        {
            Id_vuelo = id_vuelo;
            Aviones = pAviones;
            Destinos = pDestinos;
            Cantidad_pasajeros = cantidad_pasajeros;
            Fecha = fecha;
            Tiempo_estimado = tiempo_estimado;
            Estado = estado;
            Hora_inicio = hora_inicio;
        }

    }
}
