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
    public class CategoriaBL
    {
        CategoriaADO objCategoriaADO = new CategoriaADO();

        public DataTable listarCategorias()
        {
            return objCategoriaADO.listarCategoria();
        }
    }
}
