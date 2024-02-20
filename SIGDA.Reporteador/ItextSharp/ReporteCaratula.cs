using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGDA.Reporteador.ItextSharp
{
    public class ReporteCaratula:ReportesBase
    {
        public string Anio { set; get; }
        public string Expediente { set; get; }
        public string TipoExpediente { set; get; }
        public string Municipio { set; get; }
        public string Juicio { set; get; }
        public string Promovente { set; get; }
        public string Demandado { set; get; }
        public string Juez { set; get; }
        public string Secretario { set; get; }
        public string FechaRadicacion { set; get; }
        public string FechaResolucion { set; get; }
    }
}
