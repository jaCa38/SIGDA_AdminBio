using SIGDA.SRHN.Libreria.Nomina.Catalogo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Nomina.Catalogo.Models
{
    public class DetalleTabla : IDetalleTablaBase
    {
        public int IdTabla { set; get; }
        public int IdDetalle { set; get; }
        public decimal Inferior { set; get; }
        public decimal Superior { set; get; }
        public decimal CuotaImporte { set; get; }
        public decimal PorcentajeExcedente { set; get; }
        
    }
}
