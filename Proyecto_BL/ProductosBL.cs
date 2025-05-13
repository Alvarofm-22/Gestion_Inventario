using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Proyecto_ADO;
using Proyecto_BE;

namespace Proyecto_BL
{
    public class ProductosBL
    {

        ProductoADO objProductoADO = new ProductoADO();

        public Boolean insertarProducto(ProductoBE objProductoBE)
        {
            return objProductoADO.insertarProducto(objProductoBE);
        }

        public Boolean actualizarProducto(ProductoBE objProductoBE)
        {
            return objProductoADO.actualizarProducto(objProductoBE);
        }

        public Boolean eliminarProducto(String strCodigo)
        {
            return objProductoADO.eliminarProducto(strCodigo);
        }

        public ProductoBE consultarProducto(String strCodigo)
        {
            return objProductoADO.consultarProducto(strCodigo);
        }

        public DataTable listarProducto()
        {
            return objProductoADO.listarProducto();
        }


    }
}
