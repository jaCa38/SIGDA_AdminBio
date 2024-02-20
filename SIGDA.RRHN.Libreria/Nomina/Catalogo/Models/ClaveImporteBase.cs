using SIGDA.SRHN.Libreria.Nomina.Catalogo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Nomina.Catalogo.Models
{
    public class ClaveImporteBase : IClaveImporteBase
    {
        public int IdDetalle { set; get; }
        public int IdImporteClave { set; get; }
        public int IdClave { set; get; }
        public decimal Importe { set; get; }
    }
}
