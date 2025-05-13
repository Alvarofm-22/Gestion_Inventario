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
using Proyecto_BL;


namespace Proyecto_GUI
{
    public partial class FrmPrincipalEmpleado : Form
    {

        EmpleadoBL objEmpleadoBL = new EmpleadoBL();
        DataView dataV;

        public FrmPrincipalEmpleado()
        {
            InitializeComponent();
        }


        private void cargarData(String idEmpleado)
        {
            // Construimos  el objeto Dataview dtv  en base al DataTable devuelto por el metodo 
            // Y lo filtramos de acuerdo al parametro str
            dataV = new DataView(objEmpleadoBL.listarEmpleados());
            dataV.RowFilter = "nombre like '%" + idEmpleado + "%'";
            dgvEmpleados.DataSource = dataV;
            lblEmpleados.Text = dgvEmpleados.Rows.Count.ToString();
        }

        private void FrmPrincipalEmpleado_Load(object sender, EventArgs e)
        {
            //Sirve para solo agregar las columnas que yo configure en mi data grid
            dgvEmpleados.AutoGenerateColumns = false;
            cargarData("");
        }

        private void txtNomEmpleado_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cargarData(txtNomEmpleado.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAgregarEmpleado ventana = new FrmAgregarEmpleado();
                ventana.ShowDialog();

                cargarData(txtNomEmpleado.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgvEmpleados.CurrentRow != null)
                {
                    String idCodigo = dgvEmpleados.CurrentRow.Cells[0].Value.ToString();
                    MessageBox.Show($"ID del empleado seleccionado: {idCodigo}");

                    FrmActualizarEmpleado ventana = new FrmActualizarEmpleado();
                    ventana.idCodigo = idCodigo;
                    ventana.ShowDialog();

                    cargarData(txtNomEmpleado.Text);

                }
                else
                {
                    MessageBox.Show("No hay ninguna fila seleccionada.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                String idEmpleado = Convert.ToString(dgvEmpleados.CurrentRow.Cells[0].Value);

                DialogResult respuesta = MessageBox.Show("Estas seguro de eliminar el empleado", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (respuesta == DialogResult.Yes)
                {
                    if (objEmpleadoBL.eliminarEmpleado(idEmpleado) == true)
                    {
                        cargarData("");
                    }

                    else
                    {
                        throw new Exception("No se pudo eliminar el empleado, contacte TI");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

        }
    }
}
