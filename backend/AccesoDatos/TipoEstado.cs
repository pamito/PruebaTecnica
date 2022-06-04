using System;
using System.Collections.Generic;

namespace backend.AccesoDatos
{
    public partial class TipoEstado
    {
        public long CodigoTipoEstado { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
