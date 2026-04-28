using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Parcial3_Aeropuerto.EN;
using Parcial3_Aeropuerto.BL;
namespace Parcial3_Aeropuerto.UI.Controllers
{
    public class VuelosController : Controller
    {
        VuelosBL vuelosBL = new VuelosBL();
        AvionesBL avionesBL = new AvionesBL();
        DestinosBL destinosBL = new DestinosBL();

        // GET: VuelosController
        public ActionResult Vuelos()
        {
            return View(vuelosBL.MostrarVuelos());
        }

        // GET: VuelosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VuelosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VuelosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vuelos vuelos)
        {
            if (ModelState.IsValid)
            {
                vuelosBL.AgregarVuelos(vuelos);
                return RedirectToAction("Vuelos", new Vuelos());
            }
            return View("Create", vuelos);
        }

        // GET: VuelosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(vuelosBL.ObtenerVuelosPorId(id));
        }

        // POST: VuelosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vuelos vuelos)
        {
            if(ModelState.IsValid)
            {
                vuelosBL.ModificarVuelos(vuelos);
                return RedirectToAction("Vuelos");
            }
            return View("Edit", vuelos);
        }

        // GET: VuelosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(vuelosBL.ObtenerVuelosPorId);
        }

        // POST: VuelosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            vuelosBL.EliminarVuelos(id);
            return RedirectToAction("Vuelos");
        }
    }
}
