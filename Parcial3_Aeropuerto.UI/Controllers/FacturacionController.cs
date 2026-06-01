using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Parcial3_Aeropuerto.BL;
using Parcial3_Aeropuerto.EN;

namespace Parcial3_Aeropuerto.UI.Controllers
{
    public class FacturacionController : Controller
    {
        FacturacionBL facturacionBL = new FacturacionBL();
        // GET: FacturacionController
        public ActionResult Facturacion(int paginas = 1, string buscar = "")
        {
            var rol = HttpContext.Session.GetString("Rol");

            if (rol != "Administrador" && rol != "Gerente")
            {
                return RedirectToAction("AccesoDenegado", "Login");
            }

            int registrosPorPagina = 5;

            var lista = string.IsNullOrEmpty(buscar)
                ? facturacionBL.MostrarFacturaciones()
                : facturacionBL.BuscarFacturacion(buscar);

            var totalRegistros = lista.Count();

            var facturaciones = lista
                .OrderBy(p => p.Id_Facturacion)
                .Skip((paginas - 1) * registrosPorPagina)
                .Take(registrosPorPagina)
                .ToList();

            var modelo = new Paginacion<Facturacion>
            {
                Items = facturaciones,
                PaginaActual = paginas,
                TotalPaginas = (int)Math.Ceiling((double)totalRegistros / registrosPorPagina)
            };

            ViewBag.Buscar = buscar;

            return View("Facturacion", modelo);
        }

        // GET: FacturacionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FacturacionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FacturacionController/Create
        

        // GET: FacturacionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(facturacionBL.ObtenerFacturacionPorId(id));
        }

        // POST: FacturacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Facturacion facturacion)
        {
            if(ModelState.IsValid)
            {
                facturacionBL.ModificarFacturacion(facturacion);
                return RedirectToAction("Facturacion");
            }
            return View("Edit", facturacion);
        }

        // GET: FacturacionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(facturacionBL.ObtenerFacturacionPorId(id));
        }

        // POST: FacturacionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            facturacionBL.EliminarFacturacion(id);
            return RedirectToAction("Facturacion");
        }
    }
}
