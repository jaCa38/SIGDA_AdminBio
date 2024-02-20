using SIGDA.Reporteador.ItextSharp;
using SIGDA.Reporteador.Models;
using SIGDA.Reporteador.Services.Interfaces;
using SIGDA.Reporteador.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Reporteador.Services
{
    public class BaseReportesService : IBaseReportesService
    {
        private readonly IBaseReportesService _baseReportesService;
        public BaseReportesService(IBaseReportesService baseReportesService)
        {
            _baseReportesService = baseReportesService;
        }

        public string ArchivarDocumentoTemporal(long IdMinerva, ConfigReporteador configReporteador, ConfigArchivo configArchivo)
        {
            return _baseReportesService.ArchivarDocumentoTemporal(IdMinerva, configReporteador, configArchivo);
        }

        public EsquemaReporte ConsultarEsquemaReporte(long IdReporte)
        {
            return _baseReportesService.ConsultarEsquemaReporte(IdReporte);
        }

        public void Dispose()
        {
            try { }
            catch { }
        }
    }
}
