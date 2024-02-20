using SIGDA.Consejo.Libreria.Enums;
using SIGDA.Consejo.Libreria.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Consejo.Libreria.Models
{
    public class NombramientoBase : ITipoMovimientoBase, INombramientoBase
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public ETipoNombramiento TipoMovimiento { get; set; }
        public long IdPlaza { get; set; }
    }
}
