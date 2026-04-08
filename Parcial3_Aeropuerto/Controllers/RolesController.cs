using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcial3_Aeropuerto.Models;
using MySqlConnector;
using System.Data;

namespace Parcial3_Aeropuerto.Controllers
{
    public class RolesController : Controller
    {
        // GET: RolesController
        public ActionResult Roles(string buscar )
        {
            return View(RolDAL.MostrarRoles());
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
                RolDAL.InsertarRoles(roles);
                return RedirectToAction("Roles");
            }
            return View();
            
        }

        // GET: RolesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(RolDAL.ObtenerRolesPorId(id));
        }

        // POST: RolesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Rol roles)
        {
            ModelState.Remove("Id_rol");
            if (ModelState.IsValid)
            {
                RolDAL.ModificarRoles(roles);
                return RedirectToAction("Roles");

            }
            return View();
        }

        // GET: RolesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(RolDAL.ObtenerRolesPorId(id));
        }

        // POST: RolesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Rol roles)
        {
          RolDAL.EliminarRoles(roles.Id_rol);
            return RedirectToAction("Roles");
        }
    }
}
