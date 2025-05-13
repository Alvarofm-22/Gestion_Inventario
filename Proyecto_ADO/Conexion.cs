using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Agregar
using System.Configuration;


namespace Proyecto_ADO
{
    internal class Conexion
    {
        public String ObtenerCadenaCnx()
        {
            try
            {
                //Retornar la cadena de conexion Ventas definida en el aPP.config del 
                //Proyecto ejecutable (capa de presentacion) ProyVentas_GUI
                String strCnx = ConfigurationManager.ConnectionStrings["BDInventario"].ConnectionString;
                return strCnx;
            }
            catch (Exception ex)
            {

                throw new Exception("Error  " + ex.Message);
            }
        }

    }
}
