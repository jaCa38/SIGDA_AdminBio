using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.APIProgress.Models.Trans.PNT
{
    public class RemuneracionBrutaNetaTabla
    {
        public int AnioTrimestre { set; get; }
        public int IdTrimestre { set; get; }
        public int IdTabla { set; get; }
        public int IdConsecInterno { set; get; }
        public int IdEmpleado { set; get; }
        public string Denominacion { set; get; }
        public decimal Bruto { set; get; }
        public decimal Neto { set; get; }
        public string TipoMoneda { set; get; }
        public string Periodicidad { set; get; }
    }
}
