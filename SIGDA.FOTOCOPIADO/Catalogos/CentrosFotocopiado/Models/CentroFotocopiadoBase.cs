using SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosFotocopiado.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosFotocopiado.Models
{
    public class CentroFotocopiadoBase : ICentroFotocopiadoBase
    {
        public long IdCentroFotocopiado { get; set; }
        public long IdZona { get; set; }
        public long IdMunicipio { get; set; }
        public string NombreCentroFotocopiado { get; set; }
    }
}
