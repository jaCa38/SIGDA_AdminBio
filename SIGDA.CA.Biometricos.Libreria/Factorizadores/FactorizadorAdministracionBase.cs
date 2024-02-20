
using SIGDA.CA.Biometricos.Libreria.Conexion;
using SIGDA.CA.Biometricos.Libreria.Controllers;
using SIGDA.CA.Biometricos.Libreria.Services.Interfaces;

namespace SIGDA.CA.Biometricos.Libreria.Factorizadores
{
    public static class FactorizadorAdministracionBase
    {
        public static IAdministracionBase CrearConexionAdministracionBase()
        {
            IAdministracionBase nuevoMotor;

            nuevoMotor = new AdministracionBaseController(ConexionStrings.BDSICA_MYSQL, ConexionStrings.BDSIGDACA_MSSQL);

            return nuevoMotor;
        }
    }
}
