using SIGDA.Catalogos.Genericos.Genericos.Services.Interfaces;
using SIGDA.SRHN.Libreria.Catalogos.Municipios.Controllers;
using SIGDA.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGDA.Catalogos.Genericos.Services.Interfaces;

namespace SIGDA.SRHN.Libreria.Catalogos.Municipios.Factorizadores
{
    public static class FactorizadorMunicipio
    {
        public static IModelGenericoService CrearConexionGenerica()
        {
            IModelGenericoService nuevoMotor;

            //ConexionSql sql = ConexionSql.Conectar(CadenasConexion.BDRHN_LOCAL);
            nuevoMotor = new MunicipioController(CadenasConexion.BDRHN_LOCAL);

            return nuevoMotor;
        }
        public static IZonaBaseService CrearConexionGenericaZona()
        {
            IZonaBaseService nuevoMotor;

            //ConexionSql sql = ConexionSql.Conectar(CadenasConexion.BDRHN_LOCAL);
            nuevoMotor = new MunicipioController(CadenasConexion.BDRHN_LOCAL);            
            return nuevoMotor;
        }
    }
}
