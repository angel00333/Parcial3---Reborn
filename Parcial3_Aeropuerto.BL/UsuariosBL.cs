using System;
using System.Collections.Generic;
using System.Text;

using Parcial3_Aeropuerto.EN;
using Parcial3_Aeropuerto.DAL;

namespace Parcial3_Aeropuerto.BL
{
    public class UsuariosBL
    {
        public int AgregarUsuario(Usuarios usuario)
        {
            return UsuariosDAL.AgregarUsuarios(usuario);
        }
        public int ModificarUsuario(Usuarios usuario)
        {
            return UsuariosDAL.ModificarUsuarios(usuario);
        }
        public int EliminarUsuario(int id)
        {
            return UsuariosDAL.EliminarUsuarios(id);
        }
        public List<Usuarios> BuscarUsuarios(string criterio)
        {
            return UsuariosDAL.BuscarUsuarios(criterio);
        }
        public List<Usuarios> MostrarUsuarios()
        {
            return UsuariosDAL.MostrarUsuarios();
        }
        public Usuarios ObtenerUsuarioPorId(int id)
        {
            return UsuariosDAL.ObtenerUsuarioPorId(id);
        }
    }
}
