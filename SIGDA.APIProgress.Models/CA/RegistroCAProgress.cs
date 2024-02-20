using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.APIProgress.Models.CA
{
    public class RegistroCAProgress
    {
        public int IdEmpleado { set; get; }
        public string Fecha { set; get; }
        public int IdClave { set; get; }
        public string Entrada { set; get; }
        public string Salida { set; get; }
        public string Responsable { set; get; }
        public string SesionDe { set; get; }
        public string Observaciones { set; get; }
        public int IdEstatusRespuesta { set; get; }
        public string ObservacionesRespuesta { set; get; }
    }
}
