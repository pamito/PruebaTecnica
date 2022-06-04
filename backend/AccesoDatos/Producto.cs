using System;
using System.Collections.Generic;

namespace backend.AccesoDatos
{
    public partial class Producto
    {
        public long IdProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string Eanproducto { get; set; }
        public long? CodigoCategoriaProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public long? CodigoEstado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
