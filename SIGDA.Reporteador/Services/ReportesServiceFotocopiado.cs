using SIGDA.Reporteador.Services.InterfacesFotocopiado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Reporteador.Services
{
    public class ReportesServiceFotocopiado : IReportesService
    {
        private readonly IReportesService _reportesService;

        public ReportesServiceFotocopiado(IReportesService reportesService)
        {
            _reportesService = reportesService;
        }

        public void Dispose()
        {
            try { }
            catch { }
        }

        public string ReporteCopiadorasZona(long IdMinerva)
        {
            return _reportesService.ReporteCopiadorasZona(IdMinerva);
        }
    }
}
