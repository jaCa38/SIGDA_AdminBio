using SIGDA.Conexion;
using SIGDA.SRHN.Libreria.Catalogos.Curriculum.Controllers;
using SIGDA.Catalogos.Genericos.Genericos.Services.Interfaces;
using SIGDA.SRHN.Libreria.Catalogos.SubCentrosTrabajo.Controllers;
using SIGDA.SRHN.Libreria.Catalogos.SubCentrosTrabajo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGDA.Catalogos.Genericos.Services.Interfaces;

namespace SIGDA.SRHN.Libreria.Catalogos.Curriculum.Factorizadores
{
    public class FactorizadorNivelAcademico
    {
        public static INivelAcademicoService CrearConexionNivelAcademico()
        {
            INivelAcademicoService nuevoMotor;
            nuevoMotor = new NivelAcademicoController(CadenasConexion.BDCV_LOCAL);
            return nuevoMotor;
        }
    }
}
