
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Catalogos.NuevosCentrosTrabajo.Interfaces
{
    public interface INuevoCentroTrabajoBase
    {
        public long IdSistema { get; set; }
        public long IdMunicipio { get; set; }
        public long IdCentroTrabajo { get; set; }
    }
}
