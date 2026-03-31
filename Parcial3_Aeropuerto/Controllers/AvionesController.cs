using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Parcial3_Aeropuerto.Models; // Agrega esta línea para incluir el espacio de nombres de tu modelo

namespace Parcial3_Aeropuerto.Controllers
{
    public class AvionesController : Controller
    {
        // GET: Aviones
        public ActionResult Aviones(string buscar)
        {
            if (string.IsNullOrEmpty(buscar))
            {
                return View(AvionesDAL.MostrarAviones());
            }
            var resultado = AvionesDAL.BuscarAviones(buscar);
            return View(resultado);
        }

        // GET: Aviones/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Aviones/Create
        public ActionResult Create()
        {
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
                AvionesDAL.InsertarAviones(aviones);
                return RedirectToAction("Aviones");
            }
            return View();
        }

        // GET: Aviones/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Aviones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Aviones/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Aviones/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
