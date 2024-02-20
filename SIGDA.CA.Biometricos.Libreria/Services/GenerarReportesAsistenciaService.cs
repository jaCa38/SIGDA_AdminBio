using SIGDA.CA.Biometricos.Libreria.Models;
using SIGDA.CA.Biometricos.Libreria.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace SIGDA.CA.Biometricos.Libreria.Services
{
    public class GenerarReportesAsistenciaService
    {

        private readonly IGenerarReportesAsistencia _metodos;
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public GenerarReportesAsistenciaService(IGenerarReportesAsistencia metodos)
        {
            _metodos = metodos;
        }


        public List<ReporteAsistencia> GenerarReporteAsistencia(int idEmpleado, DateTime fechaInicio, DateTime fechaFin)
        {
            return _metodos.GenerarReporteAsistencia(idEmpleado, fechaInicio, fechaFin);
        }

    }
}
