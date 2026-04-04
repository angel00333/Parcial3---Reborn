using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Parcial3_Aeropuerto.Models;

namespace Parcial3_Aeropuerto.Controllers
{
    public class PasajeroController : Controller
    {
        // GET: PasajeroController
        public ActionResult Pasajero(int paginas = 1)
        {
            int registrosPorPagina = 5;

            var listaCompleta = PasajeroDAL.MostrarPasajeros();

            var totalRegistros = listaCompleta.Count();

            var pasajeros = listaCompleta
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
            try
            {
                PasajeroDAL.AgregarPasajero(pasajero);
                return RedirectToAction("Pasajero");
            }
            catch
            {
                return PartialView("Create");
            }
        }

        // GET: PasajeroController/Edit/5
        public ActionResult Edit(int id)
        {
            return PartialView(PasajeroDAL.ObtenerPasajeroPorId(id));
        }

        // POST: PasajeroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pasajero pasajero)
        {
            if (ModelState.IsValid)
            {
                PasajeroDAL.ModificarPasajero(pasajero);
                return RedirectToAction("Pasajero");
            }
            return PartialView("Edit", pasajero);
        }

        // GET: PasajeroController/Delete/5
        public ActionResult Delete(int id)
        {
            return PartialView("Delete", PasajeroDAL.ObtenerPasajeroPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PasajeroDAL.EliminarPasajero(id);
            return RedirectToAction("Pasajero");
        }
    }
}
