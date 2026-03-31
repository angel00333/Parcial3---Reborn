using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
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

        // POST: PersonaController1/Create
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
                return PartialView("Create", pasajero);
            }
        }

        // GET: PasajeroController/Edit/5
        public ActionResult Edit(int id)
        {
            var pasajero = PasajeroDAL.ObtenerPasajeroPorId(id);

            if (pasajero == null)
            {
                return Content("No se encontró el pasajero.");
            }

            return PartialView("Edit", pasajero);
        }

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
            return View();
        }

        // POST: PasajeroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Pasajero));
            }
            catch
            {
                return View();
            }
        }
    }
}
