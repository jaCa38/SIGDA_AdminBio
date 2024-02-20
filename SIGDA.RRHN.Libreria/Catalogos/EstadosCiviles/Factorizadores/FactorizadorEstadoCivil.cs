using SIGDA.Catalogos.Genericos.Genericos.Services.Interfaces;
using SIGDA.SRHN.Libreria.Catalogos.EstadosCiviles.Controllers;
using SIGDA.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Catalogos.EstadosCiviles.Factorizadores
{
    public class FactorizadorEstadoCivil
    {
        public static IModelGenericoService CrearConexionGenerica()
        {
            IModelGenericoService nuevoMotor;

            //ConexionSql sql = ConexionSql.Conectar(CadenasConexion.BDRHN_LOCAL);
            nuevoMotor = new EstadoCivilController(CadenasConexion.BDRHN_LOCAL);

            return nuevoMotor;
        }
    }
}
