using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; //Para usar SelectList
using Parcial3_Aeropuerto.BL;
using Parcial3_Aeropuerto.DAL;
using Parcial3_Aeropuerto.EN;
namespace Parcial3_Aeropuerto.UI.Controllers
{
    public class DestinosController : Controller
    {
        AeropuertosBL aeropuertosBL = new AeropuertosBL();

        DestinosBL destinosBL = new DestinosBL();
        // GET: DestinosController
        public ActionResult Destinos(int paginas = 1, string buscar = "")
        {
            var rol = HttpContext.Session.GetString("Rol");

            if (rol != "Recepcionista" && rol != "Gerente" && rol != "Administrador")
            {
                return RedirectToAction("AccesoDenegado", "Login");
            }

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
            var rol = HttpContext.Session.GetString("Rol");

            if (rol != "Gerente" && rol != "Administrador")
            {
                return RedirectToAction("AccesoDenegado", "Login");
            }

            ViewBag.Id_aeropuerto = new SelectList(aeropuertosBL.MostrarAeropuertos(), "Id_aeropuerto", "Nombre_aeropuerto");
            return View();
        }

        // POST: DestinosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Destinos destinos, int Id_aeropuerto)
        {

            if (ModelState.IsValid)
            {
                destinos.Aeropuertos = new Aeropuertos{Id_aeropuerto = Id_aeropuerto};
                destinosBL.AgregarDestino(destinos);
                TempData["SMSExito"] = "El usuario se agregó correctamente";
                return RedirectToAction("Destinos");
            }
            ViewBag.Id_aeropuerto = new SelectList(aeropuertosBL.MostrarAeropuertos(), "Id_aeropuerto", "Nombre_aeropuerto", Id_aeropuerto);
            return View();
        }

        // GET: DestinosController/Edit/5
        public ActionResult Edit(int id)
        {
            var rol = HttpContext.Session.GetString("Rol");

            if (rol != "Gerente" && rol != "Administrador")
            {
                return RedirectToAction("AccesoDenegado", "Login");
            }

            ViewBag.Id_aeropuerto = new SelectList(aeropuertosBL.MostrarAeropuertos(), "Id_aeropuerto", "Nombre_aeropuerto", destinosBL.ObtenerDestinosPorId(id).Aeropuertos.Id_aeropuerto );
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
                TempData["SMSExito"] = "El usuario se modificó correctamente";
                return RedirectToAction("Destinos");
            }
            ViewBag.Id_aeropuerto = new SelectList(aeropuertosBL.MostrarAeropuertos(), "Id_aeropuerto", "Nombre_aeropuerto", destinos.Aeropuertos.Id_aeropuerto);
            return View("Edit", destinos);
        }

        // GET: DestinosController/Delete/5
        public ActionResult Delete(int id)
        {
            var rol = HttpContext.Session.GetString("Rol");

            if (rol != "Gerente" && rol != "Administrador")
            {
                return RedirectToAction("AccesoDenegado", "Login");
            }

            return View(destinosBL.ObtenerDestinosPorId(id));
        }

        // POST: DestinosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if(destinosBL.DestinoTieneVuelo(id))
            {
                TempData["SMSError"] = "No se puede eliminar este destino porque tiene vuelos relacionados.";
                return RedirectToAction("Destinos");
            }
            destinosBL.EliminarDestino(id);
            TempData["SMSExito"] = "El destino se eliminó correctamente.";

            return RedirectToAction("Destinos");
        }
    }
}
