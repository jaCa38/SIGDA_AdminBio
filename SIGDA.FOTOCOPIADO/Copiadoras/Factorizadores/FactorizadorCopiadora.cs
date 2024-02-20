using SIGDA.Catalogos.Genericos.Genericos.Services.Interfaces;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Controllers;
using SIGDA.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Services.Interfaces;

namespace SIGDA.FOTOCOPIADO.Libreria.Copiadoras.Factorizadores
{
    public static class FactorizadorCopiadora
    {
        public static ICopiadoraService CrearConexionGenerica()
        {
            ICopiadoraService nuevoMotor;

            nuevoMotor = new CopiadoraController(CadenasConexion.BDFOTOCOPIADO_LOCAL);

            return nuevoMotor;
        }
    }
}
