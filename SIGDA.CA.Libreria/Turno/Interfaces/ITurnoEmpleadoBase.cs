using SIGDA.CA.Libreria.Turno.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Libreria.Turno.Interfaces
{
    public interface ITurnoEmpleadoBase
    {
        public long IdEmpleado { get; set; }
        public ETipoTurnoEmpleado TipoTurno { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
