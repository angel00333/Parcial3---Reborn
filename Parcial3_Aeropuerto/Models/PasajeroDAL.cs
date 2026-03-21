using MySqlConnector;

namespace Parcial3_Aeropuerto.Models
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
                string sql = "UPDATE Pasajeros SET Nombre=@Nombre, Apellido=@Apellido, Pasaporte=@Pasaporte, Edad=@Edad, Pais=@Pais, Visa=@Visa WHERE Id=@Id";
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@Nombre", pasajero.Nombre);
                comando.Parameters.AddWithValue("@Apellido", pasajero.Apellido);
                comando.Parameters.AddWithValue("@Pasaporte", pasajero.Pasaporte);
                comando.Parameters.AddWithValue("@Edad", pasajero.Edad);
                comando.Parameters.AddWithValue("@Pais", pasajero.Pais);
                comando.Parameters.AddWithValue("@Visa", pasajero.Visa);
                comando.Parameters.AddWithValue("@Id", pasajero.Id);
                resultado = comando.ExecuteNonQuery();
                con.Close();
            }
            return resultado;
        }
    }
}
