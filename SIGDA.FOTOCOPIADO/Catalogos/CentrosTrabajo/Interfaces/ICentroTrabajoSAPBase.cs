using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosTrabajo.Interfaces
{
    public interface ICentroTrabajoSAPBase
    {
        public long IdentificadorCCS { get; set; }
        public string ClaveCSS { get; set; }
        public string DenominacionCSS { get; set; }
        public string DescripcionCSS { get; set; }
        public string CentroTrabajoCSS { get; set; }
        public long IdZona { get; set; }
        public string Zona { get; set; }
    }
}
