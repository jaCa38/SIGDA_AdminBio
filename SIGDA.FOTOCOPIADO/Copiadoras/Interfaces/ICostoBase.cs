using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Interfaces
{
    public interface ICostoBase
    {
        public long IdCostoCopia { get; set; }
        public DateTime FechaInicioCostoCopia { get; set; }
        public DateTime FechaFinCostoCopia { get; set; }
        public Decimal CostoCopia { get; set; }
        public long IdZona { get; set; }
    }
}
