using SIGDA.Conexion;
using SIGDA.SRHN.Libreria.Deudo.Controllers;
using SIGDA.SRHN.Libreria.Secure.Controllers;
using SIGDA.SRHN.Libreria.Secure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Secure.Factorizadores
{
    public class FactorizadorSecure
    {
        public static IPermisoService CrearConexionPermiso()
        {
            IPermisoService nuevoMotor;
            //ConexionSql sql = ConexionSql.Conectar(CadenasConexion.BDRHN_LOCAL);
            nuevoMotor = new PermisoController(CadenasConexion.BDRHN_LOCAL);
            return nuevoMotor;
        }
        public static IUsuarioService CrearConexionUsuario()
        {
            IUsuarioService nuevoMotor;
            //ConexionSql sql = ConexionSql.Conectar(CadenasConexion.BDRHN_LOCAL);
            nuevoMotor = new UsuarioController(CadenasConexion.BDRHN_LOCAL);
            return nuevoMotor;
        }
    }
}
