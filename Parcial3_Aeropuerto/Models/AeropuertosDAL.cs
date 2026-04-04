
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MySqlConnector;
using System.Data;
namespace Parcial3_Aeropuerto.Models
{
    public class AeropuertosDAL
    {
        public static List<Aeropuertos> MostrarAeropuertos() {

            List<Aeropuertos> aeropuerto = new List<Aeropuertos>();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT*FROM Aeropuertos";

                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                while(reader.Read())
                {
                    Aeropuertos aeropuertos = new Aeropuertos();
                    aeropuertos.Id_aeropuerto = reader.GetInt32(0);
                    aeropuertos.Nombre_aeropuerto = reader.GetString(1);
                    aeropuertos.Pais=reader.GetString(2);
                    aeropuerto.Add(aeropuertos);
                }
                return aeropuerto;
            }
        }
        public static List<Aeropuertos> BuscarAeropuertos(string criterio)
        {
            List<Aeropuertos> aeropuertos = new List<Aeropuertos>();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT * FROM Aeropuertos WHERE Id_aeropuerto LIKE @C OR Nombre_aeropuerto LIKE @C";

                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@C", "%" + criterio + "%");
                IDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    aeropuertos.Add(new Aeropuertos
                    {
                        Id_aeropuerto = reader.GetInt32(0),
                        Nombre_aeropuerto = reader.GetString(1),
                        Pais = reader.GetString(2)
                    });
                }
                con.Close();
            }
            return aeropuertos;
        }

        public static int InsertarAeropuertos(Aeropuertos aeropuertos)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "INSERT INTO Aeropuertos (Nombre_aeropuerto, Pais) VALUES (@Nombre_aeropuerto, @Pais)";
                MySqlCommand comando = new MySqlCommand(sql, con);

                comando.Parameters.AddWithValue("@Nombre_aeropuerto", aeropuertos.Nombre_aeropuerto );
                comando.Parameters.AddWithValue("@Pais", aeropuertos.Pais);
                resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            return resultado;
        }

        //Falta obtenerDAtos por Id en adelante, solo se ha creado esto XD


        public static Aeropuertos ObtenerAerolineasPorId(int id)
        {
            Aeropuertos aeropuertos = new Aeropuertos();
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();
                string sql = "SELECT * FROM Aeropuertos WHERE Id_aeropuerto=@Id_aeropuerto";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@Id_aeropuerto", id);
                IDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    aeropuertos = new Aeropuertos
                    {
                        Id_aeropuerto = reader.GetInt32(0),
                        Nombre_aeropuerto = reader.GetString(1),
                        Pais = reader.GetString(2),
                    };
                }
                con.Close();
            }
            return aeropuertos;
        }
       
        public static int  ModificarAropuertos(Aeropuertos aeropuertos)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {

                con.Open();
                string sql = "UPDATE Aeropuertos  SET  Nombre_aeropuerto=@Nombre_aeropuerto, Pais=@Pais WHERE Id_aeropuerto= @Id_aeropuerto";

                MySqlCommand comando = new MySqlCommand(sql, con);

                comando.Parameters.AddWithValue("@Nombre_aeropuerto", aeropuertos.Nombre_aeropuerto);
                comando.Parameters.AddWithValue("@Pais", aeropuertos.Pais);
                comando.Parameters.AddWithValue("@Id_aeropuerto", aeropuertos.Id_aeropuerto);
                resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            return resultado;
        }
       

        public static int EliminarAeropuertos(int id)
        {
            int resultado = 0;
            using (MySqlConnection con = ConexionSQL.Conectar())
            {
                con.Open();

                string sql = "DELETE FROM Aeropuertos WHERE Id_aeropuerto=@Id_aeropuerto";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("Id_aeropuerto", id);
                resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            return resultado;

        }

    }





    
}
