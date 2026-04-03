using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcial3_Aeropuerto.Models;
using System.Data;
using MySqlConnector;

namespace Parcial3_Aeropuerto.Controllers
{
    public class AerolineasController : Controller
    {
        // GET: AerolieasController
        public ActionResult Aerolineas(string buscar)
        {
            if (string.IsNullOrEmpty(buscar))
            {
                return View(AerolineasDAL.MostrarAerolineas());
            }

            var resultado = AerolineasDAL.BuscarAerolineas(buscar);
            return View(resultado);

        }

        // GET: AerolieasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AerolieasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AerolieasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aerolineas aerolineas)
        {
            ModelState.Remove("Id_aerolinea");
            if (ModelState.IsValid)
            {
                AerolineasDAL.InsertarAerolineas(aerolineas);
                return RedirectToAction("Aerolineas");
            }

            return View();
          
        }

        // GET: AerolieasController/Edit/5
        public ActionResult Edit(int id)
        {
            var aerolineas = AerolineasDAL.ObtenerAerolineasPorId(id);
            return View(aerolineas);
        }

        // POST: AerolieasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aerolineas aerolineas)
        {
            if (ModelState.IsValid) {
                AerolineasDAL.ModificarAerolineas(aerolineas);
                return RedirectToAction("Aerolineas");

                            
            }
            return View();

        }

        // GET: AerolieasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(AerolineasDAL.ObtenerAerolineasPorId(id));
        }

        // POST: AerolieasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Aerolineas aerolineas)
        {
          AerolineasDAL.EliminarAerolineas(aerolineas.Id_aerolinea);
            return RedirectToAction("Aerolineas");
        }
    }
}
