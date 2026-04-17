using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;
using Parcial3_Aeropuerto.DAL;
using System.Data;

namespace Parcial3_Aeropuerto.Models
{
    public class ReservasDAL
    {
        public static int AgregarReserva(Reservas reserva)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "INSERT INTO Reservas (Id_pasajero, Id_vuelo, Fecha, Costo, Id_usuario)" + "VALUES (@Id_pasajero, @Id_vuelo, @Fecha, @Costo, @Id_usuario)";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@Id_pasajero", reserva.Id_pasajero);
                comando.Parameters.AddWithValue("@Id_vuelo", reserva.Id_vuelo);
                comando.Parameters.AddWithValue("@Fecha", reserva.Fecha);
                comando.Parameters.AddWithValue("@Costo", reserva.Costo);
                comando.Parameters.AddWithValue("@Id_usuario", reserva.Id_usuario);
                resultado = comando.ExecuteNonQuery();
                con.Close();

            }
            return resultado;
        }

        public static int ModificarReserva(Reservas reserva)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "UPDATE Reservas SET Id_pasajero=@Id_pasajero, Id_vuelo=@Id_vuelo, Fecha=@Fecha, Costo=@Costo, Id_usuario=@Id_usuario WHERE Id_reserva=@Id_reserva";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@Id_pasajero", reserva.Id_pasajero);
                comando.Parameters.AddWithValue("@Id_vuelo", reserva.Id_vuelo);
                comando.Parameters.AddWithValue("@Fecha", reserva.Fecha);
                comando.Parameters.AddWithValue("@Costo", reserva.Costo);
                comando.Parameters.AddWithValue("@Id_usuario", reserva.Id_usuario);
                comando.Parameters.AddWithValue("@Id_reserva", reserva.Id_reserva);
                resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            return resultado;
        }

        public static int EliminarReserva(int id)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "DELETE FROM Reservas WHERE Id_reserva=@Id_reserva";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@Id_reserva", id);
                resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            return resultado;
        }

        public static List<Reservas> MostrarReservas()
        {
            List<Reservas> reservas = new List<Reservas>();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT * FROM Reservas";
                MySqlCommand comando = new MySqlCommand(sql, con);
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Reservas reserva = new Reservas
                    {
                        Id_reserva = reader.GetInt32("Id_reserva"),
                        Id_pasajero = reader.GetInt32("Id_pasajero"),
                        Id_vuelo = reader.GetInt32("Id_vuelo"),
                        Fecha = reader.GetDateOnly("Fecha"),
                        Costo = reader.GetDouble("Costo"),
                        Id_usuario = reader.GetInt32("Id_usuario")
                    };
                    reservas.Add(reserva);
                }
                con.Close();
                return reservas;
            }
        }

        public static Reservas ObtenerReservaPorId(int id)
        {
            Reservas reserva = new Reservas();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT * FROM Reservas WHERE Id_reserva=@Id_reserva";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@Id_reserva", id);
                comando.CommandType = CommandType.Text;
                MySqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    reserva = new Reservas
                    {
                        Id_reserva = reader.GetInt32("Id_reserva"),
                        Id_pasajero = reader.GetInt32("Id_pasajero"),
                        Id_vuelo = reader.GetInt32("Id_vuelo"),
                        Fecha = reader.GetDateOnly("Fecha"),
                        Costo = reader.GetDouble("Costo"),
                        Id_usuario = reader.GetInt32("Id_usuario")
                    };
                }
                con.Close();
                return reserva;
            }
        }

        public static List<Reservas> BuscarReserva(string criterio)
        {
            List<Reservas> reservas = new List<Reservas>();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT * FROM Reservas WHERE Id_pasajero LIKE @Criterio OR Id_vuelo LIKE @Criterio OR Fecha LIKE @Criterio OR Costo LIKE @Criterio OR Id_usuario LIKE @Criterio";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");
                comando.CommandType = CommandType.Text;
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Reservas reserva = new Reservas();
                    reserva.Id_reserva = reader.GetInt32(0);
                    reserva.Id_pasajero = reader.GetInt32(1);
                    reserva.Id_vuelo = reader.GetInt32(2);
                    reserva.Fecha = reader.GetDateOnly(3);
                    reserva.Costo = reader.GetDouble(4);
                    reserva.Id_usuario = reader.GetInt32(5);
                    reservas.Add(reserva);
                }
                con.Close();
                return reservas;
            }
        }
    }
}
