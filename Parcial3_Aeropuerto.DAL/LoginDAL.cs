using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;
using System.Data;

using Parcial3_Aeropuerto.EN;
namespace Parcial3_Aeropuerto.DAL
{
    public class LoginDAL
    {
        public static Login IniciarSesion(string nombreUsuario, string contraseña)
        {
            Login login = null;

            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();

                string sql = @"SELECT u.Id_usuario, u.Nombre_usuario, u.Contraseña, u.Id_rol, r.Nombre_rol FROM usuarios u INNER JOIN rol r ON u.Id_rol = r.Id_rol WHERE u.Nombre_usuario = @Nombre_usuario AND u.Contraseña = @Contraseña";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Nombre_usuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@Contraseña", contraseña);

                IDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    login = new Login
                    {
                        Id_usuario = reader.GetInt32(0),
                        Nombre_usuario = reader.GetString(1),
                        Contraseña = reader.GetString(2),
                        Id_rol = reader.GetInt32(3),
                        Nombre_rol = reader.GetString(4)
                    };
                }

                con.Close();
            }

            return login;
        }
    }
}
