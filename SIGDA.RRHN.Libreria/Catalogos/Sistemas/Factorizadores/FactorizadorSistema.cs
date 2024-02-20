using SIGDA.Conexion;
using SIGDA.SRHN.Libreria.Catalogos.Sistemas.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGDA.Catalogos.Genericos.Genericos.Services.Interfaces;

namespace SIGDA.SRHN.Libreria.Catalogos.Sistemas.Factorizadores
{
    public static class FactorizadorSistema
    {
        public static IModelGenericoService CrearConexionGenerica()
        {
            IModelGenericoService nuevoMotor;

            //ConexionSql sql = ConexionSql.Conectar(CadenasConexion.BDRHN_LOCAL);
            nuevoMotor = new SistemaController(CadenasConexion.BDRHN_LOCAL);

            return nuevoMotor;
        }
    }
}
