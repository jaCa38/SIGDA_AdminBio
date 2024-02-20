using SIGDA.CA.Libreria.Turno.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Libreria.Turno.Models
{
    public class ConfigTurno : IConfigTurnoBase, IConfigTurno, ITipoTurnoBase
    {
        public long IdConfigTurno { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public TimeSpan HoraInicioEntrada { get; set; }
        public TimeSpan RetardoInicia { get; set; }
        public TimeSpan RetardoTermina { get; set; }
        public TimeSpan FaltaInicia { get; set; }
        public TimeSpan HorasExtra { get; set; }
        public long IdCatalogoTurno { get; set; }
        public string DescripcionCatalogoTurno { get; set; }
    }
}
