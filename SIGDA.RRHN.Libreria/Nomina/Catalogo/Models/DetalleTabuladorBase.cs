using SIGDA.SRHN.Libreria.Nomina.Catalogo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Nomina.Catalogo.Models
{
    public class DetalleTabuladorBase : IDetalleTabuladorBase
    {
        public int IdTabla { set; get; }
        public int IdDetalle { set; get; }
        public string Nivel { set; get; }
        public decimal BaseGravable { set; get; }
        public decimal ImpuestoMensual { set; get; }
        public decimal Isseg { set; get; }
        public decimal Issste { set; get; }
        public decimal BrutoMensual { set; get; }
        public decimal NetoMensual { set; get; }
        public List<ClaveImporteBase> ListaClavesImportes { set; get; } = new List<ClaveImporteBase>();
    }
}
