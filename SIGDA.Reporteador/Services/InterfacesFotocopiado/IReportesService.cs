using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Reporteador.Services.InterfacesFotocopiado
{
    public interface IReportesService : IDisposable
    {
        #region Copiadoras
        string ReporteCopiadorasZona(long IdMinerva);

        #endregion


    }
}
