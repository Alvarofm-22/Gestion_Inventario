using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_BL;

namespace Proyecto_GUI
{
    public partial class FrmPrincipalProductos : Form
    {
        ProductosBL objProductoBL = new ProductosBL();
        DataView dataV;


        public FrmPrincipalProductos()
        {
            InitializeComponent();
        }

        private void cargarDatos(String striProducto)
        {
            // Construimos  el objeto Dataview dtv  en base al DataTable devuelto por el metodo ListarProducto
            // Y lo filtramos de acuerdo al parametro strFiltro
            dataV = new DataView(objProductoBL.listarProducto());
            dataV.RowFilter = "descripcion like '%" + striProducto + "%'";
            dgvProductos.DataSource = dataV;
            lblProductos.Text = dgvProductos.Rows.Count.ToString();

        }

        private void FrmPrincipalProductos_Load(object sender, EventArgs e)
        {
            //Sirve para solo agregar las columnas que yo configure en mi data grid
            dgvProductos.AutoGenerateColumns = false;
            cargarDatos("");
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Pasaremos al metodo CargarDatos el texto que se va escribiendo
                // en la caja de texto 
                cargarDatos(txtDescripcion.Text.Trim());
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
            FrmAgregarPro objVentana = new FrmAgregarPro();
            objVentana.ShowDialog();
            
            cargarDatos(txtDescripcion.Text);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtengo el codigo del producto que selecciono el usuario
                String strCodigo = dgvProductos.CurrentRow.Cells[0].Value.ToString();

                //Una ves obtenido mi codigo de producto
                //abro la ventana de actualizacion 
                FrmActualizarProducto objVentana = new FrmActualizarProducto();
                objVentana.Codigo = strCodigo;
                objVentana.ShowDialog();    


                cargarDatos(txtDescripcion.Text);

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
                String idProducto = Convert.ToString(dgvProductos.CurrentRow.Cells[0].Value);

                DialogResult respuesta = MessageBox.Show("Estas seguro de eliminar el producto", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (respuesta == DialogResult.Yes)
                {
                    if (objProductoBL.eliminarProducto(idProducto) == true)
                    {
                        cargarDatos("");
                    }

                    else
                    {
                        throw new Exception("No se pudo eliminar el producto, contacte TI");
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
