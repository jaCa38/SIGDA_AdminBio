using SIGDA.SRHN.Libreria.Catalogos.NuevosCentrosTrabajo.Controllers;
using SIGDA.SRHN.Libreria.Catalogos.NuevosCentrosTrabajo.Services.Interfaces;
using SIGDA.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Catalogos.NuevosCentrosTrabajo.Factorizadores
{
    public static class FactorizadorNuevoCentroTrabajo
    {
        public static INuevoCentroTrabajoService CrearConexionNuevoCentroTrabajo()
        {
            INuevoCentroTrabajoService nuevoMotor;

            //ConexionSql sql = ConexionSql.Conectar(CadenasConexion.BDRHN_LOCAL);
            nuevoMotor = new NuevoCentroTrabajoController(CadenasConexion.BDRHN_LOCAL);

            return nuevoMotor;
        }
    }
}
