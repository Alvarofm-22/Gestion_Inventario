using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//AGREGAR
using Proyecto_ADO;
using Proyecto_BE;

namespace Proyecto_BL
{
    public class UsuarioBL
    {
        UsuarioADO objUsuarioADO = new UsuarioADO();    

        public UsuarioBE consultarUsuario(String strUsuario, String strContraseña)
        {
            return objUsuarioADO.consultarUsuario(strUsuario, strContraseña);
        }
    }
}
