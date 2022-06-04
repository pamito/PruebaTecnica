using System;
using System.Collections.Generic;

namespace backend.AccesoDatos
{
    public partial class Estado
    {
        public long CodigoEstado { get; set; }
        public string NombreEstado { get; set; }
        public long CodigoTipoEstado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
