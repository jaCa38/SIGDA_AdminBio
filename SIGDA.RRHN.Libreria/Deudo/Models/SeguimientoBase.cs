using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Deudo.Models
{
    public class SeguimientoBase
    {
        public int IdSeguimiento { set; get; }
        public int IdRegistro { set; get; }
        public string NumOficio { set; get; }
        public string FechaOficio { set; get; }
        public int IdDestino { set; get; }
        public string Destino { set; get; }
        public string Observaciones { set; get; }
        public int IdUsuario { set; get; }
        public string Monto { set; get; }
    }
}
