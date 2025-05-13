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
    public class ProveedorADO
    {
        //Creo un objeto de la clase Conexion
        Conexion miConexion = new Conexion();
        SqlConnection conexion = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        SqlDataReader data;



        public Boolean insertarProveedor(ProveedorBE objProveedorBE)
        {
            try
            {
                conexion.ConnectionString = miConexion.ObtenerCadenaCnx();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "CRUD_INSERTAR_PROVEEDOR";

                //Primero limpiamos los parametros 
                comando.Parameters.Clear();
                //Le pasamos los datos necesarios para insertar proveedor

                comando.Parameters.AddWithValue("@nombreProveedor", objProveedorBE.nombreProveedor);
                comando.Parameters.AddWithValue("@direccion", objProveedorBE.direccion);
                comando.Parameters.AddWithValue("@telefono", objProveedorBE.telefono);
                comando.Parameters.AddWithValue("@celular", objProveedorBE.celular);
                comando.Parameters.AddWithValue("@correoElectronico", objProveedorBE.correoElectronico);
                comando.Parameters.AddWithValue("@estadoProveedor", objProveedorBE.estadoProveedor);
                comando.Parameters.AddWithValue("@personaContacto", objProveedorBE.personaContacto);


                conexion.Open();
                comando.ExecuteReader();
                return true;


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }



        public Boolean actualizarProveedor(ProveedorBE objProveedorBE)
        {
            try
            {
                conexion.ConnectionString = miConexion.ObtenerCadenaCnx();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "CRUD_ACTUALIZAR_PROVEEDOR";

                //Primero limpiamos los parametros 
                comando.Parameters.Clear();
                //Le pasamos los datos necesarios para actualizar proveedor

                comando.Parameters.AddWithValue("@idProveedor", objProveedorBE.idProveedor);
                comando.Parameters.AddWithValue("@nombreProveedor", objProveedorBE.nombreProveedor);
                comando.Parameters.AddWithValue("@direccion", objProveedorBE.direccion);
                comando.Parameters.AddWithValue("@telefono", objProveedorBE.telefono);
                comando.Parameters.AddWithValue("@celular", objProveedorBE.celular);
                comando.Parameters.AddWithValue("@correoElectronico", objProveedorBE.correoElectronico);
                comando.Parameters.AddWithValue("@estadoProveedor", objProveedorBE.estadoProveedor);
                comando.Parameters.AddWithValue("@personaContacto", objProveedorBE.personaContacto);


                conexion.Open();
                comando.ExecuteNonQuery();
                return true;


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

        }



        public Boolean eliminarProveedor(String idProveedor)
        {
            try
            {
                conexion.ConnectionString = miConexion.ObtenerCadenaCnx();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "CRUD_ELIMINAR_PROVEEDOR";

                //Primero limpiamos los parametros 
                comando.Parameters.Clear();
                //Le pasamos los datos necesarios para eliminar proveedor

                comando.Parameters.AddWithValue("@idProveedor", idProveedor);
                conexion.Open();
                comando.ExecuteNonQuery();

                return true;
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }


        public ProveedorBE consultarProveedor(String idProveedor)
        {
            try
            {
                ProveedorBE objProveedorBE = new ProveedorBE();
                conexion.ConnectionString = miConexion.ObtenerCadenaCnx();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "CRUD_CONSULTAR_PROVEEDOR";

                //Primero limpiamos los parametros 
                comando.Parameters.Clear();

                // Agregamos el parámetro necesario para la consulta del producto
                comando.Parameters.AddWithValue("@idProveedor", idProveedor);
                conexion.Open();
                data = comando.ExecuteReader();

                //Primero verificamos si la consulta nos arrogo una fila

                if(data.HasRows)
                {
                    data.Read();
                    objProveedorBE.idProveedor = data["idProveedor"].ToString();
                    objProveedorBE.nombreProveedor = data["nombreProveedor"].ToString();
                    objProveedorBE.direccion = data["direccion"].ToString();
                    objProveedorBE.telefono = data["telefono"].ToString();
                    objProveedorBE.celular = data["celular"].ToString();
                    objProveedorBE.correoElectronico = data["correoElectronico"].ToString();
                    objProveedorBE.estadoProveedor = data["estadoProveedor"].ToString();
                    objProveedorBE.personaContacto = data["personaContacto"].ToString();


                }

                data.Close();
                return objProveedorBE;


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }




        public DataTable listarProveedores()
        {
            DataSet dataSet = new DataSet();
            conexion.ConnectionString = miConexion.ObtenerCadenaCnx();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "CRUD_LISTAR_PROVEEDORES";

            try
            {
                comando.Parameters.Clear();

                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(dataSet, "Proveedor");
                return dataSet.Tables["Proveedor"];

            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }

        }


    }
}
