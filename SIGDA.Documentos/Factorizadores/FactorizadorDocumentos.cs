using SIGDA.Documentos.Controllers;
using SIGDA.Documentos.Services.Interfaces;
using SIGDA.Documentos.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGDA.Documentos.Factorizadores
{
    public static class FactorizadorDocumentos
    {
        public static IMetaDocumentoService CrearConexionGenerica()
        {
            IMetaDocumentoService nuevoMotor;

            nuevoMotor = new MetaDocumentoController(CadenasConexion.SIGDA_DOCUMENTOS);

            return nuevoMotor;
        }

        public static IMetaDocumentoTmpService CrearConexionGenericaDocumentosTmp()
        {
            IMetaDocumentoTmpService nuevoMotor;

            nuevoMotor = new MetaDocumentoTmpController(CadenasConexion.SIGDA_DOCUMENTOS);

            return nuevoMotor;
        }
    }
}
