using SIGDA.Catalogos.Genericos.Genericos.Services.Interfaces;
using SIGDA.Conexion;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.Marcas.Controllers;
using SIGDA.FOTOCOPIADO.Libreria.Catalogos.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.FOTOCOPIADO.Libreria.Catalogos.Marcas.Factorizadores
{
    public static class FactorizadorMarca
    {
        public static IModelGenericoService CrearConexionGenerica()
        {
            IModelGenericoService nuevoMotor;

            nuevoMotor = new MarcaController(CadenasConexion.BDFOTOCOPIADO_LOCAL);

            return nuevoMotor;
        }

        public static ICatalogoGenericoService CrearConexionDesactivarMarca()
        {
            ICatalogoGenericoService nuevoMotor;

            nuevoMotor = new MarcaController(CadenasConexion.BDFOTOCOPIADO_LOCAL);

            return nuevoMotor;
        }
    }
}
