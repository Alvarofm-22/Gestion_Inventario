using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//AGREGAMOS
using Proyecto_ADO;
using Proyecto_BE;

namespace Proyecto_BL
{
    public class ProveedorBL
    {
        ProveedorADO objProveedorADO = new ProveedorADO();


        public Boolean insertarProveedor(ProveedorBE objProveedorBE)
        {
            return objProveedorADO.insertarProveedor(objProveedorBE);
        }

        public Boolean actualizarProveedor(ProveedorBE objProveedorBE)
        {
            return objProveedorADO.actualizarProveedor(objProveedorBE);
        }

        public Boolean eliminarProveedor(String idProveedor)
        {
            return objProveedorADO.eliminarProveedor(idProveedor);
        }

        public ProveedorBE consultarProveedor(String idProveedor)
        {
            return objProveedorADO.consultarProveedor(idProveedor);
        }


        public DataTable listarProveedores()
        {
            return objProveedorADO.listarProveedores();
        }
    }
}
