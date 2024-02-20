using SIGDA.Reporteador.ItextSharp;
using SIGDA.Reporteador.Models;
using SIGDA.Reporteador.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Reporteador.Services.Interfaces
{
    public interface IBaseReportesService: IDisposable
    {
        EsquemaReporte ConsultarEsquemaReporte(long IdReporte);
        string ArchivarDocumentoTemporal(long IdMinerva, ConfigReporteador configReporteador, ConfigArchivo configArchivo);
    }
}
