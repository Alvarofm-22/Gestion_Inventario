using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Proyecto_GUI
{
    public class ValidarDatos
    {

        public void ValidarPrecio(KeyPressEventArgs e)
        {
            CultureInfo cc = CultureInfo.CurrentCulture;

            e.Handled = !(char.IsDigit(e.KeyChar)
                            || e.KeyChar == (char)Keys.Back
                            || e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator);
        }

        public void ValidarEntero(KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar)
                            || e.KeyChar == (char)Keys.Back);// permite Backspace
        }

        public void ValidarLetras(KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar)
                          || e.KeyChar == ' '  // Espacio
                          || e.KeyChar == (char)Keys.Back);// permite el Backspace
        }

        public void ValidarCorreo(KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetterOrDigit(e.KeyChar)
                          || e.KeyChar == '@'  // Símbolo arroba
                          || e.KeyChar == '.'  // Punto
                          || e.KeyChar == '-'  // Guion
                          || e.KeyChar == '_'  // Guion bajo
                          || e.KeyChar == (char)Keys.Back);
        }

        public void ValidarDireccion(KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetterOrDigit(e.KeyChar)
                          || e.KeyChar == ' '   // Espacio
                          || e.KeyChar == '.'   // Punto
                          || e.KeyChar == ','   // Coma
                          || e.KeyChar == '-'   // Guion
                          || e.KeyChar == '#'   // Símbolo numeral
                          || e.KeyChar == '/'   // Barra diagonal
                          || e.KeyChar == (char)Keys.Back);
        }




    }

}

