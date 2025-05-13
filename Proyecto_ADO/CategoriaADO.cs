using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//agregar
using System.Data;
using System.Data.SqlClient;
using Proyecto_BE;


namespace Proyecto_ADO
{
    public class CategoriaADO
    {

        //Creo un objeto de la clase Conexion
        Conexion miConexion = new Conexion();
        SqlConnection conexion = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        SqlDataReader data;


        public DataTable listarCategoria()
        {
            DataSet dataSet = new DataSet();
            conexion.ConnectionString = miConexion.ObtenerCadenaCnx();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "CRUD_LISTAR_CATEGORIA";

            try
            {
                comando.Parameters.Clear();

                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(dataSet, "Categoria");
                return dataSet.Tables["Categoria"];

            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }

        }


    }
}
