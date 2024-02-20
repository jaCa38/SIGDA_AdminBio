using SIGDA.Conexion;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.Modelos.Services.Interfaces;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.TipoCopia.Controllers;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.TipoCopia.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.TipoCopia.Factorizadores
{
    public static class FactorizadorTipoCopia
    {
        public static ITipoCopiaService CrearConexionGenerica()
        {
            ITipoCopiaService nuevoMotor;

            nuevoMotor = new TipoCopiaController(CadenasConexion.BDFOTOCOPIADO_LOCAL);

            return nuevoMotor;
        }
    }
}
