using SIGDA.Conexion;
using SIGDA.CA.Libreria.Turno.Controllers;
using SIGDA.CA.Libreria.Turno.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.CA.Libreria.Turno.Factorizadores
{
    public class FactorizadorTurno
    {
        public static ITurnoSICAService CrearConexionTurnoSICA()
        {
            ITurnoSICAService nuevoMotor;

            nuevoMotor = new TurnoSICAController(CadenasConexion.BDSIGDA_CA_MSSQL, CadenasConexion.BDSICA_MYSQL);

            return nuevoMotor;
        }

        public static ITipoTurnoService CrearConexionTipoTurno()
        {
            ITipoTurnoService nuevoMotor;

            nuevoMotor = new TurnoController(CadenasConexion.BDSIGDA_CA_MSSQL);

            return nuevoMotor;
        }

        public static IConfigTurnoService CrearConexionConfigTurno()
        {
            IConfigTurnoService nuevoMotor;

            nuevoMotor = new TurnoController(CadenasConexion.BDSIGDA_CA_MSSQL);

            return nuevoMotor;
        }

        public static ITurnoEmpleado CrearConexionTurnoEmpleado()
        {
            ITurnoEmpleado nuevoMotor;

            nuevoMotor = new TurnoController(CadenasConexion.BDSIGDA_CA_MSSQL);

            return nuevoMotor;
        }
    }
}
