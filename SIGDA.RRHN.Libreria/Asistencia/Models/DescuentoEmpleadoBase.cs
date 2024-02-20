using SIGDA.SRHN.Libreria.Asistencia.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Asistencia.Models
{
    public class DescuentoEmpleadoBase
    {
        public int IdConsec { set; get; }
        public int IdEmpleado { set; get; }
        public ETipoDescuento IdTipoDescuento { set; get; }
        public EEstatus IdEstatus { set; get; }
    }
}
