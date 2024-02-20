using SIGDA.SRHN.Libreria.Catalogos.Genericos.Enums;
using SIGDA.SRHN.Libreria.Catalogos.NuevosCentrosTrabajo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Catalogos.NuevosCentrosTrabajo.Models
{
    public class NuevoCentroTrabajoDetalle : INuevoCentroTrabajoDetalle, INuevoCentroTrabajoBase
    {
        public string DescripcionCentroTrabajo { get; set; }
        public long IdSubCentroTrabajo { get; set; }
        public string DescripcionSubCentroTrabajo { get; set; }
        public string IdentificadorNomina { get; set; }
        public EDivision IdDivision { get; set; }
        public EInstancia IdInstancia { get; set; }
        public string DescripcionMunicipio { get; set; }
        public int Activo { get; set; }
        public long IdSistema { get; set; }
        public long IdMunicipio { get; set; }
        public long IdCentroTrabajo { get; set; }
    }
}
