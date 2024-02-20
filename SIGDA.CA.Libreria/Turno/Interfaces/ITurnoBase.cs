using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Libreria.Turno.Interfaces
{
    public interface ITurnoBase
    {
        public TimeSpan TurnoEntrada { get; set; }
        public TimeSpan TurnoSalida { get; set; }
    }
}
