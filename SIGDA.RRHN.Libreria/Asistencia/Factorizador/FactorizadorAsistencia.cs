using SIGDA.SRHN.Libreria.Asistencia.Controllers;
using SIGDA.SRHN.Libreria.Asistencia.Services.Interfaces;
using SIGDA.Conexion;
using SIGDA.SRHN.Libreria.Deudo.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Asistencia.Factorizador
{
    public class FactorizadorAsistencia
    {
        public static ICatalogoService CrearConexionCatalogoAsistencia()
        {
            ICatalogoService nuevoMotor;
            nuevoMotor = new CatalogoController(CadenasConexion.BDRHN_LOCAL);
            return nuevoMotor;
        }
        public static IDescuentoEmpleadoService CrearConexionDescuentoEmpleado()
        {
            IDescuentoEmpleadoService nuevoMotor;
            nuevoMotor = new DescuentoEmpleadoController(CadenasConexion.BDRHN_LOCAL);
            return nuevoMotor;
        }
    }
}
