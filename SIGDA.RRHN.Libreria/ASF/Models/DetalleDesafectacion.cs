using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.ASF.Models
{
    public class DetalleDesafectacion
    {
        public int IdClave { set; get; }
        public decimal Gravado { set; get; }
        public decimal Exento { set; get; }
        public int IdTipoClave { set; get; }
    }
}
