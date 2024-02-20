using SIGDA.SRHN.Libreria.Catalogos.Genericos.Enums;
using SIGDA.Catalogos.Genericos.Interfaces;
using SIGDA.SRHN.Libreria.Catalogos.NuevosCentrosTrabajo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Catalogos.NuevosCentrosTrabajo.Models
{
    public class NuevoCentroTrabajoBase : INuevoCentroTrabajoBase, IBaseModel
    {
        public long IdPrincipal { get; set; }
        public string DescripPrincipal { get; set; }
        public EDivision Division { get; set; }
        public EInstancia Instancia { get; set; }
        public long IdSistema { get; set; }
        public long IdMunicipio { get; set; }
        public long IdCentroTrabajo { get; set; }
        public string? DescripcionSubCT { get; set; }
        public string? ClaveNomina { get; set; }//1-1-14-1

    }
}
