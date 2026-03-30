using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcial3_Aeropuerto.Models;

namespace Parcial3_Aeropuerto.Controllers
{
    public class PasajeroController : Controller
    {
        // GET: PasajeroController
        public ActionResult Pasajero(string buscar)
        {
            if (string.IsNullOrEmpty(buscar))
            {
                return View(PasajeroDAL.MostrarPasajeros());

            }

            var resultado = PasajeroDAL.BuscarPasajeros(buscar);
            return View(resultado);
        }

        // GET: PasajeroController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PasajeroController/Create
        public ActionResult Create()
        {
            return PartialView("Create");
        }

        // POST: PasajeroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pasajero pasajero)
        {
            try
            {
                PasajeroDAL.AgregarPasajero(pasajero);
                return RedirectToAction(nameof(Pasajero));
            }
            catch
            {
                return PartialView("Create", pasajero);
            }
        }

        // GET: PasajeroController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PasajeroController/Edit/5
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

        // GET: PasajeroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PasajeroController/Delete/5
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
