using SIGDA.Catalogos.Genericos.Interfaces;
using SIGDA.SRHN.Libreria.Catalogos.Genericos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Catalogos.SubCentrosTrabajo.Models
{
    public class SubCentroTrabajoBase : IBaseModel
    {
        public long IdPrincipal { get; set; }
        public string DescripPrincipal { get; set; }
        public EDivision Division { get; set; }
        public EInstancia Instancia { get; set; }
        public long IdSistema { get; set; }
        public long IdMunicipio { get; set; }
        public long IdCentroTrabajo { get; set; }

    }
}
