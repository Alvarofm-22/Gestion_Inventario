using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GUI
{
    public partial class MDIGestionInventario : Form
    {
        public MDIGestionInventario()
        {
            InitializeComponent();
        }

        private void mantenimientoDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPrincipalEmpleado ventana = new FrmPrincipalEmpleado();
            ventana.MdiParent = this;
            ventana.Show();
        }

        private void mantenimientoDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPrincipalProveedor ventana = new FrmPrincipalProveedor();
            ventana.MdiParent = this;
            ventana.Show();
        }

        private void mantenimientoDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPrincipalProductos ventana = new FrmPrincipalProductos();
            ventana.MdiParent = this;
            ventana.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MDIGestionInventario_Resize(object sender, EventArgs e)
        {
            Refresh();
        }

        private void MDIGestionInventario_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Estas seguro de salir?", "Confirmar",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
            {
                e.Cancel = true;
            }

        }

        private void MDIGestionInventario_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Salimos de la aplicacion
            Application.Exit();
        }

        private void MDIGestionInventario_Load(object sender, EventArgs e)
        {

        }
    }
}
