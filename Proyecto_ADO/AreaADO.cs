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
    public class AreaADO
    {


        //Creo un objeto de la clase Conexion
        Conexion miConexion = new Conexion();
        SqlConnection conexion = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        SqlDataReader data;

        public DataTable listarArea()
        {
            DataSet dataSet = new DataSet();
            conexion.ConnectionString = miConexion.ObtenerCadenaCnx();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "CRUD_LISTAR_AREA";

            try
            {
                comando.Parameters.Clear();

                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(dataSet, "Area");
                return dataSet.Tables["Area"];

            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }

        }


    }
}
