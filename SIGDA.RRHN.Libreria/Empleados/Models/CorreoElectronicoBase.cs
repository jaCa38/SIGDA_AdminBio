using SIGDA.SRHN.Libreria.Empleados.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Models
{
    public class CorreoElectronicoBase : ICorreoElectronicoBase
    {
        public int IdEmail { set; get; }
        public string Email { set; get; }
        public int IdEmpleado { set; get; }
    }
}
