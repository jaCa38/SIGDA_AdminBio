using SIGDA.CA.Libreria.Turno.Enums;
using SIGDA.CA.Libreria.Turno.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Libreria.Turno.Models
{
    public class TurnoEmpleadoVariable : ITurnoEmpleadoBase
    {
        public long IdEmpleado { get; set; }
        public ETipoTurnoEmpleado TipoTurno { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public ITipoTurnoBase TurnoDiaDomingo { get; set; } = new TipoTurnoBase();
        public ITipoTurnoBase TurnoDiaLunes { get; set; } = new TipoTurnoBase();
        public ITipoTurnoBase TurnoDiaMartes { get; set; } = new TipoTurnoBase();
        public ITipoTurnoBase TurnoDiaMiercoles { get; set; } = new TipoTurnoBase();
        public ITipoTurnoBase TurnoDiaJueves { get; set; } = new TipoTurnoBase();
        public ITipoTurnoBase TurnoDiaViernes { get; set; } = new TipoTurnoBase();
        public ITipoTurnoBase TurnoDiaSabado { get; set; } = new TipoTurnoBase();

    }
}
