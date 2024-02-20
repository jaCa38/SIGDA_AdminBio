using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.APIProgress.Models.ASF
{
    public class CuotaISSEGISSSTEProgress
    {
        public int IdQuincena { set; get; }
        public int AnioQuincena { set; get; }
        public decimal Importe { set; get; }
        public string Texto { set; get; }
        public string PosPre { set; get; }
        public string CentroGestor { set; get; }
        public string Fondo { set; get; }
        public string AreaFuncional { set; get; }
        public string ElementoPEP { set; get; }
        public string CuentaMayor { set; get; }
        public string CentroCosto { set; get; }
    }
}
