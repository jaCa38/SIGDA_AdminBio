using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Models
{
    public class InformacionLaboralBase
    {
        public int IdEmpleado { set; get; }
        public int IdLaboral { set; get; }
        public string Institucion { set; get; }
        public string Puesto { set; get; }
        public int MesDesde { set; get; }
        public int AnioDesde { set; get; }
        public int MesHasta { set; get; }
        public int AnioHasta { set; get; }
        public int EmpleoActual { set; get; }
        public string Actividades { set; get; }
        public string Ubicacion { set; get; }
        public int IdMunicipio { set; get; }
    }
}
