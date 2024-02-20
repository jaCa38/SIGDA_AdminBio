using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.APIProgress.Models.Trans.ASEG.CveEmp
{
    public class ClaveEmpleadoTrim
    {
        public int IdQuincena { set; get; }
        public int AnioQna { set; get; }
        public int IdTrimestre { set; get; }
        public int IdEmpleado { set; get; }
        public int IdClave { set; get; }
        public decimal Importe { set; get; }
    }
}
