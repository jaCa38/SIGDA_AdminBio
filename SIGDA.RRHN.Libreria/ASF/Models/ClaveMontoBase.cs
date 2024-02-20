using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.ASF.Models
{
    public class ClaveMontoBase
    {
        public long IdGeneral { set; get; }
        public string Clave { set; get; }
        public decimal Importe { set; get; }
        /// <summary>
        /// 1 => Percepcion
        /// 2 => Deduccion
        /// 3 => Otros
        /// </summary>
        public int TipoClave { set; get; }
    }
}
