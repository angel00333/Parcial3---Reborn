using System;
using System.Collections.Generic;
using System.Text;

using MySqlConnector;
using System.Data;

using Parcial3_Aeropuerto.EN;
namespace Parcial3_Aeropuerto.DAL
{
    public class FacturacionDAL
    {
        public static int ModificarFacturacion(Facturacion facturacion)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "UPDATE Facturacion SET Id_Facturacion = @Id_Facturacion, Fecha = @Fecha, Monto = @Monto";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@Id_Facturacion", facturacion.Id_Facturacion);
                comando.Parameters.AddWithValue("@Fecha", facturacion.Fecha);
                comando.Parameters.AddWithValue("@Monto", facturacion.Monto);
                resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            return resultado;
        }

        public static int EliminarFacturacion(int id)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "DELETE FROM Facturacion WHERE Id_Facturacion = @Id_Facturacion";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@Id_Facturacion", id);
                resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            return resultado;
        }

        public static List<Facturacion> MostrarFacturaciones()
        {
            List<Facturacion> Facturaciones = new List<Facturacion>();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT * FROM Facturacion";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Facturacion facturacion = new Facturacion();
                    facturacion.Id_Facturacion = reader.GetInt32(0);
                    facturacion.Fecha = DateOnly.FromDateTime(reader.GetDateTime(1));
                    facturacion.Monto = reader.GetDouble(2);

                }
                con.Close();
                return Facturaciones;

            }
        }

        public static Facturacion ObtenerFacturacionPorId(int id)
        {
            Facturacion facturacion = new Facturacion();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT * FROM Facturacion WHERE Id_Facturacion = @Facturacion";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@Id_Facturacion", id);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    facturacion.Id_Facturacion = reader.GetInt32(0);
                    facturacion.Fecha = DateOnly.FromDateTime(reader.GetDateTime(1));
                    facturacion.Monto = reader.GetDouble(2);
                }
                con.Close();
                return facturacion;
            }
        }
    }
}

