using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcial3_Aeropuerto.Models;
using MySqlConnector;
using System.Data;

using Parcial3_Aeropuerto.BL;
using Parcial3_Aeropuerto.EN;

namespace Parcial3_Aeropuerto.Controllers
{
    public class RolesController : Controller
    {
        RolBL rolBL = new RolBL();
        // GET: RolesController
        public ActionResult Roles(string buscar )
        {
            return View(rolBL.MostrarRoles());
        }

        // GET: RolesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RolesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Rol roles)
        {
            ModelState.Remove("Id_rol");
            if (ModelState.IsValid)
            {
                rolBL.AgregarRol(roles);
                return RedirectToAction("Roles");
            }
            return View();
            
        }

        // GET: RolesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(rolBL.ObtenerRolPorId(id));
        }

        // POST: RolesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Rol roles)
        {
            ModelState.Remove("Id_rol");
            if (ModelState.IsValid)
            {
                rolBL.ModificarRol(roles);
                return RedirectToAction("Roles");

            }
            return View();
        }

        // GET: RolesController/Delete/5
        public ActionResult Delete(int id)
        {
            return PartialView(rolBL.ObtenerRolPorId(id));
        }

        // POST: RolesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            rolBL.EliminarRol(id);
            return RedirectToAction("Roles");
        }
    }
}
