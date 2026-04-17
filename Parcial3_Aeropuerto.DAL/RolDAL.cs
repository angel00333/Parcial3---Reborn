using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySqlConnector;
using System.Security.Cryptography.X509Certificates;
using Parcial3_Aeropuerto.EN;

namespace Parcial3_Aeropuerto.DAL
{
    public class RolDAL
    {

        public static List<Rol> MostrarRoles()
        {
            List<Rol> roleslist = new List<Rol>();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT * FROM Rol";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Rol roles = new Rol();
                    roles.Id_rol = reader.GetInt32(0);
                    roles.Nombre_rol = reader.GetString(1);
                    roleslist.Add(roles);
                }
                con.Close();
            }
            return roleslist;
        }

        public static List<Rol> BuscarRoles(string criterio)
        {
            List<Rol> roleslist = new List<Rol>();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT * FROM Rol WHERE Id_rol LIKE @C OR Nombre_rol LIKE @C";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@C", "%" + criterio + "%");
                IDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    roleslist.Add(new Rol
                    {
                        Id_rol = reader.GetInt32(0),
                        Nombre_rol = reader.GetString(1)
                    });
                }
                con.Close();
            }
            return roleslist;

        }


        public static Rol ObtenerRolesPorId(int id)
        {
            Rol roles = new Rol();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT * FROM Rol WHERE Id_rol=@Id_rol";
                MySqlCommand comando = new MySqlCommand(sql, con);

                comando.Parameters.AddWithValue("@Id_rol", id);

                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    roles.Id_rol = reader.GetInt32(0);
                    roles.Nombre_rol = reader.GetString(1);

                }
                con.Close();
            }
            return roles;
        }

        public static int AgregarRoles(Rol roles)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "INSERT INTO Rol (Nombre_rol) VALUES (@Nombre_rol)";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@Nombre_rol", roles.Nombre_rol);       
                resultado = comando.ExecuteNonQuery();
               
                con.Close();
            }
            return resultado;

        }

        public static int ModificarRoles(Rol roles)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "UPDATE Rol SET Nombre_rol=@Nombre_rol WHERE Id_rol=@Id_rol";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@Nombre_rol", roles.Nombre_rol);
                comando.Parameters.AddWithValue("@Id_rol", roles.Id_rol);
                resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            return resultado;

        }

        public static int EliminarRoles(int id)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "DELETE FROM Rol WHERE Id_rol=@Id_rol";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@Id_rol", id);
                resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            return resultado;
        }

    }   

}
