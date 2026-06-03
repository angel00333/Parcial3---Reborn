using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcial3_Aeropuerto.BL;
using Parcial3_Aeropuerto.DAL;
using Parcial3_Aeropuerto.EN;
namespace Parcial3_Aeropuerto.UI.Controllers
{
    public class VuelosController : Controller
    {
        VuelosBL vuelosBL = new VuelosBL();
        AvionesBL avionesBL = new AvionesBL();
        DestinosBL destinosBL = new DestinosBL();
        AerolineasBL aerolineasBL = new AerolineasBL();

        // GET: VuelosController
        public ActionResult Vuelos(int paginas = 1, string buscar="")
        {
            var rol = HttpContext.Session.GetString("Rol");

            if (rol != "Recepcionista" && rol != "Gerente" && rol != "Administrador")
            {
                return RedirectToAction("AccesoDenegado", "Login");
            }

            int RegistrosPorPagina = 4; 

            var lista = string.IsNullOrEmpty(buscar)
                ? vuelosBL.MostrarVuelos()
                : vuelosBL.BuscarVuelos(buscar);

            var totalRegistros = lista.Count();

            var vuelos = lista
                .OrderBy(v => v.Id_vuelo)
                .Skip((paginas - 1) * RegistrosPorPagina)
                .Take(RegistrosPorPagina)
                .ToList();

            var modelo = new Paginacion<Vuelos>
            {
                Items = vuelos,
                PaginaActual = paginas,
                TotalPaginas = (int)Math.Ceiling((double)totalRegistros / RegistrosPorPagina)
            };

            
            ViewBag.Buscar = buscar;
            ViewBag.Destinos = destinosBL.MostrarDestinos();

            return View("Vuelos", modelo);


        }

        // GET: VuelosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VuelosController/Create
        public ActionResult Create()
        {
            var rol = HttpContext.Session.GetString("Rol");

            if (rol != "Gerente" && rol != "Administrador")
            {
                return RedirectToAction("AccesoDenegado", "Login");
            }

            ViewBag.Aviones = avionesBL.MostrarAviones();
            ViewBag.Destinos = destinosBL.MostrarDestinos();
            ViewBag.Aerolineas = aerolineasBL.MostrarAerolineas();
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
                TempData["MensajeExito"] = "Vuelo creado exitosamente.";
                return RedirectToAction("Vuelos");
            }

            ViewBag.Aviones = avionesBL.MostrarAviones();
            ViewBag.Destinos = destinosBL.MostrarDestinos();
            ViewBag.Aerolineas = aerolineasBL.MostrarAerolineas();
            return View("Create", vuelos);
        }

        // GET: VuelosController/Edit/5
        public ActionResult Edit(int id)
        {
            var rol = HttpContext.Session.GetString("Rol");

            if (rol != "Gerente" && rol != "Administrador")
            {
                return RedirectToAction("AccesoDenegado", "Login");
            }

            ViewBag.Aviones = avionesBL.MostrarAviones();
            ViewBag.Destinos = destinosBL.MostrarDestinos();
            ViewBag.Aerolineas = aerolineasBL.MostrarAerolineas();
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
            ViewBag.Aviones = avionesBL.MostrarAviones();
            ViewBag.Destinos = destinosBL.MostrarDestinos();
            ViewBag.Aerolineas = aerolineasBL.MostrarAerolineas();
            return View("Edit", vuelos);
        }

        // GET: VuelosController/Delete/5
        public ActionResult Delete(int id)
        {
            var rol = HttpContext.Session.GetString("Rol");

            if (rol != "Gerente" && rol != "Administrador")
            {
                return RedirectToAction("AccesoDenegado", "Login");
            }

            var vuelo = vuelosBL.ObtenerVuelosPorId(id);

            ViewBag.Destino = destinosBL.ObtenerDestinosPorId(vuelo.Id_destino);
            return View(vuelo);
        }

        // POST: VuelosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (vuelosBL.VueloTieneReservas(id))
            {
                TempData["SMSError"] = "No se puede eliminar este vuelo porque tiene reservas relacionadas.";
                return RedirectToAction("Vuelos");
            }

            vuelosBL.EliminarVuelos(id);
            TempData["SMSExito"] = "El vuelo se eliminó correctamente.";

            return RedirectToAction("Vuelos");
        }
    }
}
