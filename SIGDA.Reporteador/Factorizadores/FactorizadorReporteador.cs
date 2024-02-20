using SIGDA.Reporteador.Controllers;
using SIGDA.Reporteador.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Reporteador.Factorizadores
{
    public static class FactorizadorReporteador
    {
        public static Services.InterfacesFotocopiado.IReportesService CrearConexionReportesFotocopiado()
        {
            Services.InterfacesFotocopiado.IReportesService nuevoMotor;

            nuevoMotor = new FotocopiadoController(ConnectionStrings.BDREPORTES);

            return nuevoMotor;
        }
    }
}
