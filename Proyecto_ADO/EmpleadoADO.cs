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
    public class EmpleadoADO
    {

        //Creo un objeto de la clase Conexion
        Conexion miConexion = new Conexion();
        SqlConnection conexion = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        SqlDataReader data;


        public Boolean insertarEmpleado(EmpleadoBE objEmpleadoBE)
        {
            try
            {
                conexion.ConnectionString = miConexion.ObtenerCadenaCnx();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "CRUD_INSERTAR_EMPLEADO";

                //Primero limpiamos los parametros 
                comando.Parameters.Clear();
                //Le pasamos los datos necesarios para insertar empleados
                comando.Parameters.AddWithValue("@idArea", objEmpleadoBE.idArea);
                comando.Parameters.AddWithValue("@nombre", objEmpleadoBE.nombre);
                comando.Parameters.AddWithValue("@apellidoPaterno", objEmpleadoBE.apellidoPaterno);
                comando.Parameters.AddWithValue("@apellidoMaterno", objEmpleadoBE.apellidoMaterno);
                comando.Parameters.AddWithValue("@DNI", objEmpleadoBE.DNI);
                comando.Parameters.AddWithValue("@fechaNacimiento", objEmpleadoBE.fechaNacimiento);
                comando.Parameters.AddWithValue("@sexo", objEmpleadoBE.sexo);
                comando.Parameters.AddWithValue("@direccion", objEmpleadoBE.direccion);
                comando.Parameters.AddWithValue("@telefono", objEmpleadoBE.telefono);
                comando.Parameters.AddWithValue("@telefonoEmergencia", objEmpleadoBE.telefonoEmergencia);
                comando.Parameters.AddWithValue("@correoElectronico", objEmpleadoBE.correoElectronico);
                comando.Parameters.AddWithValue("@puesto", objEmpleadoBE.puesto);
                comando.Parameters.AddWithValue("@fechaContratacion", objEmpleadoBE.fechaContratacion);
                comando.Parameters.AddWithValue("@estado", objEmpleadoBE.estado);
                comando.Parameters.AddWithValue("@salario", objEmpleadoBE.salario);
                
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


        public Boolean actualizarEmpleado(EmpleadoBE objEmpleadoBE)
        {

            try
            {
                conexion.ConnectionString = miConexion.ObtenerCadenaCnx();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "CRUD_ACTUALIZAR_EMPLEADO";

                //Primero limpiamos los parametros 
                comando.Parameters.Clear();

                //Agregamos los parametros requeridos para la actualizacion
                comando.Parameters.AddWithValue("@idEmpleado", objEmpleadoBE.idEmpleado);
                comando.Parameters.AddWithValue("@idArea", objEmpleadoBE.idArea);
                comando.Parameters.AddWithValue("@nombre", objEmpleadoBE.nombre);
                comando.Parameters.AddWithValue("@apellidoPaterno", objEmpleadoBE.apellidoPaterno);
                comando.Parameters.AddWithValue("@apellidoMaterno", objEmpleadoBE.apellidoMaterno);
                comando.Parameters.AddWithValue("@DNI", objEmpleadoBE.DNI);
                comando.Parameters.AddWithValue("@fechaNacimiento", objEmpleadoBE.fechaNacimiento);
                comando.Parameters.AddWithValue("@sexo", objEmpleadoBE.sexo);
                comando.Parameters.AddWithValue("@direccion", objEmpleadoBE.direccion);
                comando.Parameters.AddWithValue("@telefono", objEmpleadoBE.telefono);
                comando.Parameters.AddWithValue("@telefonoEmergencia", objEmpleadoBE.telefonoEmergencia);
                comando.Parameters.AddWithValue("@correoElectronico", objEmpleadoBE.correoElectronico);
                comando.Parameters.AddWithValue("@puesto", objEmpleadoBE.puesto);
                comando.Parameters.AddWithValue("@fechaContratacion", objEmpleadoBE.fechaContratacion);
                comando.Parameters.AddWithValue("@estado", objEmpleadoBE.estado);
                comando.Parameters.AddWithValue("@salario", objEmpleadoBE.salario);


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



        public Boolean eliminarEmpleado(String idEmpleado)
        {
            try
            {
                conexion.ConnectionString = miConexion.ObtenerCadenaCnx();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "CRUD_ELIMINAR_EMPLEADO";

                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@idEmpleado", idEmpleado);
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



        public EmpleadoBE consultarEmpleado(String idEmpleado)
        {
            try
            {
                EmpleadoBE objEmpleadoBE = new EmpleadoBE();    
                conexion.ConnectionString = miConexion.ObtenerCadenaCnx();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "CRUD_CONSULTAR_EMPLEADO";

                // Primero limpiamos los parámetros 
                comando.Parameters.Clear();


                // Agregamos el parámetro necesario para la consulta del producto
                comando.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                conexion.Open();
                data = comando.ExecuteReader();

                //Primero verificamos si la consulta nos arrogo una fila
                if (data.HasRows)
                {
                    data.Read();
                    objEmpleadoBE.idEmpleado = data["idEmpleado"].ToString();
                    objEmpleadoBE.idArea = data["idArea"].ToString();
                    objEmpleadoBE.nombre = data["nombre"].ToString();
                    objEmpleadoBE.apellidoPaterno = data["apellidoPaterno"].ToString();
                    objEmpleadoBE.apellidoMaterno = data["apellidoMaterno"].ToString();
                    objEmpleadoBE.DNI = data["DNI"].ToString() ;
                    objEmpleadoBE.fechaNacimiento = Convert.ToDateTime(data["fechaNacimiento"].ToString());
                    objEmpleadoBE.sexo = data["sexo"].ToString();
                    objEmpleadoBE.direccion = data["direccion"].ToString();
                    objEmpleadoBE.telefono = data["telefono"].ToString();
                    objEmpleadoBE.telefonoEmergencia = data["telefonoEmergencia"].ToString();
                    objEmpleadoBE.correoElectronico = data["correoElectronico"].ToString();
                    objEmpleadoBE.puesto = data["puesto"].ToString();
                    objEmpleadoBE.fechaContratacion = Convert.ToDateTime(data["fechaContratacion"]);
                    objEmpleadoBE.estado = data["estado"].ToString();
                    objEmpleadoBE.salario = Convert.ToInt32(data["salario"]);

                }

                data.Close();
                return objEmpleadoBE;

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


        public DataTable listarEmpleados()
        {
            try
            {
                DataSet data = new DataSet();
                conexion.ConnectionString = miConexion.ObtenerCadenaCnx();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "CRUD_LISTAR_EMPLEADOS";
                comando.Parameters.Clear();
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(data, "empleados");
                return data.Tables["empleados"];




            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
