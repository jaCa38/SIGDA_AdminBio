using SIGDA.CA.Biometricos.Libreria.Conexion;
using SIGDA.CA.Biometricos.Libreria.Controllers;
using SIGDA.CA.Biometricos.Libreria.Services;

namespace SIGDA.CA.Biometricos.Libreria.Factorizadores
{
    public class FactorizadorDescargaInfoBiometricos
    {
        public static IDescargaInfoBiometricos CrearConexionBiometricos()
        {
            IDescargaInfoBiometricos nuevoMotor;

            nuevoMotor = new DescargaInfoBiometricosController(ConexionStrings.BDSICA_MYSQL, ConexionStrings.BDSIGDACA_MSSQL);

            return nuevoMotor;
        }



    }
}
