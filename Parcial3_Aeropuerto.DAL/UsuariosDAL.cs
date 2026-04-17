using System;
using System.Collections.Generic;
using System.Text;
using Humanizer;
using MySqlConnector;
using Parcial3_Aeropuerto.DAL;
using System.Collections.Specialized;
using System.Data; //libreria para conectar con mysql
namespace Parcial3_Aeropuerto.EN
{
    public class UsuariosDAL
    {

        public static List<Usuarios> MostrarUsuarios()
        {
            List<Usuarios> Usuariolist = new List<Usuarios>();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT * FROM Usuarios";

                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                   Usuarios usuario = new Usuarios
                    {
                        Id_usuario = reader.GetInt32(0),
                        Nombre_usuario = reader.GetString(1),
                        Contraseña = reader.GetString(2),
                        Id_rol = reader.GetInt32(3),
                       
                    };
                    Usuariolist.Add(usuario);
                }
                con.Close();
            }
            return Usuariolist;
        }


        public static List<Usuarios> BuscarUsuarios(string criterio)
        {
            List<Usuarios> Usuariolist = new List<Usuarios>();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT * FROM Usuarios WHERE Id_usuario LIKE @C OR Nombre_usuario LIKE @C";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@C", "%" + criterio + "%");
                IDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Usuariolist.Add(new Usuarios
                    {
                        Id_usuario = reader.GetInt32(0),
                        Nombre_usuario = reader.GetString(1),
                        Contraseña = reader.GetString(2),
                        Id_rol = reader.GetInt32(3),
                        
                    });
                }
                con.Close();
            }
            return Usuariolist;

        }



        public static int AgregarUsuarios(Usuarios usuarios)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())

            {
                con.Open();

                string sql = ("INSERT INTO usuarios (Nombre_usuario, Contraseña, Id_rol) VALUES (@Nombre_usuario, @Contraseña, @Id_rol)");
                MySqlCommand comando = new MySqlCommand(sql, con);
               
                comando.Parameters.AddWithValue("@Nombre_usuario", usuarios.Nombre_usuario);
                comando.Parameters.AddWithValue("@Contraseña", usuarios.Contraseña);
                comando.Parameters.AddWithValue("@Id_rol", usuarios.Id_rol);

                resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            return resultado;
        }




        public static Usuarios ObtenerUsuarioPorId(int id)
        {
            Usuarios usuario = new Usuarios();
            using (MySqlConnection con = new MySqlConnection())
            {
                con.Open();
                string sql = "SELECT  FROM Usuarios WHERE Id_usuario=@id_ususario";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@Id_aeropuerto", id);
                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    usuario.Id_usuario = reader.GetInt32(0);
                    usuario.Nombre_usuario = reader.GetString(1);
                    usuario.Contraseña = reader.GetString(2);
                    usuario.Id_rol = reader.GetInt32(3);
                    usuario.Nombre_rol = reader.GetString(4);
                }
                con.Close();
            }
            return usuario;
        }


        public static int ModificarUsuarios(Usuarios usuarios)
        {
            int resultado = 0;
            using (MySqlConnection con = new MySqlConnection())
            {
                con.Open();
                string sql = "UPDATE usuarios SET Nombre_usuario=@Nombre_usuario, Contraseña=@Contraseña, Id_rol=@Id_rol WHERE Id_usuario=@Id_usuario";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@Nombre_usuario", usuarios.Nombre_usuario);
                comando.Parameters.AddWithValue("@Contraseña", usuarios.Contraseña);
                comando.Parameters.AddWithValue("@Id_rol", usuarios.Id_rol);
                comando.Parameters.AddWithValue("@Id_usuario", usuarios.Id_usuario);
                resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            return resultado;



        }

        public static int EliminarUsuarios(int id)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "DELETE FROM Usuario WHERE Id_usuario=@Id_usuario";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@Id_usuario", id);
                resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            return resultado;
        }

    }
}
