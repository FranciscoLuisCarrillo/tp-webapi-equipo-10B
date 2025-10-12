using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AccesoDatos
{
    public class Acceso
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public Acceso()
        {

            // CONEXION FRANCISCO
            //conexion = new SqlConnection("server=.; database=CATALOGO_P3_DB; integrated security=true;");
            //comando = new SqlCommand();
            // CONEXION TOMAS
            conexion = new SqlConnection("server=TOMAS;  Database=CATALOGO_P3_DB; Integrated Security=True; TrustServerCertificate=True;");
            comando = new SqlCommand();
            //CONEXION JOAQUIN
            //conexion = new SqlConnection("server=(localdb)\\MSSQLLocalDB ; database=CATALOGO_P3_DB; integrated security=true; TrustServerCertificate=True;");
            //comando = new SqlCommand();

        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
            comando.Parameters.Clear();// esto lo agregue para limpiar los parametros y que no me tire error al ejecutar otra consulta
        }


        // MEtodo para pasar parametros a la consulta y generar pruebas
        public void setAtributo(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        } 

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object ejecutarEscalar()
        {
            comando.Connection = conexion;
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();
                return comando.ExecuteScalar();
            }
            catch (Exception) { throw; }
            finally
            {
                if (conexion.State != ConnectionState.Closed)
                    conexion.Close();
            }
        }

        /// Creado para ejecucion de acciones como insert, delete y update
        public int ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                if(conexion.State != ConnectionState.Open)
                    conexion.Open();
                return comando.ExecuteNonQuery();// devuelve la cantidad de filas afectadas
            }
            catch (Exception ex)
            {
                throw ex;
            }finally
            {
                if (conexion.State != ConnectionState.Closed)
                    conexion.Close();
            }
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }

    }
}
