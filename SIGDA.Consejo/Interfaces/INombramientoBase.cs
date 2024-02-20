using SIGDA.Consejo.Libreria.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Consejo.Libreria.Interfaces
{
    public interface INombramientoBase
    {
        public ETipoNombramiento TipoMovimiento { get; set; }
        public long IdPlaza { get; set; }
    }
}
