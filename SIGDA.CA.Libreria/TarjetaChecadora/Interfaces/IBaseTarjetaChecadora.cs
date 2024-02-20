using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Libreria.TarjetaChecadora.Interfaces
{
    public interface IBaseTarjetaChecadora
    {
        public long IdClaveEmpleado { get; set; }
        public DateTime FechaChecada { get; set; }
        public TimeSpan HoraChecada { get; set; }

    }
}
