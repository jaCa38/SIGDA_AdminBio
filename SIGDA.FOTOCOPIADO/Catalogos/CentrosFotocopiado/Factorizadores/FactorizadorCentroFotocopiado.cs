using SIGDA.Conexion;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosFotocopiado.Controllers;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosFotocopiado.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.CentrosFotocopiado.Factorizadores
{
    public static class FactorizadorCentroFotocopiado
    {
        public static ICentroFotocopiadoService CrearConexionGenerica()
        {
            ICentroFotocopiadoService nuevoMotor;

            nuevoMotor = new CentrosFotocopiadoController(CadenasConexion.BDFOTOCOPIADO_LOCAL);

            return nuevoMotor;
        }
    }
}
