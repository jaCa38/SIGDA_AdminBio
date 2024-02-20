using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Interfaces
{
    public interface IPlazaBase
    {
        public int IdPlazaConsec { set; get; }
        public string IdentificadorNominaProgress { set; get; }
        public int IdPlazaNominaProgress { set; get; }
        public string Denominacion { set; get; }
        public string Funcion { set; get; }
        public string Nivel { set; get; }
        public int IdEstatusPlaza { set; get; }
        public string DescripcionEstatusPlaza { set; get; }
        

    }
}
