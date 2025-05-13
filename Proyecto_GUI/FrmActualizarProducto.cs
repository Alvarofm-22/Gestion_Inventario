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
    public partial class FrmActualizarProducto : Form
    {

        //Instancias que utilizare
        ProductosBL objProductoBL = new ProductosBL();
        ProductoBE objProductoBE = new ProductoBE();

        CategoriaBL objCategoriaBL = new CategoriaBL();
        ProveedorBL objProveedorBL = new ProveedorBL();
        AreaBL objAreaBL = new AreaBL();

        Boolean blnCambio;
        Byte[] FotoOriginal;



        public String Codigo { get; set; }

        public FrmActualizarProducto()
        {
            InitializeComponent();
        }

        private void FrmActualizarProducto_Load(object sender, EventArgs e)
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
                dataT.Rows.InsertAt(dataR, 0);

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


                //Consultamos que producto va a actualizar
                objProductoBE = objProductoBL.consultarProducto(this.Codigo);


                //Una vez hecha la consulta cargare los datos a los controles determinados
                lblCodigo.Text = objProductoBE.idProductos;
                cboCategoria.SelectedValue = objProductoBE.idCategoria;
                cboProveedor.SelectedValue = objProductoBE.idProveedor;
                cboArea.SelectedValue = objProductoBE.idArea;
                txtNomProducto.Text = objProductoBE.nombreProducto;
                txtDescripcion.Text = objProductoBE.descripcion;
                txtPrecioCompra.Text = objProductoBE.precioCompra.ToString();
                txtPrecioVenta.Text = objProductoBE.precioVenta.ToString();
                txtStock.Text = objProductoBE.stock.ToString();
                
                
                if (objProductoBE.fechaVencimiento.HasValue)
                {
                    dtpFecVencimiento.Value = objProductoBE.fechaVencimiento.Value;
                }
                else
                {
                    dtpFecVencimiento.Value = DateTime.Now; // O el valor que consideres adecuado
                }



                // Verificamos si la fotoProducto es null o si está vacía
                if (objProductoBE.fotoProducto == null || objProductoBE.fotoProducto.Length == 0)
                {
                    pcbProducto.Image = null;
                }
                else
                {
                    MemoryStream foto = new MemoryStream(objProductoBE.fotoProducto);
                    pcbProducto.Image = Image.FromStream(foto);
                    // Guardamos la foto original, por si no se hace cambios...
                    FotoOriginal = objProductoBE.fotoProducto;
                }


                //evaluo el estado del producto para activar el radiobutton 
                if (objProductoBE.estado.ToUpper() == "ACTIVO")
                {
                    rbActivo.Checked = true;
                }

                else
                {
                    rbInactivo.Checked = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private ValidarDatos objValidador = new ValidarDatos();

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
            objValidador.ValidarPrecio(e);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboCategoria.SelectedIndex == 0 && cboProveedor.SelectedIndex == 0 && cboArea.SelectedIndex == 0)
                {
                    throw new Exception("La categoria, Proveedor y Area son obligatorios");
                }

                //Primero valido que mis datos no esten vacios

                if (txtNomProducto.Text.Trim() == String.Empty)
                {
                    throw new Exception("El nombre es un dato obligatorio");
                }

                if (txtDescripcion.Text.Trim() == String.Empty)
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

                if (txtStock.Text.Trim() == String.Empty)
                {
                    throw new Exception("El stock es un dato obligatorio");
                }

                //Verifico que se grabe una foto
                if (pcbProducto.Image == null)
                {
                    throw new Exception("Debe registrar una foto del producto");
                }

                // ------------------------------------------------------------------//
                //Evaluamos el estado
                if (rbActivo.Checked == true)
                {
                    objProductoBE.estado = "ACTIVO";
                }

                else
                {
                    objProductoBE.estado = "INACTIVO";
                }



                // ------------------------------------------------------------------//
                // Verificar si la fecha de vencimiento sera nula o no
                if (dtpFecVencimiento.Value == DateTime.MinValue || dtpFecVencimiento.Value == DateTime.Today)
                {
                    objProductoBE.fechaVencimiento = null; 
                }

                else
                {
                    objProductoBE.fechaVencimiento = dtpFecVencimiento.Value;
                }

                // ------------------------------------------------------------------//
                //Verificamos si se cambio la foto

                if (blnCambio)
                {
                    // Verifica si se ha seleccionado un archivo
                    if (openFileDialog1.FileName != null && File.Exists(openFileDialog1.FileName))
                    {
                        objProductoBE.fotoProducto = File.ReadAllBytes(openFileDialog1.FileName);
                    }
                    else
                    {
                        // Si no se seleccionó un archivo, asigna null
                        objProductoBE.fotoProducto = null;
                    }
                }
                else
                {
                    // Usa la foto original si no hubo cambio
                    objProductoBE.fotoProducto = FotoOriginal;
                }


                // ------------------------------------------------------------------//
                //cargamos los demas datos

                objProductoBE.idProductos = lblCodigo.Text.Trim();
                objProductoBE.idCategoria = Convert.ToString(cboCategoria.SelectedValue);
                objProductoBE.idProveedor = Convert.ToString(cboProveedor.SelectedValue);
                objProductoBE.idArea = Convert.ToString(cboArea.SelectedValue);
                objProductoBE.nombreProducto = txtNomProducto.Text.Trim();
                objProductoBE.descripcion = txtDescripcion.Text.Trim();
                objProductoBE.precioCompra = Convert.ToSingle(txtPrecioCompra.Text.Trim());
                objProductoBE.precioVenta = Convert.ToSingle(txtPrecioVenta.Text.Trim());
                objProductoBE.stock = Convert.ToInt16(txtStock.Text.Trim());
                objProductoBE.fechaIngreso = dtpFecIngreso.Value;


                if (objProductoBL.actualizarProducto(objProductoBE) == true)
                {
                    this.Close();
                }

                else
                {
                    //Si no se logro insertar lanzamos una excepcion
                    throw new Exception("No se pudo actualizar el producto, contactarse con TI");
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


                if (openFileDialog1.FileName != null)
                {
                    pcbProducto.Image = Image.FromFile(openFileDialog1.FileName);
                    blnCambio = true;
                }

                else
                {
                    blnCambio = false;
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}
