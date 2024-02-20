using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.APIProgress.Models.Vac
{
    public class DatosVacacion
    {
        public string IdentificadorNomina { set; get; }
        public int IdPeriodo { set; get; }
        public int Anio { set; get; }
        public int IdEmpleado { set; get; }
    }
}
