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
    public partial class FrmAgregarEmpleado : Form
    {

        //Instancias que utilizare
        EmpleadoBL objEmpleadoBL = new EmpleadoBL();
        EmpleadoBE objEmpleadoBE = new EmpleadoBE();

        AreaBL objAreaBL = new AreaBL();

        //Clase para validar datos
        private ValidarDatos objValidador = new ValidarDatos();


        public FrmAgregarEmpleado()
        {
            InitializeComponent();
        }

        private void FrmAgregarEmpleado_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dataT;
                DataRow dataR;

                //LLENAR EL COMBO BOX AREA 

                dataT = objAreaBL.listarArea();
                dataR = dataT.NewRow();
                dataR["idArea"] = 0;
                dataR["nombreArea"] = "--Seleccionar--";
                dataT.Rows.InsertAt(dataR, 0);

                cboArea.DataSource = dataT;

                cboArea.ValueMember = "idArea";
                cboArea.DisplayMember = "nombreArea";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidador.ValidarLetras(e);
        }

        private void txtApellidoPaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidador.ValidarLetras(e);
        }

        private void txtApellidoMaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidador.ValidarLetras(e);
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidador.ValidarEntero(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidador.ValidarEntero(e);
        }

        private void txtTelEmergencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidador.ValidarEntero(e);
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidador.ValidarCorreo(e);
        }

        private void txtPuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidador.ValidarLetras(e);
        }

        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidador.ValidarPrecio(e);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboArea.SelectedIndex == 0)
                {
                    throw new Exception("Debe seleccionar una area");
                }

                if (txtNombre.Text.Trim() == String.Empty)
                {
                    throw new Exception("Debe ingresar su nombre");
                }

                if (txtApellidoPaterno.Text.Trim() == String.Empty)
                {
                    throw new Exception("Debe ingresar su apellido paterno");
                }

                if (txtApellidoMaterno.Text.Trim() == String.Empty)
                {
                    throw new Exception("Debe ingresar su apellido materno");
                }

                if (txtDNI.Text.Trim() == String.Empty)
                {
                    throw new Exception("Debe ingresar su DNI");
                }

                if (dtpFecNacimiento.Value == DateTime.Today)
                {
                    throw new Exception("Su fecha de nacimiento no tiene cooherencia");
                }


                if (txtDireccion.Text.Trim() == String.Empty)
                {
                    throw new Exception("Debe ingresar su direccion");
                }

                if (txtTelefono.Text.Trim() == String.Empty)
                {
                    throw new Exception("Debe ingresar su telefono de celular");
                }

                if (txtTelEmergencia.Text.Trim() == String.Empty)
                {
                    throw new Exception("Debe ingresar un telefono de emergencia");
                }

                if (txtCorreo.Text.Trim() == String.Empty)
                {
                    throw new Exception("Debe ingresar su correo electronico");
                }

                if (txtPuesto.Text.Trim() == String.Empty)
                {
                    throw new Exception("Debe ingresar su puesto");
                }

                if (dtpFecContratacion.Value <= DateTime.Today)
                {
                    throw new Exception("Debe ingresar una fecha de contratacion valida");
                }

                //RECUPERAMOS EL SEXO DEL EMPLEADO
                if (rbMasculino.Checked)
                {
                    objEmpleadoBE.sexo = "MASCULINO";
                }

                if (rbFemenino.Checked)
                {
                    objEmpleadoBE.sexo = "FEMENINO";
                }

                // RECUPERAMOS EL ESTADO DEL EMPLEADO
                // 
                if (rbActivo.Checked == true)
                {
                    objEmpleadoBE.estado = "ACTIVO";
                }
                if (rbInactivo.Checked == true)
                {
                    objEmpleadoBE.estado = "INACTIVO";
                }

                if (txtSalario.Text.Trim() == String.Empty)
                {
                    throw new Exception("Debe ingresar su salario");
                }


                objEmpleadoBE.idArea = Convert.ToString(cboArea.SelectedValue);
                objEmpleadoBE.nombre = txtNombre.Text.Trim();
                objEmpleadoBE.apellidoPaterno = txtApellidoPaterno.Text.Trim();
                objEmpleadoBE.apellidoMaterno = txtApellidoMaterno.Text.Trim();
                objEmpleadoBE.DNI = txtDNI.Text.Trim();
                objEmpleadoBE.fechaNacimiento = dtpFecNacimiento.Value;
                objEmpleadoBE.direccion = txtDireccion.Text.Trim();
                objEmpleadoBE.telefono = txtTelefono.Text.Trim();
                objEmpleadoBE.telefonoEmergencia = txtTelEmergencia.Text.Trim();
                objEmpleadoBE.correoElectronico = txtCorreo.Text.Trim();
                objEmpleadoBE.puesto = txtPuesto.Text.Trim();
                objEmpleadoBE.fechaContratacion = dtpFecContratacion.Value;
                objEmpleadoBE.salario = Convert.ToInt32(txtSalario.Text);

                if (objEmpleadoBL.insertarEmpleado(objEmpleadoBE) == true)
                {
                    this.Close();
                }

                else
                {
                    throw new Exception("No se pudo registrar al empleado");
                }

            }

            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }

        }





    }
}
