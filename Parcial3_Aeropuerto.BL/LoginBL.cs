using System;
using System.Collections.Generic;
using System.Text;

using Parcial3_Aeropuerto.EN;
using Parcial3_Aeropuerto.DAL;

namespace Parcial3_Aeropuerto.BL
{
  public class LoginBL
  {
        public static Login IniciarSesion(string nombreUsuario, string contraseña)
        {
            // Delegar al DAL
            return LoginDAL.IniciarSesion(nombreUsuario, contraseña);
        }
    }
}
