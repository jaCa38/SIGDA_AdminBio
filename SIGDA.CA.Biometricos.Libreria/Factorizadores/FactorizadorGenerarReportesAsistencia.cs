using SIGDA.CA.Biometricos.Libreria.Conexion;
using SIGDA.CA.Biometricos.Libreria.Controllers;
using SIGDA.CA.Biometricos.Libreria.Services.Interfaces;

namespace SIGDA.CA.Biometricos.Libreria.Factorizadores
{
    public class FactorizadorGenerarReportesAsistencia
    {
        public static IGenerarReportesAsistencia CrearConexionGenerarReportes()
        {
            IGenerarReportesAsistencia nuevoMotor;

            nuevoMotor = new GenerarReportesAsistenciaController(ConexionStrings.BDSICA_MYSQL, ConexionStrings.BDSIGDACA_MSSQL);

            return nuevoMotor;
        }
    }
}
