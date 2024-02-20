using SIGDA.Reporteador.Interfaces;
using SIGDA.Reporteador.ItextSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Reporteador.Models
{
    public class EsquemaReporte : IEsquemaReporte
    {
        public long IdEsquemaReporte { get; set; }
        public string Esquema { get; set; }
        public eTipoReporte TipoReporte { get; set; }
        public bool HabilitarHTML { get; set; }
        public string Descripcion1 { get; set; }
        public string Descripcion2 { get; set; }
        public bool MostrarHeader { get; set; }
        public string TituloFooter { get; set; }
        public bool MostrarOtroTitulo { get; set; }
        public bool MostrarFooter { get; set; }
        public bool Resumen { get; set; }
        public bool MostrarTotales { get; set; }
        public string TituloResumen { get; set; }
    }
}
