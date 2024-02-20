using SIGDA.Catalogos.Genericos.Genericos.Services.Interfaces;
using SIGDA.Catalogos.Genericos.Services.Interfaces;
using SIGDA.Conexion;
using SIGDA.SRHN.Libreria.Catalogos.Catalogo.Controllers;
using SIGDA.SRHN.Libreria.Catalogos.Escolaridades.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.SRHN.Libreria.Catalogos.Catalogo.Factorizadores
{
    public class FactorizadorCatalogo
    {
        public static IModelCatalogoBaseService CrearConexionCatalogo()
        {
            IModelCatalogoBaseService nuevoMotor;
            nuevoMotor = new CatalogoController(CadenasConexion.BDRHN_LOCAL);
            return nuevoMotor;
        }
    }
}
