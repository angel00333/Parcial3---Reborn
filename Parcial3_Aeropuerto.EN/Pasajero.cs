using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
namespace Parcial3_Aeropuerto.EN
{
    public class Pasajero
    {
        public int Id_pasajero { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre solo puede contener letras y espacios.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El apellido solo puede contener letras y espacios.")]
        public string Apellido { get; set; } = string.Empty;

        public string Pasaporte { get; set; } = string.Empty;

        [Required(ErrorMessage = "La edad es obligatoria.")]
        [Range(1, 100, ErrorMessage = "La edad debe estar entre 0 y 100.")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El país es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El país solo puede contener letras y espacios.")]
        public string Pais { get; set; } = string.Empty;

        public string Visa { get; set; } = string.Empty;

        public Pasajero () { }

        public Pasajero(int id_pasajero, string nombre, string apellido, string pasaporte, int edad, string pais, string visa)
        {
            Id_pasajero = id_pasajero;
            Nombre = nombre;
            Apellido = apellido;
            Pasaporte = pasaporte;
            Edad = edad;
            Pais = pais;
            Visa = visa;
        }
    }
}
