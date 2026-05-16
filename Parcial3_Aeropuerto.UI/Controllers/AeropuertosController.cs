using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Parcial3_Aeropuerto.BL;
using Parcial3_Aeropuerto.DAL;
using Parcial3_Aeropuerto.EN;
using Parcial3_Aeropuerto.Models;
using System.Data;

namespace Parcial3_Aeropuerto.Controllers
{
    public class AeropuertosController : Controller
    {
        AeropuertosBL aeropuertosBL = new AeropuertosBL();
        // GET: AeropuertosController
        public ActionResult Aeropuertos( int paginas,  string buscar = "")
        {
            var rol = HttpContext.Session.GetString("Rol");

            if (rol != "Usuario" && rol != "Gerente" && rol != "Administrador")
            {
                return RedirectToAction("Login", "Login");
            }

            int registrosPorPagina = 5;

            var lista = string.IsNullOrEmpty(buscar)
                ? aeropuertosBL.MostrarAeropuertos()
                : aeropuertosBL.BuscarAeropuertos(buscar);

            var totalRegistros = lista.Count();

            var aeropuertos = lista
                .OrderBy(p => p.Id_aeropuerto)
                .Skip((paginas - 1) * registrosPorPagina)
                .Take(registrosPorPagina)
                .ToList();

            var modelo = new Paginacion<Aeropuertos>
            {
                Items = aeropuertos,
                PaginaActual = paginas,
                TotalPaginas = (int)Math.Ceiling((double)totalRegistros / registrosPorPagina)
            };

            ViewBag.Buscar = buscar;

            return View("Aeropuertos", modelo);


        }

        // GET: AeropuertosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AeropuertosController/Create
        public ActionResult Create()
        {
            var rol = HttpContext.Session.GetString("Rol");

            if (rol != "Usuario" && rol != "Gerente" && rol != "Administrador")
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        // POST: AeropuertosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aeropuertos aeropuertos)
        {

            if (ModelState.IsValid)
            {
                aeropuertosBL.AgregarAeropuertos(aeropuertos);
                TempData["SMSExito"] = "El aeropuerto se agregó correctamente";
                return RedirectToAction("Aeropuertos");
            }

            return View();
        }

        // GET: AeropuertosController/Edit/5
        public ActionResult Edit(int id)
        {
            var rol = HttpContext.Session.GetString("Rol");

            if (rol != "Usuario" && rol != "Gerente" && rol != "Administrador")
            {
                return RedirectToAction("Login", "Login");
            }

            return View(aeropuertosBL.ObtenerAeropuertoPorId(id));
        }

        // POST: AeropuertosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aeropuertos aeropuertos)
        {
            if (ModelState.IsValid)
            {
                aeropuertosBL.ModificarAeropuertos(aeropuertos);
                return RedirectToAction("Aeropuertos");

            }
            return View();
        }

        // GET: AeropuertosController/Delete/5
        public ActionResult Delete(int id)
        {
            var rol = HttpContext.Session.GetString("Rol");

            if (rol != "Usuario" && rol != "Gerente" && rol != "Administrador")
            {
                return RedirectToAction("Login", "Login");
            } 

            return View(aeropuertosBL.ObtenerAeropuertoPorId(id));
        }

        // POST: AeropuertosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            if (aeropuertosBL.AeropuertoTieneDestino(id))
            {
                TempData["SMSError"] = "No se puede eliminar este aeropuerto porque tiene destino relacionado.";
                return RedirectToAction("Aeropuertos");
            }

            aeropuertosBL.EliminarAeropuertos(id);
            TempData["SMSExito"] = "El aeropuerto se eliminó correctamente.";

            return RedirectToAction("Aeropuertos");

        }
    }
}
