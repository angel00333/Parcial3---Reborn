using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Parcial3_Aeropuerto.BL;
using Parcial3_Aeropuerto.EN;

namespace Parcial3_Aeropuerto.Controllers
{
    public class ReservasController : Controller
    {
        ReservasBL reservasBL = new ReservasBL();
        // GET: ReservasController
        public ActionResult Reservas()
        {
            return View(reservasBL.MostrarReservas());
        }

        // GET: ReservasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReservasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReservasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reservas reservas)
        {
            if(ModelState.IsValid)
            {
                reservasBL.AgregarReservas(reservas);
                return RedirectToAction("Reservas");
            }
            return View(reservas);
        }

        // GET: ReservasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservasController/Edit/5
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

        // GET: ReservasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservasController/Delete/5
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
