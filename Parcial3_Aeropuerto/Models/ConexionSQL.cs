using MySqlConnector;

namespace Parcial3_Aeropuerto.Models
{
    public class ConexionSQL
    {
        static string AirportSQL = @"datasource=localhost;port=3306;username=root;password=232100333;database=aeropuertobd";

        public static MySqlConnection Conectar()
        {
            return new MySqlConnection(AirportSQL);
        }
    }
}
