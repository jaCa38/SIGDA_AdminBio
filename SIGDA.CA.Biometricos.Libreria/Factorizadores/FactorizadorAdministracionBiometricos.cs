using SIGDA.CA.Biometricos.Libreria.Conexion;
using SIGDA.CA.Biometricos.Libreria.Controllers;
using SIGDA.CA.Biometricos.Libreria.Services;

namespace SIGDA.CA.Biometricos.Libreria.Factorizadores
{
    public class FactorizadorAdministracionBiometricos

    {

        public static IAdministracionBiometrico CrearConexionBiometricos()
        {
            IAdministracionBiometrico nuevoMotor;

            nuevoMotor = new AdministracionBiometricosController(ConexionStrings.BDSICA_MYSQL, ConexionStrings.BDSIGDACA_MSSQL);

            return nuevoMotor;
        }

    }
}
