using SIGDA.Conexion;
using SIGDA.Consejo.Libreria.Controllers;
using SIGDA.Consejo.Libreria.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Consejo.Libreria.Factorizadores
{
    public class FactorizadorConsejo
    {
        //BDCONSEJO_MSSQL
        public static IGestionConsejoService CrearConexion(long IdMinerva)
        {
            IGestionConsejoService nuevoMotor;

            nuevoMotor = new ConsejoController(CadenasConexion.BDCONSEJO_MSSQL,IdMinerva);

            return nuevoMotor;
        }

        public static IGestionConsejoService CrearConexionAmbasBD(long IdMinerva)
        {
            IGestionConsejoService nuevoMotor;

            nuevoMotor = new ConsejoController(CadenasConexion.BDCONSEJO_MSSQL, CadenasConexion.BDRH_LOCAL,IdMinerva);

            return nuevoMotor;
        }
    }
}
