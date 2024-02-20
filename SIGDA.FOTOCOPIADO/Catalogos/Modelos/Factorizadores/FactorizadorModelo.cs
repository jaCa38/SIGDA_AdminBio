using SIGDA.Conexion;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.Modelos.Controllers;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.Modelos.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.Modelos.Factorizadores
{
    public static class FactorizadorModelo
    {
        public static IModeloService CrearConexionGenerica()
        {
            IModeloService nuevoMotor;

            nuevoMotor = new ModeloController(CadenasConexion.BDFOTOCOPIADO_LOCAL);

            return nuevoMotor;
        }
    }
}
