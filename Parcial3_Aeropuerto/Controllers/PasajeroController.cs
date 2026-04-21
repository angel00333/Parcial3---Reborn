using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

using Parcial3_Aeropuerto.BL;
using Parcial3_Aeropuerto.EN;

namespace Parcial3_Aeropuerto.UI.Controllers
{
    public class PasajeroController : Controller
    {
        PasajeroBL pasajeroBL = new PasajeroBL();
        // GET: PasajeroController
        public ActionResult Pasajero(int paginas = 1, string buscar = "")
        {
            int registrosPorPagina = 5;

            var lista = string.IsNullOrEmpty(buscar)
                ? pasajeroBL.MostrarPasajeros()
                : pasajeroBL.BuscarPasajeros(buscar);

            var totalRegistros = lista.Count();

            var pasajeros = lista
                .OrderBy(p => p.Id_pasajero)
                .Skip((paginas - 1) * registrosPorPagina)
                .Take(registrosPorPagina)
                .ToList();

            var modelo = new Paginacion<Pasajero>
            {
                Items = pasajeros,
                PaginaActual = paginas,
                TotalPaginas = (int)Math.Ceiling((double)totalRegistros / registrosPorPagina)
            };

            ViewBag.Buscar = buscar;

            return View("Pasajero", modelo);
        }
        // GET: PasajeroController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PasajeroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PasajeroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pasajero pasajero)
        {
            if (ModelState.IsValid)
            {
                pasajeroBL.AgregarPasajero(pasajero);
             
                return RedirectToAction("Pasajero", new Pasajero());
            }
            return PartialView("Create", pasajero);
        }

        // GET: PasajeroController/Edit/5
        public ActionResult Edit(int id)
        {
            return PartialView(pasajeroBL.ObtenerPasajeroPorId(id));
        }

        // POST: PasajeroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pasajero pasajero)
        {
            if (ModelState.IsValid)
            {
                pasajeroBL.ModificarPasajero(pasajero);
                return RedirectToAction("Pasajero");
            }
            return PartialView("Edit", pasajero);
        }

        // GET: PasajeroController/Delete/5
        public ActionResult Delete(int id)
        {
            return PartialView("Delete", pasajeroBL.ObtenerPasajeroPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            pasajeroBL.EliminarPasajero(id);
            return RedirectToAction("Pasajero");
        }
    }
}
