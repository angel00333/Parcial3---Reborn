using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;
using System.Data;

using Parcial3_Aeropuerto.EN;

namespace Parcial3_Aeropuerto.DAL
{
    public class VuelosDAL
    {
        public static int AgregarVuelo(Vuelos vuelos)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "INSERT INTO vuelos (id_vuelo, id_avion, id_destino, cantidad_pasajeros, fecha, tiempo_estimado, estado, hora_inicio) VALUES (@id_vuelo, @id_avion, @id_destino, @cantidad_pasajeros, @fecha, @tiempo_estimado, @estado, @hora_inicio)";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@id_vuelo", vuelos.Id_vuelo);
                comando.Parameters.AddWithValue("@id_avion", vuelos.Aviones.Id_avion);
                comando.Parameters.AddWithValue("@id_destino", vuelos.Destinos.Id_destino);
                comando.Parameters.AddWithValue("@cantidad_pasajeros", vuelos.Cantidad_pasajeros);
                comando.Parameters.AddWithValue("@fecha", vuelos.Fecha);
                comando.Parameters.AddWithValue("@tiempo_estimado", vuelos.Tiempo_estimado);
                comando.Parameters.AddWithValue("@estado", vuelos.Estado);
                comando.Parameters.AddWithValue("@hora_inicio", vuelos.Hora_inicio);
                resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            return resultado;
        }

        public static int ModificarVuelo(Vuelos vuelos)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "UPDATE vuelos SET id_avion = @id_avion, id_destino = @id_destino, cantidad_pasajeros = @cantidad_pasajeros, fecha = @fecha, tiempo_estimado = @tiempo_estimado, estado = @estado, hora_inicio = @hora_inicio WHERE id_vuelo = @id_vuelo";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@id_vuelo", vuelos.Id_vuelo);
                comando.Parameters.AddWithValue("@id_avion", vuelos.Aviones.Id_avion);
                comando.Parameters.AddWithValue("@id_destino", vuelos.Destinos.Id_destino);
                comando.Parameters.AddWithValue("@cantidad_pasajeros", vuelos.Cantidad_pasajeros);
                comando.Parameters.AddWithValue("@fecha", vuelos.Fecha);
                comando.Parameters.AddWithValue("@tiempo_estimado", vuelos.Tiempo_estimado);
                comando.Parameters.AddWithValue("@estado", vuelos.Estado);
                comando.Parameters.AddWithValue("@hora_inicio", vuelos.Hora_inicio);
                resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            return resultado;
        }

        public static int EliminarVuelo(int id)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "DELETE FROM vuelos WHERE id_vuelo = @id_vuelo";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@id_vuelo", id);
                resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            return resultado;
        }

        public static List<Vuelos> MostrarVuelos()
        {
            List<Vuelos> tvuelos = new List<Vuelos>();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT * FROM vuelos";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                using (MySqlDataReader reader = comando.ExecuteReader()) {
                    while (reader.Read())
                    {
                        Vuelos vuelos = new Vuelos();
                        vuelos.Id_vuelo = reader.GetInt32(0);
                        vuelos.Aviones = AvionesDAL.ObtenerAvionesPorId(reader.GetInt32(1));
                        vuelos.Destinos = DestinosDAL.ObtenerDestinoPorId(reader.GetInt32(2));
                        vuelos.Cantidad_pasajeros = reader.GetInt32(3);
                        vuelos.Fecha = DateOnly.FromDateTime(reader.GetDateTime(4));
                        vuelos.Tiempo_estimado = reader.GetDateTime(5);
                        vuelos.Estado = reader.GetString(6);
                        vuelos.Hora_inicio = TimeOnly.FromTimeSpan(reader.GetTimeSpan(7));
                        tvuelos.Add(vuelos);
                    }
                    con.Close();
                    return tvuelos;
                }

            }
        }

        public static Vuelos ObtenerVueloPorId (int id)
        {
            Vuelos vuelos = new Vuelos();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT * FROM Vuelos WHERE Id_vuelo=@Id_vuelo ";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@Id_vuelo", id);
                comando.CommandType = CommandType.Text;
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        vuelos.Id_vuelo = reader.GetInt32(0);
                        vuelos.Aviones = AvionesDAL.ObtenerAvionesPorId(reader.GetInt32(1));
                        vuelos.Destinos = DestinosDAL.ObtenerDestinoPorId(reader.GetInt32(2));
                        vuelos.Cantidad_pasajeros = reader.GetInt32(3);
                        vuelos.Fecha = DateOnly.FromDateTime(reader.GetDateTime(4));
                        vuelos.Tiempo_estimado = reader.GetDateTime(5);
                        vuelos.Estado = reader.GetString(6);
                        vuelos.Hora_inicio = TimeOnly.FromTimeSpan(reader.GetTimeSpan(7));
                    }
                    con.Close();
                    return vuelos;
                }
            }

        }
    }
}