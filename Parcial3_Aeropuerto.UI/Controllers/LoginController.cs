using Microsoft.AspNetCore.Mvc;
using Parcial3_Aeropuerto.DAL;

namespace Parcial3_Aeropuerto.UI.Controllers
{
    public class LoginController : Controller
    {

        [HttpGet]
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public IActionResult Login()
        {
            var usuario = HttpContext.Session.GetString("Usuario");

            if (!string.IsNullOrEmpty(usuario))
            {
                return RedirectToAction("Index", "Home");
            }

            return View("Login");
        }

        [HttpPost]
        public IActionResult Login(string Nombre_usuario, string Contraseña)
        {
            var usuario = LoginDAL.IniciarSesion(Nombre_usuario, Contraseña);

            if (usuario != null)
            {
                HttpContext.Session.SetString("Usuario", usuario.Nombre_usuario);
                HttpContext.Session.SetString("Rol", usuario.Nombre_rol);
                HttpContext.Session.SetInt32("Id_usuario", usuario.Id_usuario);

                if(usuario.Nombre_rol == "Administrador")
                {
                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ViewBag.Error = "Usuario o contraseña incorrectos";
            return View("Login");
        }

        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }

        
}

