using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.APIProgress.Models.Vac
{
    public class Puesto
    {
        public int IdUR { set; get; }
        public int IdArea { set; get; }
        public int IdEstado { set; get; }
        public int IdMuncipio { set; get; }
        public int IdCentroTrabajo { set; get; }
        public int IdPlaza { set; get; }
        public int CodigoUnico { set; get; }
        public string IdFuncion { set; get; }
        public string Denominacion { set; get; }
        public string Nivel { set; get; }
    }
}
