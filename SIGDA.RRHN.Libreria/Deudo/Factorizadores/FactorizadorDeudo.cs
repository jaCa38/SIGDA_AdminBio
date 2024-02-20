using SIGDA.Catalogos.Genericos.Genericos.Services.Interfaces;
using SIGDA.Conexion;
using SIGDA.SRHN.Libreria.Deudo.Controllers;
using SIGDA.SRHN.Libreria.Deudo.Services;
using SIGDA.SRHN.Libreria.Deudo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Deudo.Factorizadores
{
    public class FactorizadorDeudo
    {
        public static IModelGenericoService CrearConexionConcepto()
        {
            IModelGenericoService nuevoMotor;

            //ConexionSql sql = ConexionSql.Conectar(CadenasConexion.BDRHN_LOCAL);
            nuevoMotor = new ConceptoController(CadenasConexion.BDRHN_LOCAL);

            return nuevoMotor;
        }

        public static IEstatusService CrearConexionEstatus()
        {
            IEstatusService nuevoMotor;

            //ConexionSql sql = ConexionSql.Conectar(CadenasConexion.BDRHN_LOCAL);
            nuevoMotor = new EstatusController(CadenasConexion.BDRHN_LOCAL);

            return nuevoMotor;
        }

        public static ITipoRecuperacionService CrearConexionTipoRecuperacion()
        {
            ITipoRecuperacionService nuevoMotor;
            nuevoMotor = new TipoRecuperacionController(CadenasConexion.BDRHN_LOCAL);
            return nuevoMotor;
        }
        public static IRegistroService CrearConexionRegistro()
        {
            IRegistroService nuevoMotor;
            nuevoMotor = new RegistroController(CadenasConexion.BDRHN_LOCAL);
            return nuevoMotor;
        }
        public static ISeguimientoService CrearConexionSeguimiento()
        {
            ISeguimientoService nuevoMotor;
            nuevoMotor = new SeguimientoController(CadenasConexion.BDRHN_LOCAL);
            return nuevoMotor;
        }
        public static IDestinoService CrearConexionDestino()
        {
            IDestinoService nuevoMotor;
            nuevoMotor = new DestinoController(CadenasConexion.BDRHN_LOCAL);
            return nuevoMotor;
        }        
    }
}
