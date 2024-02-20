using SIGDA.Conexion;
using SIGDA.SRHN.Libreria.Empleados.Controllers;
using SIGDA.SRHN.Libreria.Empleados.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Empleados.Factorizadores
{
    public class FactorizadorTelefono
    {
        public static ITelefonoService CrearConexion()
        {
            ITelefonoService nuevoMotor;
            nuevoMotor = new TelefonoController(CadenasConexion.BDRH_LOCAL);
            return nuevoMotor;
        }
    }
}
