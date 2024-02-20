using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Libreria.Turno.Interfaces
{
    public interface ITipoTurnoBase
    {
        public long IdCatalogoTurno { get; set; }
        public string DescripcionCatalogoTurno { get; set; }
    }
}
