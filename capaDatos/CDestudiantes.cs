using capaEntidad;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace capaDatos
{
    public class CDestudiantes
    {
        //llamado Linea de connexion
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["appConex"].ConnectionString);
        //Variables
        #region "Variables"
        int nCodigo = 0;
        #endregion
        //los metodos del CRUD
        #region "Métodos CRUD"
        public void tryConnection()
        {
            try
            {
                conn.Open();
                MessageBox.Show("Connected");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Problema " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public DataTable lista_es()
        {
            string Rpta = "";
            try
            {
                DataTable Tabla;
                SqlCommand comando = new SqlCommand('sp_listar', conn);
                commando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(comando);
                Resultado = comando.ExecuteReader();
                da.Fill(Tabla);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }
        public string guardar_es(int nCodigo, CEestudiante oEs)
        {
            try
            {
                if (nCodigo == 1) //Nuevo registro
                {
                    SqlCommand comando = new SqlCommand('sp_insertar', conn);
                    commando.CommandType = CommandType.StoredProcedure();
                    comando.Parameters.AddWithValue("@nom", oEs.Nombre);
                    comando.Parameters.AddWithValue("@ape", oEs.Apellido);
                    comando.Parameters.AddWithValue("@mail", oEs.Correo);
                }
                else 
                {
                    SqlCommand comando = new SqlCommand('sp_actualizar', conn);
                    commando.CommandType = CommandType.StoredProcedure();
                    comando.Parameters.AddWithValue("@nom", oEs.Nombre);
                    comando.Parameters.AddWithValue("@ape", oEs.Apellido);
                    comando.Parameters.AddWithValue("@mail", oEs.Correo);
                }
                if (conn.State == ConnectionState.Open) conn.Close;
                conn.Open();
                //Esta linea devuelve un mensaje en caso de que una o mas lineas son afectadas durantes la ejecución.
                Rpta = comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo ingresar el registro";
            catch (Exception ex)
            {
                Rpta = ex.Message;
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close;
            }
            return Rpta;
        }
        public string actualizar_es(int nCodigo)
        {
            try
            {
                    SqlCommand comando = new SqlCommand('sp_insertar', conn);
                    commando.CommandType = CommandType.StoredProcedure();
                    comando.Parameters.AddWithValue("@nom", oEs.Nombre);
                    comando.Parameters.AddWithValue("@ape", oEs.Apellido);
                    comando.Parameters.AddWithValue("@mail", oEs.Correo);

                    SqlCommand comando = new SqlCommand('sp_actualizar', conn);
                    commando.CommandType = CommandType.StoredProcedure();
                    comando.Parameters.AddWithValue("@nom", oEs.Nombre);
                    comando.Parameters.AddWithValue("@ape", oEs.Apellido);
                    comando.Parameters.AddWithValue("@mail", oEs.Correo);

                if (conn.State == ConnectionState.Open) conn.Close;
                conn.Open();
                //Esta linea devuelve un mensaje en caso de que una o mas lineas son afectadas durantes la ejecución.
                Rpta = comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo ingresar el registro";
            catch (Exception ex)
            {
                Rpta = ex.Message;
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close;
            }
            return Rpta;
        }
        public string eliminar_es(int nCodigo)
        {
            try
            {
                SqlCommand comando = new SqlCommand('sp_eliminar', conn);
                commando.CommandType = CommandType.StoredProcedure();
                comando.Parameters.AddWithValue("@id", nCodigo)
                if (conn.State == ConnectionState.Open) conn.Close;
                conn.Open();
                //Esta linea devuelve un mensaje en caso de que una o mas lineas son afectadas durantes la ejecución.
                Rpta = comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo ingresar el registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally 
            {
                if (conn.State == ConnectionState.Open) conn.Close;
            }
            return Rpta;
        }
        #endregion
    }
}