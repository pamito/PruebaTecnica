using System;
using System.Collections.Generic;

namespace backend.AccesoDatos
{
    public partial class PedidoDetalle
    {
        public long IdPedidoDetalle { get; set; }
        public long IdPedido { get; set; }
        public long IdProducto { get; set; }
        public int Linea { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal TotalLinea { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
