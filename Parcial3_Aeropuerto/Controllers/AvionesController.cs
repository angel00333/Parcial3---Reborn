using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using MySqlConnector;
using Parcial3_Aeropuerto.BL;
using Parcial3_Aeropuerto.EN; // Agrega esta línea para incluir el espacio de nombres de tu modelo

namespace Parcial3_Aeropuerto.Controllers
{
    public class AvionesController : Controller
    {
        AerolineasBL aerolineasBL = new AerolineasBL();
        AvionesBL avionesBL = new AvionesBL();
        // GET: Aviones
        public ActionResult Aviones(int paginas = 1, string buscar= "")
        {
            int registrosPorPagina = 5;

            var lista = string.IsNullOrEmpty(buscar)
                ? avionesBL.MostrarAviones()
                : avionesBL.BuscarAviones(buscar);

            var totalRegistros = lista.Count();

            var aviones = lista
                .OrderBy(a => a.Id_avion)
                .Skip((paginas -1 )* registrosPorPagina)
                .Take( registrosPorPagina )
                .ToList();
            var modelo = new Paginacion<Aviones>

            {
                Items = aviones,
                PaginaActual=paginas,
                TotalPaginas=(int)Math.Ceiling((double) totalRegistros/registrosPorPagina)
            };

            ViewBag.Buscar = buscar;
            return View("Aviones", modelo);
        }

        // GET: Aviones/Details/5
        public ActionResult Details(int id)
        {
            return View(avionesBL.ObtenerAvionesPorId(id));
        }

        // GET: Aviones/Create
        public ActionResult Create()
        {
            //Se extrae la vista de Aerolineas hacia aviones/ GET
            ViewBag.Aerolineas = aerolineasBL.MostrarAerolineas ();
            return View();
        }

        // POST: Aviones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aviones aviones)
        {
            if (ModelState.IsValid)
            {
                avionesBL.AgregarAviones(aviones);
                TempData["MensajeExito"] = "El avión se agregó correctamente";
                return RedirectToAction("Aviones");
            }

            ViewBag.Aerolineas = aerolineasBL.MostrarAerolineas();
            return View();
        }

        // GET: Aviones/Edit/5
        public ActionResult Edit(int id)
        {

            ViewBag.Aerolineas = aerolineasBL.MostrarAerolineas();
            return View(avionesBL.ObtenerAvionesPorId(id));
        }

        // POST: Aviones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aviones aviones)
        {
            if (ModelState.IsValid)
            {
                avionesBL.ModificarAviones(aviones);
                return RedirectToAction("Aviones");
            }
            return View();
        }

        // GET: Aviones/Delete/5
        public ActionResult Delete(int id)
        {
            return View(avionesBL.ObtenerAvionesPorId(id));

        }

        // POST: Aviones/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            avionesBL.EliminarAviones(id);
            return RedirectToAction("Aviones");

        }
    }
}
