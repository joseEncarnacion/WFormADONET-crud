using System.Configuration;
using System.Data.SqlClient;

namespace capaDatos
{
    public class CDestudiantes
    {
        //llamado Linea de connexion
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["appConex"].ConnectionString);

        //los metodos del crud
        
    }
}