using SIGDA.CA.Libreria.Turno.Interfaces;
using SIGDA.Catalogos.Genericos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Libreria.Turno.Models
{
    public class TipoTurnoBase : ITipoTurnoBase
    {
        public long IdCatalogoTurno { get; set; }
        public string DescripcionCatalogoTurno { get; set; }
        public long IdentificadorSICA { get; set; }
    }
}
