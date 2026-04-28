using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Parcial3_Aeropuerto.BL;
using Parcial3_Aeropuerto.EN;
namespace Parcial3_Aeropuerto.UI.Controllers
{
    public class DestinosController : Controller
    {
        DestinosBL destinosBL = new DestinosBL();
        AerolineasBL aerolineasBL = new AerolineasBL();
        // GET: DestinosController
        public ActionResult Destinos(int paginas, string buscar = "")
        {
            int registrosPorPagina = 5;

            var lista = string.IsNullOrEmpty(buscar)
                ? destinosBL.MostrarDestinos()
                : destinosBL.BuscarDestinos(buscar);

            var totalRegistros = lista.Count();

            var destinos = lista
                .OrderBy(p => p.Id_destino)
                .Skip((paginas - 1) * registrosPorPagina)
                .Take(registrosPorPagina)
                .ToList();

            var modelo = new Paginacion<Destinos>
            {
                Items = destinos,
                PaginaActual = paginas,
                TotalPaginas = (int)Math.Ceiling((double)totalRegistros / registrosPorPagina)
            };

            ViewBag.Buscar = buscar;

            return View("Destinos", modelo);
        }

        // GET: DestinosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DestinosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DestinosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Destinos destinos)
        {
            if(ModelState.IsValid)
            {
                destinosBL.AgregarDestino(destinos);
                return RedirectToAction("Destinos", new Destinos());
            }
            return View("Create", destinos);
        }

        // GET: DestinosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(destinosBL.ObtenerDestinosPorId(id));
        }

        // POST: DestinosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Destinos destinos)
        {
            if(ModelState.IsValid)
            {
                destinosBL.ModificarDestino(destinos);
                return RedirectToAction("Destinos");
            }
            return View("Edit", destinos);
        }

        // GET: DestinosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(destinosBL.ObtenerDestinosPorId(id));
        }

        // POST: DestinosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            destinosBL.EliminarDestino(id);
            return RedirectToAction("Destinos");
        }
    }
}
