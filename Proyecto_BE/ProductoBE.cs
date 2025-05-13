using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_BE
{
    public class ProductoBE
    {

        public String idProductos {  get; set; }
        public String idCategoria { get; set; }
        public String idProveedor { get; set; }
        public String idArea {  get; set; }
        public String nombreProducto { get; set; }
        public String descripcion { get; set; }
        public Single precioCompra {  get; set; }   
        public Single precioVenta {  get; set; }    
        public Int16 stock { get; set; }
        public DateTime fechaIngreso { get; set; }
        public DateTime? fechaVencimiento { get; set; }
        public String estado {  get; set; } 
        public Byte[] fotoProducto {  get; set; }




    }
}
