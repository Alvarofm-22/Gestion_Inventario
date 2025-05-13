using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//AGREGAR
using Proyecto_BE;
using Proyecto_BL;

namespace Proyecto_GUI
{

    public partial class InicioSesion : Form
    {

        //CREO VARIABLES PARA CONTROLAR EL TIEMPO Y LOS INTENTOS
        Int16 nIntentos = 0;
        Int16 nTiempo = 40;

        //CREO MIS OBJETOS USUARIO BL Y BE
        UsuarioBE objUsuarioBE = new UsuarioBE();
        UsuarioBL objUsuarioBL = new UsuarioBL();



        public InicioSesion()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtUsuario.Text.Trim() != String.Empty && txtContraseña.Text.Trim() != String.Empty)
                {
                    objUsuarioBE = objUsuarioBL.consultarUsuario(txtUsuario.Text.Trim(), txtContraseña.Text.Trim());
                
                    if(txtUsuario.Text.Trim() == objUsuarioBE.usuario && txtContraseña.Text.Trim() == objUsuarioBE.contraseña )
                    {
                        //si la comparacion es correcta 
                        this.Hide();
                        timer1.Enabled = false;

                        //guardamos las credenciales


                        //Mostramos el mdi
                        MDIGestionInventario objMDI = new MDIGestionInventario();
                        objMDI.ShowDialog();
                    }

                    else
                    {
                        nIntentos += 1;
                        throw new Exception("Credenciales Incorrectas");
                    }

                }

                else
                {
                    nIntentos += 1;
                    throw new Exception("Usuario y Contraseña son obligatorios");
                }




            }
            catch (Exception ex)
            {

                if (nIntentos == 3)
                {
                    MessageBox.Show("Lo siento, supero el numero de intentos",
                        "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Error: " + ex.Message,
                           "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            nTiempo -= 1;
            this.Text = "Ingrese su Usuario y contraseña. Le quedan...." + nTiempo;
            if (nTiempo == 0)
            {
                MessageBox.Show("Se acabo su tiempo, para ingresar",
                    "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }

        }

        private void InicioSesion_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
            Application.Exit();
        }

        private void InicioSesion_KeyDown(object sender, KeyEventArgs e)
        {
            // Para al pulsar Enter acceder al MDI...
            if (e.KeyCode == Keys.Enter)
            {
                btnIngresar.PerformClick();

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Application.Exit();
        }
    }
}
