using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcial3_Aeropuerto.Models;
using System.Data;
using MySqlConnector;

using Parcial3_Aeropuerto.BL;
using Parcial3_Aeropuerto.EN;

namespace Parcial3_Aeropuerto.Controllers
{
    public class AerolineasController : Controller
    {
        AerolineasBL aerolineasBL = new AerolineasBL();
        // GET: AerolieasController
        public ActionResult Aerolineas(int paginas = 1, string buscar = "")
        {
            int registroPorPagina = 5;

            var lista = string.IsNullOrEmpty(buscar)
                ? aerolineasBL.MostrarAerolineas()
                : aerolineasBL.BuscarAerolineas(buscar);

            var totalRegistros = lista.Count();

            var aerolineas = lista
                .OrderBy(a => a.Id_aerolinea)
                .Skip((paginas - 1) * registroPorPagina)
                .Take(registroPorPagina)
                .ToList();

            var modelo = new Paginacion<Aerolineas>
            {
                Items = aerolineas,
                PaginaActual = paginas,
                TotalPaginas = (int)Math.Ceiling((double)totalRegistros / registroPorPagina)
            };
            ViewBag.Buscar = buscar;
            return View("Aerolineas", modelo);

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
          
            if (ModelState.IsValid)
            {
                aerolineasBL.AgregarAerolineas(aerolineas);
                TempData["SMSExito"] = "La aerolinea se guardó correctamente";
                return RedirectToAction("Aerolineas");
            }

            return View();
          
        }

        // GET: AerolieasController/Edit/5
        public ActionResult Edit(int id)
        {
            var aerolineas = aerolineasBL.ObtenerAerolineasPorId(id);
            return View(aerolineas);
        }

        // POST: AerolieasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aerolineas aerolineas)
        {
            if (ModelState.IsValid) {
                aerolineasBL.ModificarAerolineas(aerolineas);
                return RedirectToAction("Aerolineas");

                            
            }
            return View();

        }

        // GET: AerolieasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(aerolineasBL.ObtenerAerolineasPorId(id));
        }

        // POST: AerolieasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (aerolineasBL.AerolineaTieneAviones(id))
            {
                TempData["SMSError"] = "No se puede eliminar esta aerolínea porque tiene aviones relacionados.";
                return RedirectToAction("Aerolineas");
            }

            aerolineasBL.EliminarAerolineas(id);
            TempData["SMSExito"] = "La aerolínea se eliminó correctamente.";

            return RedirectToAction("Aerolineas");
        }
    }
}
