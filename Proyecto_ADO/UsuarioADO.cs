using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//AGREGAR
using System.Data;
using System.Data.SqlClient;
using Proyecto_BE;

namespace Proyecto_ADO
{
    public class UsuarioADO
    {
        //Creo un objeto de la clase Conexion
        Conexion miConexion = new Conexion();
        SqlConnection conexion = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        SqlDataReader data;


        public UsuarioBE consultarUsuario(String strUsuario, String strContraseña)
        {
            try
            {
                UsuarioBE objUsuarioBE = new UsuarioBE();
                conexion.ConnectionString = miConexion.ObtenerCadenaCnx();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "CRUD_CONSULTAR_USUARIO";

                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@usuario", strUsuario);
                comando.Parameters.AddWithValue("@contraseña", strContraseña);

                conexion.Open();
                data = comando.ExecuteReader();

                // Verifico si me devuelve una fila 
                if (data.HasRows == true)
                {
                    data.Read();
                    objUsuarioBE.idUsuario = data["idUsuario"].ToString();
                    objUsuarioBE.idEmpleado = data["idEmpleado"].ToString();
                    objUsuarioBE.usuario = data["usuario"].ToString();
                    objUsuarioBE.contraseña = data["contraseña"].ToString();
                }
                else
                {
                    objUsuarioBE.idUsuario = String.Empty;
                }

                data.Close();
                return objUsuarioBE;
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

    }
}
