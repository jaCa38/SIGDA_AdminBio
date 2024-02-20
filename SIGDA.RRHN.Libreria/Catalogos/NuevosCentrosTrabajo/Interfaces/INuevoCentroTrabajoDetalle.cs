using SIGDA.SRHN.Libreria.Catalogos.Genericos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Catalogos.NuevosCentrosTrabajo.Interfaces
{
    public interface INuevoCentroTrabajoDetalle
    {
        public string DescripcionCentroTrabajo { get; set; }
        public long IdSubCentroTrabajo { get; set; }
        public string DescripcionSubCentroTrabajo { get; set; }
        public string IdentificadorNomina { get; set; }
        public EDivision IdDivision { get; set; }
        public EInstancia IdInstancia { get; set; }
        public string DescripcionMunicipio { get; set; }
        public int Activo { get; set; }

    }
}
