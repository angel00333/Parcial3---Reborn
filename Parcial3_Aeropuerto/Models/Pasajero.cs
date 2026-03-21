using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.ComponentModel.DataAnnotations;

namespace Parcial3_Aeropuerto.Models
{
    public class Pasajero
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string Apellido { get; set; }

        public string Pasaporte { get; set; }

        [Required(ErrorMessage = "La edad es obligatoria.")]

        [Range(0, 100, ErrorMessage = "La edad debe estar entre 0 y 100.")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El pais es obligatorio.")]

        public string Pais { get; set; }

        public string Visa { get; set; }

    }
}
