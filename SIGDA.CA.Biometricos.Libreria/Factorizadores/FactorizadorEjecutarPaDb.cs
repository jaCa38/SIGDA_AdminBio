using SIGDA.CA.Biometricos.Libreria.Conexion;
using SIGDA.CA.Biometricos.Libreria.Controllers;
using SIGDA.CA.Biometricos.Libreria.Services.Interfaces;

namespace SIGDA.CA.Biometricos.Libreria.Factorizadores
{
    public class FactorizadorEjecutarPaDb
    {

        public static IEjecutarPaDb CrearConexionAdministracionEjecutarPa()
        {
            IEjecutarPaDb nuevoMotor;

            nuevoMotor = new EjecutarPaDbController(ConexionStrings.BDSICA_MYSQL, ConexionStrings.BDSIGDACA_MSSQL);

            return nuevoMotor;
        }
    }
}
