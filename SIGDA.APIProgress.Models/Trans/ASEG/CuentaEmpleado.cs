using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.APIProgress.Models.Trans.ASEG
{
    public class CuentaEmpleado
    {
        public int IdQuincena { set; get; }
        public int Anio { set; get; }
        public int IdTrimestre { set; get; }
        public int IdEmpleado { set; get; }
        public string Nombre { set; get; }
        public string CuentaBanco { set; get; }
        public string Banco { set; get; }
    }
}
