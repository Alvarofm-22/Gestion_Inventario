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
    public class ProductoADO
    {
        //Creo un objeto de la clase Conexion
        Conexion miConexion = new Conexion();
        SqlConnection conexion = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        SqlDataReader data;


        public Boolean insertarProducto(ProductoBE objProductoBE)
        {
            try
            {
                conexion.ConnectionString = miConexion.ObtenerCadenaCnx();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "CRUD_INSERTAR_PRODUCTO";

                //Primero limpiamos los parametros 
                comando.Parameters.Clear();
                //Le pasamos los datos necesarios para insertar un nuevo producto
                comando.Parameters.AddWithValue("@idCategoria", objProductoBE.idCategoria);
                comando.Parameters.AddWithValue("@idProveedor", objProductoBE.idProveedor);
                comando.Parameters.AddWithValue("@idArea", objProductoBE.idArea);
                comando.Parameters.AddWithValue("@nombreProducto", objProductoBE.nombreProducto);
                comando.Parameters.AddWithValue("@descripcion", objProductoBE.descripcion);
                comando.Parameters.AddWithValue("@precioCompra", objProductoBE.precioCompra);
                comando.Parameters.AddWithValue("@precioVenta", objProductoBE.precioVenta);
                comando.Parameters.AddWithValue("@stock", objProductoBE.stock);
                comando.Parameters.AddWithValue("@fechaIngreso", objProductoBE.fechaIngreso);

                // Validar y asignar la fecha de vencimiento
                if (objProductoBE.fechaVencimiento == null)
                {
                    comando.Parameters.AddWithValue("@fechaVencimiento", DBNull.Value);
                }
                else
                {
                    comando.Parameters.AddWithValue("@fechaVencimiento", objProductoBE.fechaVencimiento);
                }


                comando.Parameters.AddWithValue("@estado", objProductoBE.estado);
                comando.Parameters.AddWithValue("@fotoProducto", objProductoBE.fotoProducto);

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
                if(conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }


        public Boolean actualizarProducto(ProductoBE objProductoBE)
        {
            try
            {
                conexion.ConnectionString = miConexion.ObtenerCadenaCnx();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "CRUD_ACTUALIZAR_PRODUCTO";

                //Agregamos los parametros
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@idProductos", objProductoBE.idProductos);
                comando.Parameters.AddWithValue("@idCategoria", objProductoBE.idCategoria);
                comando.Parameters.AddWithValue("@idProveedor", objProductoBE.idProveedor);
                comando.Parameters.AddWithValue("@idArea", objProductoBE.idArea);
                comando.Parameters.AddWithValue("@nombreProducto", objProductoBE.nombreProducto);
                comando.Parameters.AddWithValue("@descripcion", objProductoBE.descripcion);
                comando.Parameters.AddWithValue("@precioCompra", objProductoBE.precioCompra);
                comando.Parameters.AddWithValue("@precioVenta", objProductoBE.precioVenta);
                comando.Parameters.AddWithValue("@stock", objProductoBE.stock);
                comando.Parameters.AddWithValue("@fechaIngreso", objProductoBE.fechaIngreso);
                
                comando.Parameters.AddWithValue("@fechaVencimiento", (object)objProductoBE.fechaVencimiento ?? DBNull.Value);

                comando.Parameters.AddWithValue("@estado", objProductoBE.estado);
                comando.Parameters.AddWithValue("@fotoProducto", (object)objProductoBE.fotoProducto ?? DBNull.Value);


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


        public Boolean eliminarProducto(String idProducto)
        {
            try
            {
                conexion.ConnectionString = miConexion.ObtenerCadenaCnx();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "CRUD_ELIMINAR_PRODUCTO";

                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@idProductos", idProducto);
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


        public ProductoBE consultarProducto(String idCodigo)
        {
            try
            {
                ProductoBE objProductoBE = new ProductoBE();
                conexion.ConnectionString = miConexion.ObtenerCadenaCnx();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "CRUD_CONSULTAR_PRODUCTO";

                // Primero limpiamos los parámetros 
                comando.Parameters.Clear();

                // Agregamos el parámetro necesario para la consulta del producto
                comando.Parameters.AddWithValue("@idProductos", idCodigo);
                conexion.Open();
                data = comando.ExecuteReader();

                if (data.HasRows)
                {
                    data.Read();
                    objProductoBE.idProductos = data["idProductos"].ToString();
                    objProductoBE.nombreProducto = data["nombreProducto"].ToString();
                    objProductoBE.idCategoria = data["idCategoria"].ToString();
                    objProductoBE.idProveedor = data["idProveedor"].ToString();
                    objProductoBE.idArea = data["idArea"].ToString();
                    objProductoBE.descripcion = data["descripcion"].ToString();
                    objProductoBE.precioCompra = Convert.ToSingle(data["precioCompra"]);
                    objProductoBE.precioVenta = Convert.ToSingle(data["precioVenta"]);
                    objProductoBE.stock = Convert.ToInt16(data["stock"]);
                    objProductoBE.estado = data["estado"].ToString();

                    // Manejo correcto del campo de imagen
                    if (!data.IsDBNull(data.GetOrdinal("fotoProducto")))
                    {
                        objProductoBE.fotoProducto = (byte[])data["fotoProducto"];
                    }
                    else
                    {
                        objProductoBE.fotoProducto = null; // O maneja como consideres si no hay imagen
                    }

                    objProductoBE.fechaIngreso = Convert.ToDateTime(data["fechaIngreso"]);
                    objProductoBE.fechaVencimiento = data.IsDBNull(data.GetOrdinal("fechaVencimiento"))
                                                     ? (DateTime?)null
                                                     : Convert.ToDateTime(data["fechaVencimiento"]);
                }

                data.Close();
                return objProductoBE;
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



        public DataTable listarProducto()
        {
            try
            {
                DataSet data = new DataSet();
                conexion.ConnectionString = miConexion.ObtenerCadenaCnx();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "CRUD_LISTAR_PRODUCTOS";
                comando.Parameters.Clear();
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(data, "productos");
                return data.Tables["productos"];


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
