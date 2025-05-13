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
using System.IO;// para la clase File y manejo de la foto


namespace Proyecto_GUI
{
    public partial class FrmAgregarPro : Form
    {

        //Instancias que utilizare
        ProductosBL objProductoBL = new ProductosBL();
        ProductoBE objProductoBE = new ProductoBE();

        CategoriaBL objCategoriaBL = new CategoriaBL();
        ProveedorBL objProveedorBL = new ProveedorBL();
        AreaBL objAreaBL = new AreaBL();

        



        public FrmAgregarPro()
        {
            InitializeComponent();
        }

        private void FrmAgregarPro_Load(object sender, EventArgs e)
        {

            try
            {
                DataTable dataT;

                dataT = objCategoriaBL.listarCategorias();
                DataRow dataR;

                dataR = dataT.NewRow();

                dataR["idCategoria"] = 0;
                dataR["nombreCategoria"] = "--Seleccionar--";
                dataT.Rows.InsertAt(dataR, 0);
                
                cboCategoria.DataSource = dataT;

                cboCategoria.ValueMember = "idCategoria";
                cboCategoria.DisplayMember = "nombreCategoria";

                //Ahora llenamos el combobox de proveedores
                //Con el dataTable y dataReader

                dataT = objProveedorBL.listarProveedores();
                dataR = dataT.NewRow();
                
                dataR["idProveedor"] = 0;
                dataR["nombreProveedor"] = "--Seleccionar--";
                dataT.Rows.InsertAt (dataR, 0);

                cboProveedor.DataSource = dataT;

                cboProveedor.ValueMember = "idProveedor";
                cboProveedor.DisplayMember = "nombreProveedor";

                //Finalmente el area

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


        private ValidarDatos objValidador = new ValidarDatos();

        //Primero validamos los datos
        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidador.ValidarPrecio(e);

        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidador.ValidarPrecio(e);
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidador.ValidarEntero(e);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboCategoria.SelectedIndex == 0 && cboProveedor.SelectedIndex == 0 && cboArea.SelectedIndex == 0)
                {
                    throw new Exception("La categoria, Proveedor y Area son obligatorios");
                }

                //Primero valido que mis datos no esten vacios

                if(txtNomProducto.Text.Trim() == String.Empty)
                {
                    throw new Exception("El nombre es un dato obligatorio");
                }

                if(txtDescripcion.Text.Trim() == String.Empty) 
                {
                    throw new Exception("La descripcion es un dato obligatorio");
                }

                if (txtPrecioCompra.Text.Trim() == String.Empty)
                {
                    throw new Exception("El precio de compra es un dato obligatorio");
                }

                if (txtPrecioVenta.Text.Trim() == String.Empty)
                {
                    throw new Exception("El precio de venta es un dato obligatorio");
                }

                if(txtStock.Text.Trim() == String.Empty)
                {
                    throw new Exception("El stock es un dato obligatorio");
                }

                //Evaluamos el estado
                if(rbActivo.Checked == true)
                {
                    objProductoBE.estado = "Activo";
                }

                else
                {
                    objProductoBE.estado = "Inactivo";
                }

                //Verifico que se grabe una foto
                if(pcbProducto.Image == null)
                {
                    throw new Exception("Debe registrar una foto del producto");
                }

                //Convertimos la foto en un arreglo de bytes para cargarlo al objProducto
                objProductoBE.fotoProducto = File.ReadAllBytes(openFileDialog1.FileName);


                // Verificar si la fecha de vencimiento es válida
                if (dtpFecVencimiento.Value.Date == DateTime.Today)
                {
                    objProductoBE.fechaVencimiento = null; // Asignar null si la fecha es mínima o la fecha de hoy
                }

                else
                {
                    objProductoBE.fechaVencimiento = dtpFecVencimiento.Value;
                }




                objProductoBE.idCategoria = Convert.ToString(cboCategoria.SelectedValue);
                objProductoBE.idProveedor = Convert.ToString(cboProveedor.SelectedValue);
                objProductoBE.idArea = Convert.ToString(cboArea.SelectedValue);
                objProductoBE.nombreProducto = txtNomProducto.Text.Trim();
                objProductoBE.descripcion = txtDescripcion.Text.Trim(); 
                objProductoBE.precioCompra = Convert.ToSingle(txtPrecioCompra.Text.Trim());
                objProductoBE.precioVenta = Convert.ToSingle(txtPrecioVenta.Text.Trim());
                objProductoBE.stock = Convert.ToInt16(txtStock.Text.Trim());
                objProductoBE.fechaIngreso = dtpFecIngreso.Value;



                if(objProductoBL.insertarProducto(objProductoBE) == true)
                {
                    this.Close();
                }

                else
                {
                    //Si no se logro insertar lanzamos una excepcion
                    throw new Exception("No se pudo registrar el producto, contactarse con TI");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                // Codifique
                openFileDialog1.FileName = String.Empty;
                openFileDialog1.Multiselect = false;
                openFileDialog1.ShowDialog();

                //Si se escogio una foto se carga en el picture box

                if (openFileDialog1.FileName != String.Empty)
                {
                    pcbProducto.Image = Image.FromFile(openFileDialog1.FileName);
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }
        }


    }
}
