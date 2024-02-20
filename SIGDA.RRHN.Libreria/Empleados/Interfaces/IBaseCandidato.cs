using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Interfaces
{
    public interface IBaseCandidato
    {
        public long IdCandidato { get; set; }
        public string NombreCandidato { get; set; }
        public string PaternoCandidato { get; set; }
        public string MaternoCandidato { get; set; }
    }
}
