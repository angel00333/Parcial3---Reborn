using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcial3_Aeropuerto.Models;

namespace Parcial3_Aeropuerto.Controllers
{
    public class AeropuertosController : Controller
    {
        // GET: AeropuertosController
        public ActionResult Aeropuertos(string buscar)
        {
            if (string.IsNullOrEmpty(buscar))
            {
                return View(AeropuertosDAL.MostrarAeropuertos());
            }
            var resultado = AeropuertosDAL.BuscarAeropuertos(buscar);
            return View(resultado);



        }

        // GET: AeropuertosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AeropuertosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AeropuertosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: AeropuertosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AeropuertosController/Edit/5
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

        // GET: AeropuertosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AeropuertosController/Delete/5
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
