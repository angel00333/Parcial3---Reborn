using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Parcial3_Aeropuerto.BL;
using Parcial3_Aeropuerto.DAL;
using Parcial3_Aeropuerto.EN;
using Rotativa.AspNetCore;

namespace Parcial3_Aeropuerto.Controllers
{
    public class ReservasController : Controller
    {
        ReservasBL reservasBL = new ReservasBL();
        PasajeroBL pasajerosBL = new PasajeroBL();
        AerolineasBL aerolineasBL = new AerolineasBL();
        VuelosBL vuelosBL = new VuelosBL();
        AvionesBL avionesBL = new AvionesBL();
        DestinosBL destinosBL = new DestinosBL();
        // GET: ReservasController
        public ActionResult Reservas(int paginas, string buscar = "")
        {
            var rol = HttpContext.Session.GetString("Rol");

            if (rol != "Recepcionista" && rol != "Gerente" && rol != "Administrador")
            {
                return RedirectToAction("Login", "Login");
            }

            int registrosPorPagina = 5;

            var lista = string.IsNullOrEmpty(buscar)
                ? reservasBL.MostrarReservas()
                : reservasBL.BuscarReservas(buscar);

            var totalRegistros = lista.Count();
            var reservas = lista
                .OrderBy(r => r.Id_reserva)
                .Skip((paginas - 1) * registrosPorPagina)
                .Take(registrosPorPagina)
                .ToList();
            var modelo = new Paginacion<Reservas>
            {
                Items = reservas,
                PaginaActual = paginas,
                TotalPaginas = (int)Math.Ceiling((double)totalRegistros / registrosPorPagina)
            };

            ViewBag.Buscar = buscar;
            return View("Reservas", modelo);
        }

        // GET: ReservasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReservasController/Create
        public ActionResult Create()
        {
            var rol = HttpContext.Session.GetString("Rol");

            if (rol != "Usuario" && rol != "Gerente" && rol != "Administrador")
            {
                return RedirectToAction("Login", "Login");
            }

            ViewBag.Pasajeros = pasajerosBL.MostrarPasajeros();
            ViewBag.Vuelos = vuelosBL.MostrarVuelos();
            ViewBag.Destinos = destinosBL.MostrarDestinos();
            return View();
        }

        // POST: ReservasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reservas reservas)
        {
            reservas.Id_usuario = HttpContext.Session.GetInt32("Id_usuario") ?? 0;
            

            ModelState.Remove("Id_usuario");
            

            if (ModelState.IsValid)
            {
                reservasBL.AgregarReservas(reservas);
                TempData["MensajeExito"] = "Reserva creada exitosamente.";
                return RedirectToAction("Reservas");
            }

            ViewBag.Pasajeros = pasajerosBL.MostrarPasajeros();
            ViewBag.Vuelos = vuelosBL.MostrarVuelos();
            ViewBag.Destinos = destinosBL.MostrarDestinos();
            return View("Create", reservas);
        }

        // GET: ReservasController/Edit/5
        public ActionResult Edit(int id)
        {
            var rol = HttpContext.Session.GetString("Rol");

            if (rol != "Usuario" && rol != "Gerente" && rol != "Administrador")
            {
                return RedirectToAction("Login", "Login");
            } 

            ViewBag.Pasajeros = pasajerosBL.MostrarPasajeros();
            ViewBag.Vuelos = vuelosBL.MostrarVuelos();
            ViewBag.Destinos = destinosBL.MostrarDestinos();
            return View(reservasBL.ObtenerReservasPorId(id));
        }

        // POST: ReservasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Reservas reservas)
        {
            reservas.Id_usuario = HttpContext.Session.GetInt32("Id_usuario") ?? 0;

            ModelState.Remove("Id_usuario");

            if (ModelState.IsValid)
            {
                reservasBL.ModificarReservas(reservas);
                TempData["MensajeExito"] = "Reserva modificada exitosamente.";
                return RedirectToAction("Reservas");
            }

            ViewBag.Pasajeros = pasajerosBL.MostrarPasajeros();
            ViewBag.Vuelos = vuelosBL.MostrarVuelos();
            ViewBag.Destinos = destinosBL.MostrarDestinos();
            return View();
        }

        // GET: ReservasController/Delete/5
        public ActionResult Delete(int id)
        {
            var rol = HttpContext.Session.GetString("Rol");

            if (rol != "Usuario" && rol != "Gerente" && rol != "Administrador")
            {
                return RedirectToAction("Login", "Login");
            }

            var reserva = reservasBL.ObtenerReservasPorId(id);

            ViewBag.Pasajero = pasajerosBL.ObtenerPasajeroPorId(reserva.Id_pasajero);
            return View(reserva);
        }

        // POST: ReservasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            reservasBL.EliminarReservas(id);
            return RedirectToAction("Reservas");
        }

        public IActionResult Pdf(int id)
        {
            var rol = HttpContext.Session.GetString("Rol");

            if (rol != "Usuario" && rol != "Gerente" && rol != "Administrador")
            {
                return RedirectToAction("Login", "Login");
            }

            var reserva = reservasBL.ObtenerReservasPorId(id);

            var modelo = new ReservasP
            {
                Reservas = new List<Reservas> { reserva },
                Pasajero = pasajerosBL.MostrarPasajeros(),
                Aerolineas = aerolineasBL.MostrarAerolineas(),
                Vuelos = vuelosBL.MostrarVuelos(),
                Aviones = avionesBL.MostrarAviones(),
                Destinos = destinosBL.MostrarDestinos()
            };

            return new ViewAsPdf("Pdf", modelo)
            {
                FileName = "RegistroReserva.pdf",
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape,
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };
        }

    }
}
