using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcial3_Aeropuerto.Models;
using System.Data;
using MySqlConnector;

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
        public ActionResult Create(Aeropuertos aeropuertos)
        {

            ModelState.Remove("Id_aeropuerto");
            if (ModelState.IsValid)
            {
                AeropuertosDAL.InsertarAeropuertos(aeropuertos);
                return RedirectToAction("Aeropuertos");
            }

            return View();
        }

        // GET: AeropuertosController/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View(AeropuertosDAL.ObtenerAerolineasPorId(id));
        }

        // POST: AeropuertosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aeropuertos aeropuertos)
        {
            if (ModelState.IsValid)
            {
                AeropuertosDAL.ModificarAropuertos(aeropuertos);
                return RedirectToAction("Aeropuertos");

            }
            return View();
        }

        // GET: AeropuertosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(AeropuertosDAL.ObtenerAerolineasPorId(id));
        }

        // POST: AeropuertosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Aeropuertos aeropuertos)
        {
            AeropuertosDAL.EliminarAeropuertos(aeropuertos.Id_aeropuerto);
            return RedirectToAction("Aeropuertos");

        }
    }
}
