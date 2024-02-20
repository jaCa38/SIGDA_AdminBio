using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosFotocopiado.Interfaces
{
    public interface ICentroFotocopiadoDetalle
    {
        public string Zona { get; set; }
        public string Municipio { get; set; }
    }
}
