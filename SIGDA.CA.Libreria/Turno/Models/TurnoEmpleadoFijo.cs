using SIGDA.CA.Libreria.Turno.Enums;
using SIGDA.CA.Libreria.Turno.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Libreria.Turno.Models
{
    public class TurnoEmpleadoFijo : ITurnoEmpleadoBase, ITipoTurnoBase
    {
        public long IdEmpleado { get; set; }
        public ETipoTurnoEmpleado TipoTurno { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public long IdCatalogoTurno { get; set; }
        public string DescripcionCatalogoTurno { get; set; }
    }
}
