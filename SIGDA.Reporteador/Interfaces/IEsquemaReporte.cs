using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Reporteador.Interfaces
{
    public interface IEsquemaReporte
    {
        long IdEsquemaReporte { get; set; }
        string Esquema { get; set; }

    }
}
