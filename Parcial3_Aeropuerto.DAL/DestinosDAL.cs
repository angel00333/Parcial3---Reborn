using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;
using System.Data;

using Parcial3_Aeropuerto.EN;
namespace Parcial3_Aeropuerto.DAL
{
    public class DestinosDAL
    {
        public static int AgregarDestino(Destinos destinos)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "INSERT INTO Destinos ( Id_aeropuerto, Nombre_destino) VALUES ( @Id_aeropuerto, @Nombre_destino)";
                MySqlCommand comando = new MySqlCommand(sql, con);
               
                comando.Parameters.AddWithValue("@Id_aeropuerto", destinos.Id_aeropuerto);
                comando.Parameters.AddWithValue("@Nombre_destino", destinos.Nombre_destino);
                resultado = comando.ExecuteNonQuery();
                con.Close();

            }
            return resultado;
        }

        public static int ModificarDestino(Destinos destinos)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "UPDATE Destinos SET Nombre_destino = @Nombre_destino WHERE Id_destino = @Id_destino";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@Id_destino", destinos.Id_destino);
                comando.Parameters.AddWithValue("@Id_aeropuerto", destinos.Id_aeropuerto);
                comando.Parameters.AddWithValue("@Nombre_destino", destinos.Nombre_destino);
                resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            return resultado;
        }

        public static int EliminarDestino(int id)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "DELETE FROM Destinos WHERE Id_destino = @Id_destino";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@Id_destino", id);
                resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            return resultado;
        }

        public static List<Destinos> MostrarDestinos()
        {
            List<Destinos> tdestinos = new List<Destinos>();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT * FROM Destinos";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Destinos destinos = new Destinos();
                    destinos.Id_destino = reader.GetInt32(0);
                    destinos.Id_aeropuerto = reader.GetInt32(1);
                    destinos.Nombre_destino = reader.GetString(2);
                    tdestinos.Add(destinos);
                }
                con.Close();
            }
            return tdestinos;
        }

        public static Destinos ObtenerDestinoPorId(int id)
        {
            Destinos destinos = new Destinos();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT * FROM Destinos WHERE Id_destino = @Id_destino";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@Id_destino", id);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    destinos.Id_destino = reader.GetInt32(0);
                    destinos.Id_aeropuerto = reader.GetInt32(1);
                    destinos.Nombre_destino = reader.GetString(2);
                }
                con.Close();
                return destinos;
            }

        }

        public static List<Destinos> BuscarDestinos(string criterio)
        {
            List<Destinos> tdestinos = new List<Destinos>();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT * FROM Destinos WHERE Id_destino LIKE @Criterio OR Nombre_destino LIKE @Criterio";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");
                IDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Destinos destinos = new Destinos();
                    destinos.Id_destino = reader.GetInt32(0);
                    destinos.Id_aeropuerto = reader.GetInt32(1);
                    destinos.Nombre_destino = reader.GetString(2);
                    tdestinos.Add(destinos);
                }
                con.Close();
                return tdestinos;
            }
            
        }
    }
}
