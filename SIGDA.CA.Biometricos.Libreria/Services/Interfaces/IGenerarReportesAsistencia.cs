using SIGDA.CA.Biometricos.Libreria.Models;
using System;
using System.Collections.Generic;

namespace SIGDA.CA.Biometricos.Libreria.Services.Interfaces
{
    public interface IGenerarReportesAsistencia : IDisposable
    {
        List<ReporteAsistencia> GenerarReporteAsistencia(int idEmpleado, DateTime fechaInicio, DateTime fechaFin);
    }
}
