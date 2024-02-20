using SIGDA.Conexion;
using SIGDA.SRHN.Libreria.Historicos.Controllers;
using SIGDA.SRHN.Libreria.Historicos.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Historicos.Factorizadores
{
    public static class FactorizadorCatalogosHistorico
    {
        public static ICatalogosHistoricoService CrearConexionCatalogosHistorico()
        {
            ICatalogosHistoricoService nuevoMotor;

            //ConexionSql sql = ConexionSql.Conectar(CadenasConexion.BDRHN_LOCAL);
            nuevoMotor = new CatalogosHistoricoController(CadenasConexion.BDRHN_LOCAL);

            return nuevoMotor;
        }
    }
}
