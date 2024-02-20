using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Libreria.Turno.Interfaces
{
    public interface IConfigTurno
    {
        public TimeSpan HoraInicioEntrada { get; set; }
        public TimeSpan RetardoInicia { get; set; }
        public TimeSpan RetardoTermina { get; set; }
        public TimeSpan FaltaInicia { get; set; }
        public TimeSpan HorasExtra { get; set; }
    }
}
