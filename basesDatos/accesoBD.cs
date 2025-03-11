using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace basesDatos
{
    public class accesoBD
    {

        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector {  get; set; }

        public accesoBD() 
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database = CentroEstetica; integrated security = true");
            comando = new SqlCommand();
        }


        public void setConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }


        public void solicitarDatos()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                Lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
               comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void setParemtros(string atributo, object valor)
        {
            comando.Parameters.AddWithValue(atributo, valor);
        }


        public void cerrarConexion()
        {
            if (lector != null)
            {
                conexion.Close();
            }

            conexion.Close();

        }



    }
}
