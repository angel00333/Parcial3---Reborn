using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using MySqlConnector;
using Parcial3_Aeropuerto.BL;
using Parcial3_Aeropuerto.EN; // Agrega esta línea para incluir el espacio de nombres de tu modelo

namespace Parcial3_Aeropuerto.Controllers
{
    public class AvionesController : Controller
    {
        AerolineasBL aerolineasBL = new AerolineasBL();
        AvionesBL avionesBL = new AvionesBL();
        // GET: Aviones
        public ActionResult Aviones(string buscar)
        {
            if (string.IsNullOrEmpty(buscar))
            {
                return View(avionesBL.MostrarAviones());
            }
            var resultado = avionesBL.BuscarAviones(buscar);
            return View(resultado);
        }

        // GET: Aviones/Details/5
        public ActionResult Details(int id)
        {
            return View(avionesBL.ObtenerAvionesPorId(id));
        }

        // GET: Aviones/Create
        public ActionResult Create()
        {
            //Se extrae la vista de Aerolineas hacia aviones/ GET
            ViewBag.Aerolineas = aerolineasBL.MostrarAerolineas();
            return View();
        }

        // POST: Aviones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aviones aviones)
        {
            ModelState.Remove("Id_avion");
            if (ModelState.IsValid)
            {
                avionesBL.AgregarAviones(aviones);
                return RedirectToAction("Aviones");
            }
            return View();
        }

        // GET: Aviones/Edit/5
        public ActionResult Edit(int id)
        {
            return View(avionesBL.ObtenerAvionesPorId(id));
        }

        // POST: Aviones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aviones aviones)
        {
            if (ModelState.IsValid)
            {
                avionesBL.ModificarAviones(aviones);
                return RedirectToAction("Aviones");
            }
            return View();
        }

        // GET: Aviones/Delete/5
        public ActionResult Delete(int id)
        {
            return View(avionesBL.ObtenerAvionesPorId(id));

        }

        // POST: Aviones/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Aviones aviones)
        {
            avionesBL.EliminarAviones(aviones.Id_avion);
            return RedirectToAction("Aviones");

        }
    }
}
