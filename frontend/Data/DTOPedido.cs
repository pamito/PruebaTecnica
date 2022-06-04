namespace frontend.Data
{
    public class DTOPedido
    {
        public DTOPedido() {}

        public long IdPedido { get; set; }
        public string Nit { get; set; }
        public string NombreCliente { get; set; }
        public string DireccionDespacho { get; set; }       
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaDespacho { get; set; }
        public DateTime FechaEntrega { get; set; }
    }
}