using System.ComponentModel.DataAnnotations;

namespace Parcial3_Aeropuerto.EN
{
    public class Reservas
    {
        public int Id_reserva { get; set; }

        public int Id_pasajero { get; set; }

        public int Id_vuelo { get; set; }

        [Required (ErrorMessage = "La fecha de reserva es obligatoria.")]
        public DateOnly Fecha { get; set; }

        [Required (ErrorMessage = "El costo de la reserva es obligatorio.")]

        [Range(0, double.MaxValue, ErrorMessage ="No se permiten números negativos")]
        public double Costo { get; set; }

        public int Id_usuario { get; set; }
    }
}
