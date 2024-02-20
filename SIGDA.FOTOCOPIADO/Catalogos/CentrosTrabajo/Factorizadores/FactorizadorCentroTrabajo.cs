using SIGDA.Conexion;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosTrabajo.Controllers;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosTrabajo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosTrabajo.Factorizadores
{
    public class FactorizadorCentroTrabajo
    {
        public static ICentroTrabajoService CrearConexionGenerica()
        {
            ICentroTrabajoService nuevoMotor;

            nuevoMotor = new CentroTrabajoController(CadenasConexion.BDFOTOCOPIADO_LOCAL);

            return nuevoMotor;
        }
    }
}
