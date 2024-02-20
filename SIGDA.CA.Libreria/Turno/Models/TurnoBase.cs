using SIGDA.CA.Libreria.Turno.Interfaces;
using SIGDA.Catalogos.Genericos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Libreria.Turno.Models
{
    public class TurnoBase : BaseModel, ITurnoBase
    {
        public TimeSpan TurnoEntrada { get; set; }
        public TimeSpan TurnoSalida { get; set; }
    }
}
