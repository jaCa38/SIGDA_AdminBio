using SIGDA.CA.Biometricos.Libreria.Conexion;
using SIGDA.CA.Biometricos.Libreria.Services.Interfaces;

namespace SIGDA.CA.Biometricos.Libreria.Factorizadores
{
    public class FactorizadorInsertarDatosDb
    {
        public static IInsertarDatosDb CrearConexionBiometricos()
        {
            IInsertarDatosDb nuevoMotor;

            nuevoMotor = new InsertarDatosDbController(ConexionStrings.BDSICA_MYSQL, ConexionStrings.BDSIGDACA_MSSQL);

            return nuevoMotor;
        }
    }
}
