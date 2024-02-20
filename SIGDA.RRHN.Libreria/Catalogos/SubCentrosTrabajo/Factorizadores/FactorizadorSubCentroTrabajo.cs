using SIGDA.SRHN.Libreria.Catalogos.SubCentrosTrabajo.Services.Interfaces;
using SIGDA.Conexion;
using SIGDA.SRHN.Libreria.Catalogos.SubCentrosTrabajo.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Catalogos.SubCentrosTrabajo.Factorizadores
{
    public static class FactorizadorSubCentroTrabajo
    {
        public static ISubCentroTrabajoService CrearConexionSubCentroTrabajo()
        {
            ISubCentroTrabajoService nuevoMotor;

            //ConexionSql sql = ConexionSql.Conectar(CadenasConexion.BDRHN_LOCAL);
            nuevoMotor = new SubCentroTrabajoController(CadenasConexion.BDRHN_LOCAL);

            return nuevoMotor;
        }
    }
}
