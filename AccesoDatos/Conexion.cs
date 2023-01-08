using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace AccesoDatos
{
    public class Conexion
    {

        public MySqlConnection connection;

        public bool Conectar() {
           
            try
            {
                var configurationBuilder = new ConfigurationBuilder();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                configurationBuilder.AddJsonFile(path, false);

                var root = configurationBuilder.Build();

              //  string cadenaConexion = "server=localhost; database=dbuser; user=root; password=280641;port=3306;";
                connection = new MySqlConnection(root.GetConnectionString("MySqlConnection"));

                connection.Open();
                return true;
            }
            catch{
                return false;
            }
           
        }

        public bool DesConectar()
        {
           
            try
            {
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public DataTable EjecutarConsulta(string procedimiento,List<Parametro> parametros = null) {
            Conectar();

            DataTable datos = new DataTable();
            try
            {
                MySqlCommand comando = new MySqlCommand(procedimiento, connection);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                if (parametros!= null) {
                    foreach (Parametro parametro in parametros)
                    {
                        comando.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }                
                MySqlDataReader lector = comando.ExecuteReader();               
                datos.Load(lector);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro al traer datos de user" + e.Message);
            }
            finally
            {
                DesConectar();
            }

            return datos;

        }


        public bool EjecutarTransaccion(string procedimiento, List<Parametro> parametros = null)
        {
            Conectar();

            try
            {
                MySqlCommand comando = new MySqlCommand(procedimiento, connection);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (Parametro parametro in parametros)
                    {
                        comando.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }
                 comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro al insertar datos de user" + e.Message);
                return false;
            }
            finally
            {
                DesConectar();
            }
        }

    }
}