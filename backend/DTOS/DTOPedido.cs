namespace backend.DTOS
{
    public class DTOPedido
    {
        public DTOPedido()
        {            
        }

        public long IdPedido { get; set; }
        public long IdCliente { get; set; }
        public string Nit { get; set; }
        public string NombreCliente { get; set; }
        public string DireccionDespacho { get; set; }
        public long CodigoCiudadDespacho { get; set; }        
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaDespacho { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long CodigoEstado { get; set; }

        public string MensajeAccion { get; set; }        
    }
}