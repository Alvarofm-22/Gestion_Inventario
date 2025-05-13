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
    public partial class FrmActualizarEmpleado : Form
    {

        //Instancias que utilizare
        EmpleadoBL objEmpleadoBL = new EmpleadoBL();
        EmpleadoBE objEmpleadoBE = new EmpleadoBE();

        AreaBL objAreaBL = new AreaBL();

        ValidarDatos objValidador = new ValidarDatos();

        public String idCodigo {  get; set; }



        public FrmActualizarEmpleado()
        {
            InitializeComponent();
        }

        private void FrmActualizarEmpleado_Load(object sender, EventArgs e)
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

                //HAGO LA CONSULTA PARA SABER QUE EMPLEADO ACTUALIZARE
                objEmpleadoBE = objEmpleadoBL.consultarEmpleado(this.idCodigo);


                //UNA VEZ HECHO LA CONSULTA LLENARE LOS CONTROLES CON LOS DATOS DEL EMPLEADO
                lblCodigo.Text = objEmpleadoBE.idEmpleado;
                cboArea.SelectedValue = objEmpleadoBE.idArea;
                txtNombre.Text = objEmpleadoBE.nombre;
                txtApellidoPaterno.Text = objEmpleadoBE.apellidoPaterno;
                txtApellidoMaterno.Text = objEmpleadoBE.apellidoMaterno;
                txtDNI.Text = objEmpleadoBE.DNI;
                dtpFecNacimiento.Value = objEmpleadoBE.fechaNacimiento;

                if(objEmpleadoBE.sexo.ToUpper() == "MASCULINO")
                {
                    rbMasculino.Checked = true;
                }

                if(objEmpleadoBE.sexo.ToUpper() == "FEMENINO")
                {
                    rbFemenino.Checked = true;
                }

                txtDireccion.Text = objEmpleadoBE.direccion;
                txtTelefono.Text = objEmpleadoBE.telefono;
                txtTelEmergencia.Text = objEmpleadoBE.telefonoEmergencia;
                txtCorreo.Text = objEmpleadoBE.correoElectronico;
                txtPuesto.Text = objEmpleadoBE.puesto;
                dtpFecContratacion.Value = objEmpleadoBE.fechaContratacion;

                if (objEmpleadoBE.estado.ToUpper() == "ACTIVO")
                {
                    rbActivo.Checked = true;
                }

                if (objEmpleadoBE.estado.ToUpper() == "INACTIVO")
                {
                    rbInactivo.Checked = true;
                }

                txtSalario.Text = Convert.ToString(objEmpleadoBE.salario);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidador.ValidarDireccion(e);
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

                if (objEmpleadoBL.actualizarEmpleado(objEmpleadoBE) == true)
                {
                    this.Close();
                }

                else
                {
                    throw new Exception("No se pudo actualizar datos al empleado" + idCodigo);
                }

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
    }

}
