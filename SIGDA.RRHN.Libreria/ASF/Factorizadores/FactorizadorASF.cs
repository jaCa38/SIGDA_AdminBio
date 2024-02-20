using SIGDA.SRHN.Libreria.ASF.Controllers;
using SIGDA.SRHN.Libreria.ASF.Services.Interfaces;
using SIGDA.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.ASF.Factorizadores
{
    public class FactorizadorASF
    {
        public static ICuotasService CrearConexionCuotas()
        {
            ICuotasService nuevoMotor;
            nuevoMotor = new CuotaController(CadenasConexion.BDRHN_LOCAL);
            return nuevoMotor;
        }
        public static INomOrdService CrearConexionNomOrd()
        {
            INomOrdService nuevoMotor;
            nuevoMotor = new NomOrdController(CadenasConexion.BDRHN_LOCAL);
            return nuevoMotor;
        }
        public static IDesafectacionService CrearConexionDesafectacion()
        {
            IDesafectacionService nuevoMotor;
            nuevoMotor = new DesafectacionController(CadenasConexion.BDRHN_LOCAL);
            return nuevoMotor;
        }
    }
}
