using SIGDA.CA.Biometricos.Libreria.Conexion;
using SIGDA.CA.Biometricos.Libreria.Controllers;
using SIGDA.CA.Biometricos.Libreria.Services.Interfaces;

namespace SIGDA.CA.Biometricos.Libreria.Factorizadores
{
    public class FactorizadorConsultaDb
    {
        public static IConsultarDb CrearConexionBiometricos()
        {
            IConsultarDb nuevoMotor;

            nuevoMotor = new ConsultarDbController(ConexionStrings.BDSICA_MYSQL, ConexionStrings.BDSIGDACA_MSSQL);

            return nuevoMotor;
        }
    }
}
