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
    public class AreaBL
    {

        AreaADO objAreaADO = new AreaADO();

        public DataTable listarArea()
        {
            return objAreaADO.listarArea();
        }

    }
}
