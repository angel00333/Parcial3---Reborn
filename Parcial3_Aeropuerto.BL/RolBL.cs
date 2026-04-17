using System;
using System.Collections.Generic;
using System.Text;

using Parcial3_Aeropuerto.EN;
using Parcial3_Aeropuerto.DAL;
namespace Parcial3_Aeropuerto.BL
{
    public class RolBL
    {
        public int AgregarRol(Rol rol)
        {
            return RolDAL.AgregarRoles(rol);
        }
        public int ModificarRol(Rol rol)
        {
            return RolDAL.ModificarRoles(rol);
        }
        public int EliminarRol(int id)
        {
            return RolDAL.EliminarRoles(id);
        }
        public List<Rol> BuscarRoles(string criterio)
        {
            return RolDAL.BuscarRoles(criterio);
        }
        public List<Rol> MostrarRoles()
        {
            return RolDAL.MostrarRoles();
        }
        public Rol ObtenerRolPorId(int id)
        {
            return RolDAL.ObtenerRolesPorId(id);
        }
    }
}
