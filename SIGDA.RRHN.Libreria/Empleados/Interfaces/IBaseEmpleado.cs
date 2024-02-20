using SIGDA.SRHN.Libreria.Empleados.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Interfaces
{
    public interface IBaseEmpleado
    {
        public long IdEmpleado { get; set; }
        public long ClaveEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string PaternoEmpleado { get; set; }
        public string MaternoEmpleado { get; set; }
        public DateTime FechaAltaEmpleado { get; set; }
        public ETipoEmpleado TipoEmpleado { get; set; }
    }
}
