using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcial3_Aeropuerto.Models;
using MySqlConnector;
using System.Data;

using Parcial3_Aeropuerto.BL;
using Parcial3_Aeropuerto.EN;

namespace Parcial3_Aeropuerto.Controllers
{
    public class UsuariosController : Controller
    {
        RolBL rolBL = new RolBL();
        UsuariosBL usuariosBL = new UsuariosBL();
        // GET: UsuariosController
        public ActionResult Usuarios(string buscar)
        {
            var usuario = HttpContext.Session.GetString("Usuario");
            var rol = HttpContext.Session.GetString("Rol");

            if (string.IsNullOrEmpty(usuario))
            {
                return RedirectToAction("Login", "Login");
            }

            if (rol != "Administrador")
            {
                return RedirectToAction("AccesoDenegado", "Login");
            }

            return View(usuariosBL.MostrarUsuarios());
        }

        // GET: UsuariosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuariosController/Create
        public ActionResult Create()
        {
            ViewBag.Roles = rolBL.MostrarRoles();
            return View();
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuarios usuarios)
        {

            ModelState.Remove("Id_usuario");

            if (ModelState.IsValid)
            {
                usuariosBL.AgregarUsuario(usuarios);
                TempData["SMSExito"] = "El usuario se agregó correctamente";
                return RedirectToAction("Usuarios");
            }
           ViewBag.Roles= rolBL.MostrarRoles();
            return View();

        }

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Roles = rolBL.MostrarRoles();
            return View(usuariosBL.ObtenerUsuarioPorId(id));
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                usuariosBL.ModificarUsuario(usuarios);
                TempData["SMSExito"] = "El usuario se modificó correctamente";
                return RedirectToAction("Usuarios");
            }
            return View();
        }

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(usuariosBL.ObtenerUsuarioPorId(id));
        }

        // POST: UsuariosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            usuariosBL.EliminarUsuario(id);
            return RedirectToAction("Usuarios");
        }
    }
}
