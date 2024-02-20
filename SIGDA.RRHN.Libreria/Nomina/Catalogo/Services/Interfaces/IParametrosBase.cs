using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Nomina.Catalogo.Services.Interfaces
{
    public interface IParametrosBase 
    {
        public int IdParametro { set; get; }
        public int Anio { set; get; }
        public decimal SalarioMinimo { set; get; }
        public decimal UMA { set; get; }
        public decimal PorcentajeISSEG { set; get; }
        public decimal PorcentajeISSSTE { set; get; }
        public decimal PorcentajeISSEGPatronal { set; get; }
        public decimal PorcentajeISSSTEPatronal { set; get; }
    }
}
