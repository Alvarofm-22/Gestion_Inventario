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
    public class EmpleadoBL
    {

        EmpleadoADO objEmpleadoADO = new EmpleadoADO(); 


        public Boolean insertarEmpleado(EmpleadoBE objEmpleadoBE)
        {
            return objEmpleadoADO.insertarEmpleado(objEmpleadoBE);
        }


        public Boolean actualizarEmpleado(EmpleadoBE objEmpleadoBE)
        {
            return objEmpleadoADO.actualizarEmpleado(objEmpleadoBE);
        }


        public Boolean eliminarEmpleado(String strCodigo)
        {
            return objEmpleadoADO.eliminarEmpleado(strCodigo);
        }


        public EmpleadoBE consultarEmpleado(String strCodigo)
        {
            return objEmpleadoADO.consultarEmpleado(strCodigo);
        }

        public DataTable listarEmpleados()
        {
            return objEmpleadoADO.listarEmpleados();
        }



    }
}
