using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Nomina.Catalogo.Services.Interfaces
{
    public interface IDetalleTablaBase
    {
        public int IdDetalle { set; get; }
        public decimal Inferior { set; get; }
        public decimal Superior { set; get; }
        public decimal CuotaImporte { set; get; }        
    }
}
