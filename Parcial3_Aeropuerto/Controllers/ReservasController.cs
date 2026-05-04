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
        public ActionResult Reservas()
        {
            return View(reservasBL.MostrarReservas());
        }

        // GET: ReservasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReservasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReservasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reservas reservas)
        {
            if(ModelState.IsValid)
            {
                reservasBL.AgregarReservas(reservas);
                return RedirectToAction("Reservas", new Reservas());
            }
            return View("Create", reservas);
        }

        // GET: ReservasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(reservasBL.ObtenerReservasPorId(id));
        }

        // POST: ReservasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Reservas reservas)
        {
            if(ModelState.IsValid)
            {
                reservasBL.ModificarReservas(reservas);
                return RedirectToAction("Reservas");
            }
            return View(reservas);
        }

        // GET: ReservasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(reservasBL.ObtenerReservasPorId(id));
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
