using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Parcial3_Aeropuerto.Models;

namespace Parcial3_Aeropuerto.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string Saludo = "";
            DateTime HoraActual = DateTime.Now;
            if (HoraActual.Hour < 12)
            {
                Saludo = "Buenos días";
            }
            else if (HoraActual.Hour < 18)
            {
                Saludo = "Buenas tardes";
            }
            else
            {
                Saludo = "Buenas noches";
            }

            ViewBag.Saludo = Saludo;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
