using SIGDA.CA.Libreria.Turno.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Libreria.Turno.Models
{
    public class ConfigTurnoBase : IConfigTurnoBase
    {
        public long IdConfigTurno { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public string DescripcionCatalogoTurno { get; set; }
    }
}
