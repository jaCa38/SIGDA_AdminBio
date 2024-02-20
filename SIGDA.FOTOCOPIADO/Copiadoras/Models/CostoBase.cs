using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Models
{
    public class CostoBase : ICostoBase
    {
        public long IdCostoCopia { get; set; }
        public DateTime FechaInicioCostoCopia { get; set; }
        public DateTime FechaFinCostoCopia { get; set; }
        public decimal CostoCopia { get; set; }
        public long IdZona { get; set; }
    }
}
