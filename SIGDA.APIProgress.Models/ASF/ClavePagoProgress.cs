using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.APIProgress.Models.ASF
{
    public class ClavePagoProgress
    {
        public int IdClave { set; get; }
        public string Descripcion { set; get; }
        public int IdTipoClave { set; get; }
        public string DescripTipoClave { set; get; }
    }
}
