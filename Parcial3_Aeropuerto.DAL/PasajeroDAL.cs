using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;
using System.Data;

using Parcial3_Aeropuerto.EN;

namespace Parcial3_Aeropuerto.DAL
{
    public class PasajeroDAL
    {
        public static int AgregarPasajero(Pasajero pasajero)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "INSERT INTO Pasajeros (Nombre, Apellido, Pasaporte, Edad, Pais, Visa)" + "VALUES (@Nombre, @Apellido, @Pasaporte, @Edad, @Pais, @Visa)";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@Nombre", pasajero.Nombre);
                comando.Parameters.AddWithValue("@Apellido", pasajero.Apellido);
                comando.Parameters.AddWithValue("@Pasaporte", pasajero.Pasaporte);
                comando.Parameters.AddWithValue("@Edad", pasajero.Edad);
                comando.Parameters.AddWithValue("@Pais", pasajero.Pais);
                comando.Parameters.AddWithValue("@Visa", pasajero.Visa);
                resultado = comando.ExecuteNonQuery();
                con.Close();

            }
            return resultado;
        }

        public static int ModificarPasajero(Pasajero pasajero)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "UPDATE Pasajeros SET Nombre=@Nombre, Apellido=@Apellido, Pasaporte=@Pasaporte, Edad=@Edad, Pais=@Pais, Visa=@Visa WHERE Id_pasajero=@Id_pasajero";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@Nombre", pasajero.Nombre);
                comando.Parameters.AddWithValue("@Apellido", pasajero.Apellido);
                comando.Parameters.AddWithValue("@Pasaporte", pasajero.Pasaporte);
                comando.Parameters.AddWithValue("@Edad", pasajero.Edad);
                comando.Parameters.AddWithValue("@Pais", pasajero.Pais);
                comando.Parameters.AddWithValue("@Visa", pasajero.Visa);
                comando.Parameters.AddWithValue("@Id_pasajero", pasajero.Id_pasajero);
                resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            return resultado;
        }

        public static int EliminarPasajero(int id)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "DELETE FROM Pasajeros WHERE Id_pasajero=@Id_pasajero";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@Id_pasajero", id);
                resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            return resultado;
        }

        public static List<Pasajero> MostrarPasajeros()
        {
            List<Pasajero> pasajeros = new List<Pasajero>();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT * FROM Pasajeros";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Pasajero pasajero = new Pasajero();
                    pasajero.Id_pasajero = reader.GetInt32(0);
                    pasajero.Nombre = reader.GetString(1);
                    pasajero.Apellido = reader.GetString(2);
                    pasajero.Pasaporte = reader.GetString(3);
                    pasajero.Edad = reader.GetInt32(4);
                    pasajero.Pais = reader.GetString(5);
                    pasajero.Visa = reader.GetString(6);
                    pasajeros.Add(pasajero);

                }
                con.Close();
                return pasajeros;
            }
        }

        public static Pasajero ObtenerPasajeroPorId(int id)
        {
            Pasajero pasajero = new Pasajero ();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT * FROM Pasajeros WHERE Id_pasajero=@Id_pasajero";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@Id_pasajero", id);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    pasajero.Id_pasajero = reader.GetInt32(0);
                    pasajero.Nombre = reader.GetString(1);
                    pasajero.Apellido = reader.GetString(2);
                    pasajero.Pasaporte = reader.GetString(3);
                    pasajero.Edad = reader.GetInt32(4);
                    pasajero.Pais = reader.GetString(5);
                    pasajero.Visa = reader.GetString(6);
                }
                con.Close();
                return pasajero;
            }
        }

        public static List<Pasajero> BuscarPasajeros(string criterio)
             {
                  List<Pasajero> pasajeros = new List<Pasajero>();
                    using (MySqlConnection con = ConexionSQL.Conectar())
                    {
                        con.Open();
                        string sql = "SELECT * FROM Pasajeros WHERE Nombre LIKE @Criterio OR Apellido LIKE @Criterio";
                        MySqlCommand comando = new MySqlCommand(sql, con);
                        comando.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");

                            comando.CommandType = CommandType.Text;
                            IDataReader reader = comando.ExecuteReader();
                        while (reader.Read())
                        {
                            Pasajero pasajero = new Pasajero();
                            pasajero.Id_pasajero = reader.GetInt32(0);
                            pasajero.Nombre = reader.GetString(1);
                            pasajero.Apellido = reader.GetString(2);
                            pasajero.Pasaporte = reader.GetString(3);
                            pasajero.Edad = reader.GetInt32(4);
                            pasajero.Pais = reader.GetString(5);
                            pasajero.Visa = reader.GetString(6);
                            pasajeros.Add(pasajero);
                        }
                        con.Close();
                        return pasajeros;
            
                    }


             }

        public static bool PasajeroTieneReserva(int id)
        {
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();

                string sql = "SELECT COUNT(*) FROM Reservas WHERE Id_pasajero = @Id_pasajero";

                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@Id_pasajero", id);

                int cantidad = Convert.ToInt32(comando.ExecuteScalar());

                return cantidad > 0;
            }
        }
    }
}
