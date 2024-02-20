using SIGDA.CA.Biometricos.Libreria.Conexion;
using SIGDA.CA.Biometricos.Libreria.Controllers;
using SIGDA.CA.Biometricos.Libreria.Services.Interfaces;

namespace SIGDA.CA.Biometricos.Libreria.Factorizadores
{
    public class FactorizadorDescargaFotografias
    {

        public static IDescargaFotografias CrearConexionBiometricos()
        {
            IDescargaFotografias nuevoMotor;

            nuevoMotor = new DescargaFotografiasController(ConexionStrings.BDSICA_MYSQL, ConexionStrings.BDSIGDACA_MSSQL);

            return nuevoMotor;
        }
    }
}
