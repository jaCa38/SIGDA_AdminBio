using SIGDA.Conexion;
using SIGDA.FOTOCOPIADO.Libreria.Vales.Controllers;
using SIGDA.FOTOCOPIADO.Libreria.Vales.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Vales.Factorizadores
{
    public static class FactorizadorVale
    {
        public static IValeService CrearConexionGenerica()
        {
            IValeService nuevoMotor;

            nuevoMotor = new ValeController(CadenasConexion.BDFOTOCOPIADO_LOCAL);

            return nuevoMotor;
        }
    }
}
