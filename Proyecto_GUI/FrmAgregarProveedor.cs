using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//agregar
using Proyecto_BE;
using Proyecto_BL;


namespace Proyecto_GUI
{
    public partial class FrmAgregarProveedor : Form
    {

        ProveedorBE objProveedorBE = new ProveedorBE();
        ProveedorBL objProveedorBL = new ProveedorBL();

        //Clase para validar datos
        private ValidarDatos objValidador = new ValidarDatos();

        public FrmAgregarProveedor()
        {
            InitializeComponent();
        }




        //PRIMERO VALIDARE LOS DATOS


        private void txtNomProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidador.ValidarLetras(e);
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidador.ValidarLetras(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidador.ValidarEntero(e);
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidador.ValidarEntero(e);
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidador.ValidarCorreo(e);
        }

        private void txtPersonaContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidador.ValidarLetras(e);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtNomProveedor.Text.Trim() == String.Empty)
                {
                    throw new Exception("Debe colocar un nombre de proveedor");
                }

                if(txtDireccion.Text.Trim() == String.Empty)
                {
                    throw new Exception("Debe colocar una direccion");
                }

                if(txtTelefono.Text.Trim() == String.Empty)
                {
                    throw new Exception("Debe colocar un telefono");
                }

                if(txtCelular.Text.Trim() == String.Empty)
                {
                    throw new Exception("Debe colocar una numero de celular");
                }

                if(txtCorreo.Text.Trim() == String.Empty)
                {
                    throw new Exception("Debe colocar un correo electronico");
                }

                if(txtPersonaContacto.Text.Trim() == String.Empty)
                {
                    throw new Exception("Debe ingresar una persona de contacto");
                }

                //RECUPERAREMOS LOS DATOS
                
                objProveedorBE.nombreProveedor = txtNomProveedor.Text;
                objProveedorBE.direccion = txtDireccion.Text;
                objProveedorBE.telefono = txtTelefono.Text;
                objProveedorBE.celular = txtCelular.Text;
                objProveedorBE.correoElectronico = txtCorreo.Text;
                objProveedorBE.personaContacto = txtPersonaContacto.Text;
                
                if(rbActivo.Checked)
                {
                    objProveedorBE.estadoProveedor = "ACTIVO";
                }

                else
                {
                    objProveedorBE.estadoProveedor = "INACTIVO";
                }

                if (objProveedorBL.insertarProveedor(objProveedorBE) == true)
                {
                    this.Close();
                }

                else
                {
                    throw new Exception("No se pudo registrar al Proveedor");
                }


            }


            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void FrmAgregarProveedor_Load(object sender, EventArgs e)
        {

        }
    }
}
