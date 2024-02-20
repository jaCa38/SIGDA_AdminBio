using SIGDA.Conexion;
using SIGDA.SRHN.Libreria.Nomina.Catalogo.Controllers;
using SIGDA.SRHN.Libreria.Nomina.Catalogo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Nomina.Catalogo.Factorizadores
{
    public class TabuladorFactorizador
    {
        public static ITabuladorService CrearConexionTabulador()
        {
            ITabuladorService nuevoMotor;
            nuevoMotor = new TabuladorController(CadenasConexion.BDRH_LOCAL);
            return nuevoMotor;
        }
    }
}
