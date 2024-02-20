using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.APIProgress.Models.Trans.PNT
{
    public class InfoEmp
    {
        public int IdTrimestre { set; get; }
        public int Anio { set; get; }
        public int IdEmpleado { set; get; }
        public string Nombre { set; get; }
        public string Paterno { set; get; }
        public string Materno { set; get; }
        public string Ingreso { set; get; }
        public string Puesto { set; get; }
        public string Area { set; get; }
        public string Funcion { set; get; }
        public string Municipio { set; get; }
        public string UnidadResponsable { set; get; }
        public string Sexo { set; get; }
        public string EstatusEmpleado { set; get; }
        public int IdEstadoCibvil { set; get; }
        public string Nivel { set; get; }
        public string Sancion { set; get; }

    }
}
