using SIGDA.Catalogos.Genericos.Genericos.Services.Interfaces;
using SIGDA.Conexion;
using SIGDA.SRHN.Libreria.Deudo.Controllers;
using SIGDA.SRHN.Libreria.Nomina.Catalogo.Controllers;
using SIGDA.SRHN.Libreria.Nomina.Catalogo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Nomina.Catalogo.Factorizadores
{
    public class TablaImpuestosFactorizador
    {
        public static ITablaImpuestosService CrearConexionTablaLimites()
        {
            ITablaImpuestosService nuevoMotor;
            nuevoMotor = new TablaImpuestosController(CadenasConexion.BDRH_LOCAL);
            return nuevoMotor;
        }

    }
}
