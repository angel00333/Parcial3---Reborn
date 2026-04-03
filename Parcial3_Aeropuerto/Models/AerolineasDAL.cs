
using System.Data;
using MySqlConnector;

namespace Parcial3_Aeropuerto.Models
{
    public class AerolineasDAL
    {
        public static List<Aerolineas> MostrarAerolineas()
        {
            List<Aerolineas> aerolineaslist = new List<Aerolineas>();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT * FROM Aerolineas";

                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Aerolineas aerolineas = new Aerolineas();
                    aerolineas.Id_aerolinea = reader.GetInt32(0);
                    aerolineas.Nombre_aerolinea = reader.GetString(1);
                    aerolineaslist.Add(aerolineas);
                }
                con.Close();
            }
            return aerolineaslist;
        }

        public static List<Aerolineas> BuscarAerolineas(string criterio)
        {
            List<Aerolineas> aerolineaslist = new List<Aerolineas>();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT * FROM Aerolineas WHERE Id_aerolinea LIKE @C OR Nombre_aerolinea LIKE @C";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@C", "%" + criterio + "%");
                IDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    aerolineaslist.Add(new Aerolineas
                    {
                        Id_aerolinea = reader.GetInt32(0),
                        Nombre_aerolinea = reader.GetString(1)
                    });
                }
                con.Close();
            }
            return aerolineaslist;

        }


        public static int InsertarAerolineas(Aerolineas aerolineas)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "INSERT INTO Aerolineas (Nombre_aerolinea) VALUES (@Nombre_aerolinea)";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@Nombre_aerolinea", aerolineas.Nombre_aerolinea);
                resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            return resultado;
        }

        public static int EliminarAerolineas(int id)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "DELETE FROM Aerolineas WHERE Id_aerolinea=@Id_aerolinea";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@Id_aerolinea", id);
                resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            return resultado;
        }

        public static int ModificarAerolineas(Aerolineas aerolineas)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "UPDATE Aerolineas SET Nombre_aerolinea=@Nombre_aerolinea WHERE Id_aerolinea=@Id_aerolinea";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@Nombre_aerolinea", aerolineas.Nombre_aerolinea);
                comando.Parameters.AddWithValue("@Id_aerolinea", aerolineas.Id_aerolinea);
                resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            return resultado;
        }public static Aerolineas ObtenerAerolineasPorId(int id)
        {
            Aerolineas aerolineas = new Aerolineas();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT * FROM Aerolineas WHERE Id_aerolinea=@Id_aerolinea";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@Id_aerolinea", id);
                IDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    aerolineas = new Aerolineas
                    {
                        Id_aerolinea = reader.GetInt32(0),
                        Nombre_aerolinea = reader.GetString(1)
                    };
                }
                con.Close();
            }
            return aerolineas;

        }
    }
}
