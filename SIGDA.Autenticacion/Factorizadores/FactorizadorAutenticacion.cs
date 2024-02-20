
using SIGDA.Autenticacion.Interfaces;
using SIGDA.Autenticacion.Modelos.Controllers;
using SIGDA.Conexion;

namespace SIGDA.Autenticacion.Libreria.Catalogos.CentrosTrabajo.Factorizadores
{
    public static class FactorizadorAutenticacion
    {
        public static IAutenticacion CrearConMinerva()
        {
            IAutenticacion nuevoMotor;

            nuevoMotor = new AuthController(CadenasConexion.BDMINERVA);

            return nuevoMotor;
        }
    }
}
