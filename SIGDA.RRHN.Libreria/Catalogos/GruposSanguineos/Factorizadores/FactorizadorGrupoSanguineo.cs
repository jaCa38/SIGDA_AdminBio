
using SIGDA.Catalogos.Genericos.Genericos.Services.Interfaces;
using SIGDA.SRHN.Libreria.Catalogos.GruposSanguineos.Controllers;
using SIGDA.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Catalogos.GruposSanguineos.Factorizadores
{
    public class FactorizadorGrupoSanguineo
    {
        public static IModelGenericoService CrearConexionGenerica()
        {
            IModelGenericoService nuevoMotor;

            //ConexionSql sql = ConexionSql.Conectar(CadenasConexion.BDRHN_LOCAL);
            nuevoMotor = new GrupoSanguineoController(CadenasConexion.BDRHN_LOCAL);

            return nuevoMotor;
        }
    }
}
