using System;
using System.Collections.Generic;

namespace backend.AccesoDatos
{
    public partial class Cliente
    {
        public long IdCliente { get; set; }
        public string Nit { get; set; }
        public string Nombres { get; set; }
        public string DireccionPrincipal { get; set; }
        public string DireccionCorrespondencia { get; set; }
        public string EmailFacturacionElectronica { get; set; }
        public string EmailGeneral1 { get; set; }
        public string TelefonoContacto1 { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public long CodigoCiudadPrincipal { get; set; }
        public long CodigoCiudadCorrespondencia { get; set; }
        public long CodigoGenero { get; set; }
        public string Observaciones { get; set; }
        public long CodigoEstado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
