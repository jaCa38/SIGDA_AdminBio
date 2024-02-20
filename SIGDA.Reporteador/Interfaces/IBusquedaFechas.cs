using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Reporteador.Interfaces
{
    public interface IBusquedaFechas
    {
        DateTime FechaInicio { get; set; }
        DateTime FechaFin { get; set; }
    }
}
