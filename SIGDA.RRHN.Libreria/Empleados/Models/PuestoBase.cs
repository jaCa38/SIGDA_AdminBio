using SIGDA.SRHN.Libreria.Empleados.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Models
{
    public class PuestoBase : IPuestoBase
    {
        public int IdEmpleado { set; get; }
        public int IdPlazaConsec { set; get; }
        public string Inicio { set; get; }
        public string Fin { set; get; }
        public string FechaSesionConsejo { set; get; }
        public long FolioConsejo { set; get; }
        public string Observaciones { set; get; }
    }
}
