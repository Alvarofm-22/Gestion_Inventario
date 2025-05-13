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
    public partial class FrmPrincipalProveedor : Form
    {

        ProveedorBL objProveedorBL = new ProveedorBL();
        DataView dataV;


        public FrmPrincipalProveedor()
        {
            InitializeComponent();
        }

        private void cargarDatos(String idProveedor)
        {

            dataV = new DataView(objProveedorBL.listarProveedores());
            dataV.RowFilter = "nombreProveedor like '%" + idProveedor + "%'";
            dgvProveedor.DataSource = dataV;
            lblProveedores.Text = dgvProveedor.Rows.Count.ToString();
        }

        private void FrmPrincipalProveedor_Load(object sender, EventArgs e)
        {
            //Sirve para solo agregar las columnas que yo configure en mi data grid
            dgvProveedor.AutoGenerateColumns = false;
            cargarDatos("");
        }

        private void txtNomProveedor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cargarDatos(txtNomProveedor.Text.Trim());
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
                FrmAgregarProveedor ventana = new FrmAgregarProveedor();
                ventana.ShowDialog();

                cargarDatos(txtNomProveedor.Text);

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
                //Obtengo el codigo del producto que selecciono el usuario
                String strCodigo = dgvProveedor.CurrentRow.Cells[0].Value.ToString();

                //Una ves obtenido mi codigo de producto
                //abro la ventana de actualizacion 
                FrmActualizarProveedor objVentana = new FrmActualizarProveedor();
                objVentana.idCodigo = strCodigo;
                objVentana.ShowDialog();


                cargarDatos(txtNomProveedor.Text);

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
                String idProveedor = Convert.ToString(dgvProveedor.CurrentRow.Cells[0].Value);

                DialogResult respuesta = MessageBox.Show("Estas seguro de eliminar el proveedor", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (respuesta == DialogResult.Yes)
                {
                    if (objProveedorBL.eliminarProveedor(idProveedor) == true)
                    {
                        cargarDatos("");
                    }

                    else
                    {
                        throw new Exception("No se pudo eliminar el proveedor, contacte TI");
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
