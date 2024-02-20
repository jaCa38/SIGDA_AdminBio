using SIGDA.Conexion;
using SIGDA.CA.Punch.Controllers;
using SIGDA.CA.Punch.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Punch.Factorizadores
{
    public class FactorizadorPunch
    {
        public static IPunchService CrearConexionPunchs()
        {
            IPunchService nuevoMotor;
            
            nuevoMotor = new PunchController(CadenasConexion.BDSIGDA_CA_MSSQL, CadenasConexion.BDSICA_MYSQL);

            return nuevoMotor;
        }

    }
}
