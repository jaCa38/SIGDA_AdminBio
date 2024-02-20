using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Libreria.Punch.Interfaces
{
    public interface IBasePunch
    {
        public long IdRegistroSICA { get; set; }
        public int IdEstatus { get; set; }

    }
}
