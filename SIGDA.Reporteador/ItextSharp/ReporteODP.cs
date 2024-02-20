using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGDA.Reporteador.ItextSharp
{
    public class RepoRecepcion:ReportesBase
    {
        string _parrafoCabecera = string.Empty;
        string _parrafoAnexos = string.Empty;
        string _leyendaVale = string.Empty;
        string _leyendaAnual = string.Empty;

        public string ParrafoCabecera { set { _parrafoCabecera = value; } get { return _parrafoCabecera; } }
        public string ParrafoAnexos { set { _parrafoAnexos = value; } get { return _parrafoAnexos; } }
        public string LeyendaVale { set { _leyendaVale = value; } get { return _leyendaVale; } }
        public string LeyendaAnual { set { _leyendaAnual = value; } get { return _leyendaAnual; } }
    }
}
