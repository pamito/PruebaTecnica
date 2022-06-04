using System;
using System.Collections.Generic;

namespace backend.AccesoDatos
{
    public partial class Ciudad
    {
        public long CodigoCiudad { get; set; }
        public string CodigoPostal { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
