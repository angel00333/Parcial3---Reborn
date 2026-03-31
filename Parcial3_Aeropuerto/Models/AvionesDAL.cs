
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using MySqlConnector;
using System.Data; //libreria para conectar con mysql
namespace Parcial3_Aeropuerto.Models
{
    public class AvionesDAL
    {
        public static List<Aviones> MostrarAviones()
        {
            List<Aviones> avioneslist = new List<Aviones>();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT * FROM Aviones";

                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader =comando.ExecuteReader();

                while (reader.Read())
                {
                    Aviones aviones = new Aviones();
                    aviones.Id_avion = reader.GetInt32(0);
                    aviones.Id_aerolinea = reader.GetInt32(1);
                    aviones. Capacidad = reader.GetInt32(2);                   
                    avioneslist.Add(aviones);
                }
                con.Close();
            }
            return avioneslist;
        }

        public static List<Aviones> BuscarAviones(string criterio)
        {
            List<Aviones> avioneslist = new List<Aviones>();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT*FROM Aviones WHERE Id_avion LIKE @C OR Capacidad LIKE @C";
                MySqlCommand comando = new MySqlCommand(sql, con);

                comando.Parameters.AddWithValue("@C", "%" + criterio + "%");

                IDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    avioneslist.Add(new Aviones
                    {
                        Id_avion = reader.GetInt32(0),
                        Id_aerolinea = reader.GetInt32(1),
                        Capacidad = reader.GetInt32(2)

                    });
                }
                con.Close();


            }
            return avioneslist;

        }

        public static int InsertarAviones(Aviones aviones)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "INSERT INTO aviones(Id_aerolinea, Capacidad) VALUES (@id_aerolinea, @capacidad)";

                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@id_aerolinea", aviones.Id_aerolinea);
                comando.Parameters.AddWithValue("@capacidad", aviones.Capacidad);
                resultado = comando.ExecuteNonQuery();
                con.Close();
            }

            return resultado;
        }

        public static int ModificarAviones(Aviones aviones)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "UPDATE Aviones SET Id_aerolinea=@id_aerolinea, Capacidad=@capacidad WHERE Id_avion = @id_avion ";

                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@id_aerolinea", aviones.Id_aerolinea);
                comando.Parameters.AddWithValue("@capacidad", aviones.Capacidad);
                comando.Parameters.AddWithValue("@id_avion", aviones.Id_avion);
                resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            return resultado;

        }

        public static Aviones ObtenerAvionesPorID(int id)
        {
            Aviones aviones = new Aviones();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT*FROM Aviones where Id_avion = @id_avion";
                MySqlCommand comando = new MySqlCommand(sql, con);

                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@id_avion", id);

                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {


                    aviones.Id_avion = reader.GetInt32(0);
                    aviones.Id_aerolinea = reader.GetInt32(1);
                    aviones.Capacidad = reader.GetInt32(2);

                }
                con.Close();
            }
            return aviones;

        }
        public static int EliminarAviones(int id)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "DELETE FROM Aviones WHERE Id_avion=@id_avion";

                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.CommandType = CommandType.Text;

                comando.Parameters.AddWithValue("@id_avion", id);
                resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            return resultado;
        }


    }
}
