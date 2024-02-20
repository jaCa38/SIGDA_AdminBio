using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Interfaces
{
    public interface ICorreoElectronicoBase
    {
        public int IdEmail { set; get; }
        public string Email { set; get; }
    }
}
