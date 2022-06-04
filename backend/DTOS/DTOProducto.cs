namespace backend.DTOS
{
    public class DTOProducto
    {
        public DTOProducto()
        {            
        }

        public long IdProducto { get; set; }
        public string CodigoProducto { get; set; } = null!;
        public string Eanproducto { get; set; } = null!;
        public long CodigoCategoriaProducto { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Precio { get; set; }
        public long CodigoEstado { get; set; }
        public string NombreEstado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }

        public string MensajeAccion { get; set; }        
    }
}