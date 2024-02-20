using SIGDA.Conexion;
using SIGDA.FOTOCOPIADO.Libreria.Depositos.Controllers;
using SIGDA.FOTOCOPIADO.Libreria.Depositos.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Depositos.Factorizadores
{
    public static class FactorizadorDeposito
    {
        public static IDepositoService CrearConexionGenerica()
        {
            IDepositoService nuevoMotor;

            nuevoMotor = new DepositoController(CadenasConexion.BDFOTOCOPIADO_LOCAL);

            return nuevoMotor;
        }
    }
}
